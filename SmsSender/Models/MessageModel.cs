namespace SmsSender.Models;

public class MessageModel
{
    public string Phone { get; set; }
    public string Sender { get; set; }
    public int ClientId { get; set; }
    public string Text { get; set; }
}
