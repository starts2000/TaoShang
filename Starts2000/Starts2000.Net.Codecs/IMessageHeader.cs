using Starts2000.Net.Buffer;
namespace Starts2000.Net.Codecs
{
    public interface IMessageHeader
    {
        uint Tag { get; set; }
        byte Version { get; set; }
        ushort Type { get; set; }
        ushort SubType { get; set; }
        bool Zip { get; set; }
        bool Encrypted { get; set; }
        int Length { get; set; }

        void Write(IBuffer buffer);
    }
}
