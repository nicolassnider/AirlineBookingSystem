﻿namespace AirlineBookingSystem.BuildingBlocks.Contracts.EventBus.Messages;
public record FlightBookedEvent(Guid BookingId, Guid FlightId, string PassengerName, string SeatNumber, DateTime BookingDate);
