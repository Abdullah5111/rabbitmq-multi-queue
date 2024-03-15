using MassTransit;
using SharedContent.Message;

namespace Service3.Consumer
{
    public class Service1Consumer : IConsumer<Tokenn2>
    {
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
