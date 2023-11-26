using GodzillaRestaurant.Models;

namespace GodzillaRestaurant.Services
{
    public interface IMailService
    {
        Task SendMail(MailContent mailContent);
    }
}
