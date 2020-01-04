using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Services.Contracts
{
    public interface INotificationTelegramService
    {
        void SendTelegramSucessNotification(string memePublished);
        void SendTelegramFailureNotification(string error);
    }
}
