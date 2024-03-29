using MassTransit;
using SharedContent.Message;

namespace Service3.Consumer
{
    // IConsumer interface is provided by MassTransit to consume the message
    public class Service1Consumer : IConsumer<Tokenn2>
    {
        // This method will be executed automatically on the receiving of messages
        public async Task Consume(ConsumeContext<Tokenn2> context)
        {
            try
            {
                var message = context.Message;
                Console.WriteLine(message.tokenn);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error consuming message: {ex.Message}");
                Task.FromException(ex);
            }
        }
    }
}
