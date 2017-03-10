using System;

namespace Starts2000.Net.Buffer
{
    public interface IBuffer : IDisposable
    {
        byte[] ByteArray { get; }
        bool BigEndian { get; set; }
        int Capacity { get; }
        bool HasRemaining { get; }
        int Limit { get; set; }
        bool Permanent { get; set; }
        int Position { get; set; }
        bool ReadOnly { get; }
        bool Released { get; }
        int Remaining { get; }

        IBuffer AsReadOnlyBuffer();
        IBuffer Clear();
        IBuffer Compact();
        string Dump();
        IBuffer Duplicate();
        IBuffer Flip();
        byte Get();
        byte Get(int index);
        int IndexOf(byte[] target);
        IBuffer Mark();
        IBuffer Put(IBuffer source);
        IBuffer Put(IBuffer source, int length);
        void Release();
        IBuffer Reset();
        IBuffer Rewind();
        IBuffer Skip(int size);
        IBuffer Slice();
    }
}
