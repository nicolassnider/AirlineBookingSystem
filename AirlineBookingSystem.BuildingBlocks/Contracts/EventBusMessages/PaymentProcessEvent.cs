namespace AirlineBookingSystem.BuildingBlocks.Contracts.EventBus.Messages;
public record PaymentProcessEvent(Guid PaymentId, Guid BookingId, decimal Amount, DateTime PaymentDate);
