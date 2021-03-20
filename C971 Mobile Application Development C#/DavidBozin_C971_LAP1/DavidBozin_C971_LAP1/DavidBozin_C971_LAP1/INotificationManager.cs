using System;

namespace DavidBozin_C971_LAP1
{
    public interface INotificationManager
    {
        event EventHandler NotificationReceived;
        void Initialize();
        int ScheduleNotification(string title, string message);
        void ReceiveNotification(string title, string message);
    }
}