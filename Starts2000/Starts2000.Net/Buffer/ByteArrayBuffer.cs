namespace Starts2000.Net.Buffer
{
    public class ByteArrayBuffer : BufferBase
    {
        #region Fields

        byte[] _byteArray;
        static readonly byte[] EmptyByteArray = new byte[0];

        #endregion

        public override byte[] ByteArray
        {
            get { return _byteArray; }
        }

        #region Constructors

        public ByteArrayBuffer(int capacity)
            : base(0, capacity)
        {
            _byteArray = new byte[capacity];
        }

        public ByteArrayBuffer(byte[] content, int offset, int capacity)
            : base(offset, capacity)
        {
            _byteArray = content;
        }

        #endregion

        public override IBuffer Compact()
        {
            base.CheckReadonly();
            System.Buffer.BlockCopy(_byteArray, base.GetIndex(0),
                _byteArray, base.GetIndex(0, 0), base.Remaining);
            base.Position = base.Remaining;
            base.Limit = Capacity;
            return this;
        }

        public override IBuffer Duplicate()
        {
            ByteArrayBuffer buffer = new DelegateReleaseBuffer(this, base.GetIndex(0, 0), Capacity)
            {
                Limit = base.Limit,
                Position = base.Position
            };
            buffer.InternalMark(base.GetMark());
            buffer.ReadOnly = base.ReadOnly;
            return buffer;
        }

        internal override byte InternalGet(int index)
        {
            return _byteArray[index];
        }

        internal override void InternalPut(int index, byte byteValue)
        {
            _byteArray[index] = byteValue;
        }

        protected override void InternalRelease()
        {
            _byteArray = EmptyByteArray;
        }

        public override IBuffer Slice()
        {
            return new DelegateReleaseBuffer(this, base.GetIndex(0), base.Remaining);
        }

        public static ByteArrayBuffer Wrap(byte[] array)
        {
            return Wrap(array, 0, array.Length);
        }

        public static ByteArrayBuffer Wrap(byte[] array, int offset, int length)
        {
            CheckBounds(offset, length, array.Length);
            return new ByteArrayBuffer(array, 0, array.Length)
            {
                Limit = offset + length,
                Position = offset
            };
        }

        private class DelegateReleaseBuffer : ByteArrayBuffer
        {
            readonly ByteArrayBuffer _parentBuffer;

            public override bool Permanent
            {
                get { return _parentBuffer.Permanent; }
                set { _parentBuffer.Permanent = value; }
            }

            public override bool Released
            {
                get { return _parentBuffer.Released; }
            }

            public DelegateReleaseBuffer(ByteArrayBuffer buffer, int offset, int capacity)
                : base(buffer._byteArray, offset, capacity)
            {
                _parentBuffer = buffer;
            }

            public override void Release()
            {
                _parentBuffer.Release();
            }
        }
    }
}