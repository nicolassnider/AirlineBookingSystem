using AirlineBookingSystem.Notifications.Application.Interfaces;
using AirlineBookingSystem.Notifications.Core.Entities;
using MassTransit;

namespace AirlineBookingSystem.Notifications.Application.Services;
public class NotificationService : INotificationService
{
    private readonly IPublishEndpoint _publishEndpoint;

    public NotificationService(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }
    public async Task SendNotificationAsync(Notification notification)
    {
        Console.WriteLine($"Sending {notification.Type} to {notification.Recipient}: {notification.Message}");
        await _publishEndpoint.Publish(notification);
    }
}
