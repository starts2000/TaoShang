using System;
using Starts2000.Net.Buffer;
namespace Starts2000.Net.Codecs.Message
{
    public class DefaultMessageHeader : IMessageHeader
    {
        public const int HeaderLength = 15;

        public uint Tag { get; set; }
        public byte Version { get; set; }
        public ushort Type { get; set; }
        public ushort SubType { get; set; }
        public bool Zip { get; set; }
        public bool Encrypted { get; set; }
        public int Length { get; set; }

        public void Write(IBuffer buffer)
        {
            System.Buffer.BlockCopy(BitConverter.GetBytes(DefaultMessage.HeaderTag),
                0, buffer.ByteArray, 0, 4);
            buffer.ByteArray[4] = DefaultMessage.Version;
            System.Buffer.BlockCopy(BitConverter.GetBytes(Type),
                0, buffer.ByteArray, 5, 2);
            System.Buffer.BlockCopy(BitConverter.GetBytes(SubType),
                0, buffer.ByteArray, 7, 2);
            System.Buffer.BlockCopy(BitConverter.GetBytes(Zip),
                 0, buffer.ByteArray, 9, 1);
            System.Buffer.BlockCopy(BitConverter.GetBytes(Encrypted),
                0, buffer.ByteArray, 10, 1);
            System.Buffer.BlockCopy(BitConverter.GetBytes(Length),
                0, buffer.ByteArray, 11, 4);
        }
    }
}
