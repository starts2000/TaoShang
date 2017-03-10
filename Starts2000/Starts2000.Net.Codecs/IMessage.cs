namespace Starts2000.Net.Codecs
{
    public interface IMessage
    {
        IMessageHeader Header { get; set; }
        object Obj { get; set; }
    }
}