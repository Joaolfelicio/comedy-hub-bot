using ComedyHub.Core.Components.Contracts;
using ComedyHub.Model.Publish;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComedyHub.Core.Components
{
    public class NotificationComponent : INotificationComponent
    {

        public void SendSucessfulNotification(PublishedModel publishedModel)
        {
            throw new NotImplementedException();
        }

        public void SendFailureNotification(Exception exception)
        {
            throw new NotImplementedException();
        }
    }
}
