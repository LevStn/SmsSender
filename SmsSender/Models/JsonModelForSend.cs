namespace SmsSender.Models;

public class JsonModelForSend
{
    public string Login { get; set; }
    public string Password { get; set; }
    public MessageModel Messages { get; set; }
}
