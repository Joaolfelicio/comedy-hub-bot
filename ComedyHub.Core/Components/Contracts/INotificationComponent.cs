using ComedyHub.Model.Publish;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComedyHub.Core.Components.Contracts
{
    public interface INotificationComponent
    {
        Task SendSucessfulNotification(PublishedModel publishedModel);
        Task SendFailureNotification(Exception exception);
    }
}
