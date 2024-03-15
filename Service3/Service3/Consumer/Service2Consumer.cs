using MassTransit;
using SharedContent.Message;

namespace Service3.Consumer
{
    public class Service2Consumer : IConsumer<Notification>
    {
        public async Task Consume(ConsumeContext<Notification> context)
        {
            try
            {
                var message = context.Message;
                Console.WriteLine(message.Title);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error consuming message: {ex.Message}");
                Task.FromException(ex);
            }
        }
    }
}
