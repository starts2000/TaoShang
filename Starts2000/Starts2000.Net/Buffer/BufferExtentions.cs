
namespace Starts2000.Net.Buffer
{
    public static class BufferExtentions
    {
        public static int DecodeInt(this IBuffer buffer, int index)
        {
            byte bit1, bit2, bit3, bit4;

            if (buffer.BigEndian)
            {
                bit1 = buffer.ByteArray[index];
                bit2 = buffer.ByteArray[index + 1];
                bit3 = buffer.ByteArray[index + 2];
                bit4 = buffer.ByteArray[index + 3];
            }
            else
            {
                bit1 = buffer.ByteArray[index + 3];
                bit2 = buffer.ByteArray[index + 2];
                bit3 = buffer.ByteArray[index + 1];
                bit4 = buffer.ByteArray[index];
            }

            return (bit1 & 0xff) << 0x18 | (bit2 & 0xff) << 0x10 | (bit3 & 0xff) << 8 | (bit4 & 0xff);
        }

        public static long DecodeLong(this IBuffer buffer, int index)
        {
            byte bit1, bit2, bit3, bit4, bit5, bit6, bit7, bit8;

            if (buffer.BigEndian)
            {
                bit1 = buffer.ByteArray[index];
                bit2 = buffer.ByteArray[index + 1];
                bit3 = buffer.ByteArray[index + 2];
                bit4 = buffer.ByteArray[index + 3];
                bit5 = buffer.ByteArray[index + 4];
                bit6 = buffer.ByteArray[index + 5];
                bit7 = buffer.ByteArray[index + 6];
                bit8 = buffer.ByteArray[index + 7];
            }
            else
            {
                bit1 = buffer.ByteArray[index + 7];
                bit2 = buffer.ByteArray[index + 6];
                bit3 = buffer.ByteArray[index + 5];
                bit4 = buffer.ByteArray[index + 4];
                bit5 = buffer.ByteArray[index + 3];
                bit6 = buffer.ByteArray[index + 2];
                bit7 = buffer.ByteArray[index + 1];
                bit8 = buffer.ByteArray[index];
            }
            return (bit1 & 0xffL) << 0x38 | (bit2 & 0xffL) << 0x30 | (bit3 & 0xffL) << 40 
                | (bit4 & 0xffL) << 0x20 | (bit5 & 0xffL) << 0x18 | (bit6 & 0xffL) << 0x10 
                | (bit7 & 0xffL) << 8 | (bit8 & 0xffL);
        }

        public static short DecodeShort(this IBuffer buffer, int index)
        {
            byte bit1, bit2;

            if (buffer.BigEndian)
            {
                bit1 = buffer.ByteArray[index];
                bit2 = buffer.ByteArray[index + 1];
            }
            else
            {
                bit1 = buffer.ByteArray[index + 1];
                bit2 = buffer.ByteArray[index];
            }

            return (short)((bit1 << 8) | (bit2 & 0xff));
        }

        public static IBuffer EncodeInt(this IBuffer buffer, int index, int intValue)
        {
            byte bit1, bit2, bit3, bit4;

            if (buffer.BigEndian)
            {
                bit1 = (byte)(intValue >> 0x18);
                bit2 = (byte)(intValue >> 0x10);
                bit3 = (byte)(intValue >> 8);
                bit4 = (byte)intValue;
            }
            else
            {
                bit1 = (byte)intValue;
                bit2 = (byte)(intValue >> 8);
                bit3 = (byte)(intValue >> 0x10);
                bit4 = (byte)(intValue >> 0x18);
            }

            buffer.ByteArray[index] = bit1;
            buffer.ByteArray[index + 1] = bit2;
            buffer.ByteArray[index + 2] = bit3;
            buffer.ByteArray[index + 3] = bit4;
            return buffer;
        }

        public static IBuffer EncodeLong(this IBuffer buffer, int index, long longValue)
        {
            byte bit1, bit2, bit3, bit4, bit5, bit6, bit7, bit8;

            if (buffer.BigEndian)
            {
                bit1 = (byte)(longValue >> 0x38);
                bit2 = (byte)(longValue >> 0x30);
                bit3 = (byte)(longValue >> 40);
                bit4 = (byte)(longValue >> 0x20);
                bit5 = (byte)(longValue >> 0x18);
                bit6 = (byte)(longValue >> 0x10);
                bit7 = (byte)(longValue >> 8);
                bit8 = (byte)longValue;
            }
            else
            {
                bit1 = (byte)longValue;
                bit2 = (byte)(longValue >> 8);
                bit3 = (byte)(longValue >> 0x10);
                bit4 = (byte)(longValue >> 0x18);
                bit5 = (byte)(longValue >> 0x20);
                bit6 = (byte)(longValue >> 40);
                bit7 = (byte)(longValue >> 0x30);
                bit8 = (byte)(longValue >> 0x38);
            }

            buffer.ByteArray[index] =  bit1;
            buffer.ByteArray[index + 1] = bit2;
            buffer.ByteArray[index + 2] = bit3;
            buffer.ByteArray[index + 3] = bit4;
            buffer.ByteArray[index + 4] = bit5;
            buffer.ByteArray[index + 5] = bit6;
            buffer.ByteArray[index + 6] = bit7;
            buffer.ByteArray[index + 7] = bit8;
            return buffer;
        }

        public static IBuffer EncodeShort(this IBuffer buffer, int index, short shortValue)
        {
            byte bit1, bit2;

            if (buffer.BigEndian)
            {
                bit1 = (byte)(shortValue >> 8);
                bit2 = (byte)shortValue;
            }
            else
            {
                bit1 = (byte)shortValue;
                bit2 = (byte)(shortValue >> 8);
            }

            buffer.ByteArray[index] = bit1;
            buffer.ByteArray[index + 1] = bit2;
            return buffer;
        }
    }
}
