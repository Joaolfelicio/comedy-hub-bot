using ComedyHub.Core.Components.Contracts;
using ComedyHub.Core.Services.Contracts;
using ComedyHub.Model.Publish;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComedyHub.Core.Components
{
    public class NotificationComponent : INotificationComponent
    {
        private readonly INotificationTelegramService _notificationTelegramService;

        public NotificationComponent(INotificationTelegramService notificationTelegramService)
        {
            _notificationTelegramService = notificationTelegramService;
        }

        public async Task SendSucessfulNotification(PublishedModel publishedModel)
        {
            await _notificationTelegramService.SendTelegramSucessNotification(publishedModel);
        }

        public async Task SendFailureNotification(Exception exception)
        {
            await _notificationTelegramService.SendTelegramFailureNotification(exception);
            throw new NotImplementedException();
        }
    }
}
