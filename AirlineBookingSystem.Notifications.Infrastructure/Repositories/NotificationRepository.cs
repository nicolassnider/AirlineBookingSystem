using AirlineBookingSystem.Notifications.Core.Entities;
using AirlineBookingSystem.Notifications.Core.Repositories;
using Dapper;
using System.Data;

namespace AirlineBookingSystem.Notifications.Infrastructure.Repositories;

public class NotificationRepository : INotificationRepository
{
    private readonly IDbConnection _database;

    public NotificationRepository(IDbConnection database)
    {
        _database = database;
    }
    public async Task LogNotificationAsync(Notification notification)
    {
        const string sql = @"
            INSERT INTO Notifications (Id, Recipient, Message, Type, SentAt)
            VALUES (@Id, @Recipient, @Message, @Type, @SentAt)";

        await _database.ExecuteAsync(sql, notification);
    }
}
