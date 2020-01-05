using ComedyHub.Model.Publish;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComedyHub.Core.Services.Contracts
{
    public interface INotificationTelegramService
    {
        Task SendTelegramSucessNotification(PublishedModel memePublished);
        Task SendTelegramFailureNotification(Exception exception);
    }
}
