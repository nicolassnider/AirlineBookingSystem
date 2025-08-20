﻿using AirlineBookingSystem.Payments.Core.Entities;
using AirlineBookingSystem.Payments.Core.Repositories;
using Dapper;
using System.Data;

namespace AirlineBookingSystem.Payments.Infrastructure.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly IDbConnection _dbConnection;

        public PaymentRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task ProcessPaymentAsync(Payment payment)
        {
            const string query = @"INSERT INTO Payments(Id,BookingId,Amount,PaymentDate
                                   VALUES(@Id,@BookingId,@Amount,@PaymentDate)";

            await _dbConnection.ExecuteAsync(query, payment);


        }

        public async Task RefundPaymentAsync(Guid paymentId)
        {
            const string sql = "DELETE FROM Payments WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(sql, new { Id = paymentId });
        }
    }
}
