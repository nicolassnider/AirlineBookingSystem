using AirlineBookingSystem.Bookings.Core.Entities;
using AirlineBookingSystem.Bookings.Core.Repositories;
using Dapper;
using System.Data;

namespace AirlineBookingSystem.Bookings.Infrastructure.Repositories;

public class BookingRepository : IBookingRepository

{
    private readonly IDbConnection _dbConnection;

    public BookingRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
    public async Task AddBookingAsync(Booking booking)
    {
        const string sql = @"
        INSERT INTO Bookings (Id, FlightId, PassengerName, SeatNumber, BookingDate)
        VALUES (@Id, @FlightId, @PassengerName, @SeatNumber, @BookingDate)";

        await _dbConnection.ExecuteAsync(sql, booking);
    }

    public async Task<Booking> GetBookingByIdAsync(Guid bookingId)
    {
        const string sql = "SELECT * FROM Bookings WHERE Id = @Id";
        return await _dbConnection.QuerySingleOrDefaultAsync<Booking>(sql, new { Id = bookingId });
    }
}
