using System;
using System.Text;
using System.Threading;

namespace Starts2000.Net.Buffer
{
    public abstract class BufferBase : IBuffer, IDisposable
    {
        #region Fields

        int _capacity;
        int _limit;
        int _mark = -1;
        bool _bigEndian = true;
        bool _permanent;
        int _position;
        bool _readOnly;
        bool _released;
        readonly int _offset;

        readonly object _syncRoot = new object();

        #endregion

        #region Properties

        public bool BigEndian
        {
            get { return _bigEndian; }
            set { _bigEndian = value; }
        }

        public virtual int Capacity
        {
            get { return _capacity; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }

                _capacity = value;
                Limit = Math.Min(_limit, _capacity);
            }
        }

        public bool HasRemaining
        {
            get { return _limit > _position; }
        }

        public abstract byte[] ByteArray { get; }

        public int Limit
        {
            get { return _limit; }
            set
            {
                if (value > _capacity || value < 0)
                {
                    throw new ArgumentException();
                }

                _limit = value;
                Position = Math.Min(_position, _limit);
            }
        }

        public virtual bool Permanent
        {
            get { return _permanent; }
            set
            {
                CheckReleased();
                _permanent = value;
            }
        }

        public int Position
        {
            get { return _position; }
            set
            {
                if (value > _limit || value < 0)
                {
                    throw new ArgumentException();
                }

                Interlocked.Exchange(ref _position, value);

                if (_mark > _position)
                {
                    _mark = -1;
                }
            }
        }

        public bool ReadOnly
        {
            get { return _readOnly; }
            protected set { _readOnly = value; }
        }

        public virtual bool Released
        {
            get { return _released; }
        }

        public int Remaining
        {
            get { return _limit - _position; }
        }

        #endregion

        #region Constructors

        protected BufferBase(int offset, int capacity)
        {
            _offset = offset;
            _capacity = capacity;
            Limit = capacity;
        }

        #endregion

        #region Methods

        public IBuffer AsReadOnlyBuffer()
        {
            BufferBase buffer = (BufferBase)Duplicate();
            buffer.ReadOnly = true;
            return buffer;
        }

        public IBuffer Reset()
        {
            if (_mark < 0)
            {
                throw new InvalidMarkException();
            }

            _position = _mark;
            return this;
        }

        public IBuffer Rewind()
        {
            _position = 0;
            _mark = -1;
            return this;
        }

        public IBuffer Skip(int size)
        {
            if (size != 0)
            {
                Position = _position + size;
            }
            return this;
        }

        public IBuffer Clear()
        {
            _position = 0;
            _limit = _capacity;
            _mark = -1;
            return this;
        }

        public abstract IBuffer Compact();

        public abstract IBuffer Slice();

        public abstract IBuffer Duplicate();
        public IBuffer Flip()
        {
            _limit = _position;
            _position = 0;
            _mark = -1;
            return this;
        }

        public byte Get()
        {
            return InternalGet(GetIndex(1));
        }

        public byte Get(int index)
        {
            return InternalGet(GetIndex(index, 1));
        }

        /// <summary>
        /// 获取指定 byte[] 数据在缓存中的第一个匹配项的从零开始的位置值。
        /// </summary>
        /// <param name="value">要搜寻的 byte[] 数据。</param>
        /// <returns>如果找到该 byte[] 数据，则为 value 的从零开始的位置值；
        /// 如果未找到该 byte[] 数据，则为 -1。</returns>
        public int IndexOf(byte[] value)
        {
            if (value == null || value.Length == 0)
            {
                return _position;
            }

            int startIndex = GetIndex(0);
            int maxIndex = (startIndex + Remaining) - value.Length;
            byte firstValue = value[0];
            int currentIndex = startIndex;

            while (currentIndex <= maxIndex)
            {
                if (InternalGet(currentIndex) == firstValue)
                {
                    for (int i = 1; i < value.Length; i++)
                    {
                        if (InternalGet(currentIndex + i) != value[i])
                        {
                            goto NextIndex;
                        }
                    }
                    return (currentIndex - startIndex) + _position;
                }

            NextIndex:
                currentIndex++;
            }

            return -1;
        }

        public IBuffer Mark()
        {
            return InternalMark(_position);
        }

        public IBuffer Put(IBuffer source)
        {
            return Put(source, source.Remaining);
        }

        public IBuffer Put(IBuffer source, int length)
        {
            CheckBounds(0, length, source.Remaining);
            int index = PutIndex(length);

            for (int i = 0; i < length; i++)
            {
                InternalPut(index + i, source.Get());
            }

            return this;
        }

