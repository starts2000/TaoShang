using System;
using System.Text;
using Starts2000.Net.Buffer;

namespace Starts2000.Net.Codecs.Message
{
    public class DefaultMessage : IMessage
    {
        public const uint HeaderTag = 0xFFFFFF00;
        public const byte Version = 1;

        public DefaultMessage()
        {

        }

        public DefaultMessage(object data, ushort type, ushort subType = 0, bool zip = false,
            bool encrypted = false, uint tag = HeaderTag, byte version = Version)
        {
            Header = new DefaultMessageHeader()
            {
                Tag = HeaderTag,
                Version = version,
                Type = type,
                SubType = subType,
                Zip = zip,
                Encrypted = encrypted
            };

            Obj = data;
        }

        public IMessageHeader Header { get; set; }

        public object Obj { get; set; }

        public IBuffer ToBuffer(Func<object, byte[]> messageBodyEncoder)
        {
            return ToBuffer(this, messageBodyEncoder);
        }

        public static IBuffer ToBuffer(DefaultMessage message, Func<object, byte[]> messageBodyEncoder)
        {
            byte[] data = messageBodyEncoder(message.Obj);
            IBuffer buffer = BufferFactory.GetBuffer(data.Length + DefaultMessageHeader.HeaderLength);
            message.Header.Length = data.Length;
            message.Header.Write(buffer);
            System.Buffer.BlockCopy(data, 0, buffer.ByteArray, 
                DefaultMessageHeader.HeaderLength, data.Length);
            return buffer;
        }

        public static DefaultMessage FromBuffer(IBuffer buffer, 
            Func<IBuffer, int, int, ushort, object> messageBodyDecoder)
        {
            if (buffer.Remaining < DefaultMessageHeader.HeaderLength)
            {
                return null;
            }

            int index = buffer.IndexOf(BitConverter.GetBytes(HeaderTag));

            if (index != -1)
            {
                buffer.Position = index;

                if (buffer.Remaining >= DefaultMessageHeader.HeaderLength)
                {
                    int messageLength = BitConverter.ToInt32(
                        buffer.ByteArray, buffer.Position + 11);
                    if (buffer.Remaining >= DefaultMessageHeader.HeaderLength + messageLength)
                    {
                        DefaultMessageHeader header = new DefaultMessageHeader();
                        header.Tag = HeaderTag;
                        header.Version = buffer.ByteArray[buffer.Position + 4];
                        header.Type = BitConverter.ToUInt16(
                            buffer.ByteArray, buffer.Position + 5);
                        header.SubType = BitConverter.ToUInt16(
                            buffer.ByteArray, buffer.Position + 7);
                        header.Zip = BitConverter.ToBoolean(buffer.ByteArray, buffer.Position + 9);
                        header.Encrypted = BitConverter.ToBoolean(buffer.ByteArray, buffer.Position + 10);
                        header.Length = messageLength;

                        object obj = messageBodyDecoder(buffer,
                            buffer.Position + DefaultMessageHeader.HeaderLength, messageLength, header.Type);

                        buffer.Position += (DefaultMessageHeader.HeaderLength + messageLength);
                        return new DefaultMessage
                        {
                            Header = header,
                            Obj = obj
                        };
                    }
                }
            }
            else
            {
                buffer.Position = buffer.Limit;
            }

            return null;
        }
    }
}
