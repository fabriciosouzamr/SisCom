using Funcoes.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Funcoes.Interfaces
{
    public interface INotifier
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
        void Handle(string notification);
    }
}
