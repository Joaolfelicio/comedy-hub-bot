using ComedyHub.Model.Publish;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Services.Contracts
{
    public interface INotificationTelegramService
    {
        void SendTelegramSucessNotification(PublishedModel memePublished);
        void SendTelegramFailureNotification(Exception exception);
    }
}
