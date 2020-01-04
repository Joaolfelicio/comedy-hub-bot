using ComedyHub.Core.Services.Contracts;
using ComedyHub.Model.Publish;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Services
{
    public class NotificationTelegramService : INotificationTelegramService
    {
        public void SendTelegramFailureNotification(Exception exception)
        {
            throw new NotImplementedException();
        }

        public void SendTelegramSucessNotification(PublishedModel memePublished)
        {
            throw new NotImplementedException();
        }
    }
}
