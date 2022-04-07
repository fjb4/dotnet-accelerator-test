using Steeltoe.Extensions.Logging;

namespace MyNamespace.Common
{
    public class NullLogProcessor : IDynamicMessageProcessor
    {
        public string Process(string inputLogMessage) => inputLogMessage;
    }
}