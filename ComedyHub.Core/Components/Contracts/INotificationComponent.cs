using ComedyHub.Model.Publish;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Components.Contracts
{
    public interface INotificationComponent
    {
        void SendSucessfulNotification(PublishedModel publishedModel);
        void SendFailureNotification(Exception exception);
    }
}
