namespace Starts2000.Threading
{
    public static class CommandProcessorFactory
    {
        static readonly CommandProcessor _defaultInstance;

        static CommandProcessorFactory()
        {
            _defaultInstance = new CommandProcessor("Starts2000");
            _defaultInstance.Start();
        }

        public static CommandProcessor Default
        {
            get { return _defaultInstance; }
        }

        public static CommandProcessor Create(string processorName)
        {
            CommandProcessor processor = new CommandProcessor(processorName);
            processor.Start();
            return processor;
        }
    }
}
