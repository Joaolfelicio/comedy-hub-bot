using ComedyHub.Model.Notification.TelegramMessage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComedyHub.Core.Infrastructure.Gateway.Contracts
{
    public interface ITelegramGateway
    {
        Task SendPhotoMessage(TelegramPhotoMessage telegramPhotoMessage);

        Task SendTextMessage(TelegramTextMessage telegramTextMessage);
    }
}
