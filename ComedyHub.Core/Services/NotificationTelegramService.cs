using ComedyHub.Core.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Services
{
    public class NotificationTelegramService : INotificationTelegramService
    {
        public void SendTelegramFailureNotification(string error)
        {
            throw new NotImplementedException();
        }

        public void SendTelegramSucessNotification(string memePublished)
        {
            throw new NotImplementedException();
        }
    }
}
