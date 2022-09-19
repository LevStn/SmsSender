using Newtonsoft.Json;
using SmsSender.Models;

namespace SmsSender;

public class SenderService : ISenderService
{
    public SenderService()
    {

    }
    public async Task SendMessage(MessageModel messageModel)
    {
        using (var client = new HttpClient())
        {
            var endpoint = new Uri("http://api.prostor-sms.ru/messages/v2/send.json");
            var post = new JsonModelForSend()
            {
                Login = "",
                Password = "",
                Messages = messageModel
            };
            var json = JsonConvert.SerializeObject(post);
            var payLoad = new StringContent(json, encoding: System.Text.Encoding.UTF8, "application/json");
            var result = client.PostAsync(endpoint, payLoad).Result.Content.ReadAsStringAsync().Result;

        }
    }
}
