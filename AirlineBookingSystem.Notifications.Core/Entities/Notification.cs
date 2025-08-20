﻿namespace AirlineBookingSystem.Notifications.Core.Entities;

public class Notification
{
    public Guid Id { get; set; }
    public string Recipient { get; set; }
    public string Message { get; set; }
    public string Type { get; set; }
}
