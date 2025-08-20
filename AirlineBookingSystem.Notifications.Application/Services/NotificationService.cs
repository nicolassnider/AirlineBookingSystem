using AirlineBookingSystem.Notifications.Application.Interfaces;
using AirlineBookingSystem.Notifications.Core.Entities;

namespace AirlineBookingSystem.Notifications.Application.Services;
public class NotificationService : INotificationService
{
    public async Task SendNotificationAsync(Notification notification)
    {
        Console.WriteLine($"Sending {notification.Type} to {notification.Recipient}: {notification.Message}");

    }
}

