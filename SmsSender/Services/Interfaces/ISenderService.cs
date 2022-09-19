using SmsSender.Models;

namespace SmsSender;

public interface ISenderService
{
    public Task SendMessage(MessageModel messageModel);
}
