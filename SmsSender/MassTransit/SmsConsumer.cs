using MassTransit;
using SmsSender.Models;

namespace SmsSender.MassTransit;

public class SmsConsumer : IConsumer<MessageModel>
{
    private readonly ISenderService _senderService;
    public SmsConsumer (ISenderService senderService)
    {
        _senderService = senderService;

    }

    public async Task Consume(ConsumeContext<MessageModel> context)
    {
        await _senderService.SendMessage(context.Message);
    }
}
