﻿using AirlineBookingSystem.BuildingBlocks.Contracts.EventBus.Messages;
using MassTransit;

namespace AirlineBookingSystem.Bookings.Application.Consumers;
public class NotificationEventConsumer : IConsumer<NotificationEvent>
{
    public async Task Consume(ConsumeContext<NotificationEvent> context)
    {
        var notificationEvent = context.Message;
        Console.WriteLine($"received notification: Recipient={notificationEvent.Recipient} , Message= {notificationEvent.Message}");

        await Task.CompletedTask;

    }
}
