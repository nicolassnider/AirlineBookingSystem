using AirlineBookingSystem.BuildingBlocks.Contracts.EventBus.Messages;
using AirlineBookingSystem.Notifications.Application.Commands;
using MassTransit;
using MediatR;

namespace AirlineBookingSystem.Notifications.Application.Consumers;
public class PaymentProceessedConsumer : IConsumer<PaymentProcessEvent>
{
    private readonly IMediator _mediator;

    public PaymentProceessedConsumer(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task Consume(ConsumeContext<PaymentProcessEvent> context)
    {
        var paymentProcessedEvent = context.Message;
        var message = $"Payment processed for Booking ID: {paymentProcessedEvent.BookingId}, Amount: {paymentProcessedEvent.Amount}, Date: {paymentProcessedEvent.PaymentDate}";
        var command = new SendNotificationCommand("mailtest@example.com", message, "Email");
        await _mediator.Send(command);
    }
}