        public string Dump()
        {
            byte[] innerByteArray = ByteArray;
            string newLineStr = Environment.NewLine;
            int hexLength = 0x10;
            int hexCapacity = (int)Math.Ceiling((double)_capacity / hexLength);

            StringBuilder builder = new StringBuilder(hexCapacity * hexLength * 6);
            builder.Append(ToString()).Append(newLineStr);
            byte[] dst = new byte[hexLength];

            int rowIndex = 0;

            for (int i = 0; i < hexCapacity; i++)
            {
                if (rowIndex != 0)
                {
                    builder.Append(newLineStr);
                }

                string rowHeaderStr = string.Format("{0:x}", rowIndex);

                for (int j = 8 - rowHeaderStr.Length; j > 0; j--)
                {
                    builder.Append(0);
                }

                builder.Append(rowHeaderStr).Append("h:");

                if (innerByteArray.Length - rowIndex < hexLength)
                {
                    dst = new byte[innerByteArray.Length - rowIndex];
                }

                System.Buffer.BlockCopy(innerByteArray, rowIndex, dst, 0, dst.Length);

                for (int k = 0; k < hexLength; k++)
                {
                    if (rowIndex == _position || rowIndex == _limit)
                    {
                        builder.Append("'");
                    }
                    else
                    {
                        builder.Append(" ");
                    }

                    rowIndex++;

                    if (k < dst.Length)
                    {
                        string commentStr = string.Format("{0:x}", dst[k] & 0xff);

                        if (commentStr.Length < 2)
                        {
                            builder.Append(0);
                        }

                        builder.Append(commentStr);
                    }
                    else
                    {
                        builder.Append("  ");
                    }
                }

                builder.Append(" ; ");

                foreach (char ch in Encoding.Default.GetString(dst))
                {
                    builder.Append(char.IsControl(ch) ? '.' : ch);
                }
            }

            return builder.ToString();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(base.GetType().Name);
            builder.Append("[position=").Append(_position);
            builder.Append(" limit=").Append(_limit);
            builder.Append(" capacity=").Append(_capacity);
            builder.Append("]");
            return builder.ToString();
        }

        public virtual void Release()
        {
            if (!_permanent && !_released)
            {
                lock (_syncRoot)
                {
                    if (_permanent || _released)
                    {
                        try
                        {
                            InternalRelease();
                        }
                        finally
                        {
                            _released = true;
                        }
                    }
                }
            }
        }

        public void Dispose()
        {
            Release();
        }

        internal abstract byte InternalGet(int index);
        internal abstract void InternalPut(int index, byte byteValue);

        protected int GetIndex(int length)
        {
            CheckReleased();

            if (_limit - _position < length)
            {
                throw new BufferUnderflowException();
            }

            int currentIndex = _position + _offset;
            _position += length;
            return currentIndex;
        }

        protected int GetIndex(int position, int length)
        {
            CheckReleased();

            if (length < 0 || position < 0 || length > _limit - position)
            {
                throw new IndexOutOfRangeException();
            }

            return position + _offset;
        }

        protected int GetMark()
        {
            return _mark;
        }

        protected int PutIndex(int length)
        {
            CheckReleased();
            CheckReadonly();

            if (_limit - _position < length)
            {
                throw new BufferOverflowException();
            }

            int cuurentIndex = _position + _offset;
            _position += length;

            return cuurentIndex;
        }

        protected int PutIndex(int index, int length)
        {
            CheckReleased();
            CheckReadonly();

            if (length < 0 || index < 0 || length > _limit - index)
            {
                throw new IndexOutOfRangeException();
            }

            return index + _offset;
        }

        protected IBuffer InternalMark(int newMark)
        {
            if (newMark < 0)
            {
                _mark = -1;
            }
            else
            {
                if (newMark > _position)
                {
                    throw new IndexOutOfRangeException();
                }

                _mark = newMark;
            }

            return this;
        }

        protected abstract void InternalRelease();

        protected static void CheckBounds(int offset, int length, int size)
        {
            if ((offset | length | offset + length | size - (offset + length)) < 0)
            {
                throw new IndexOutOfRangeException();
            }
        }

        protected void CheckReadonly()
        {
            if (ReadOnly)
            {
                throw new ReadOnlyBufferException();
            }
        }

        protected void CheckReleased()
        {
            if (Released)
            {
                throw new ReleasedBufferException();
            }
        }

        #endregion
    }
}