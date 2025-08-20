﻿using AirlineBookingSystem.Payments.Application.Commands;
using AirlineBookingSystem.Payments.Core.Repositories;
using MediatR;

namespace AirlineBookingSystem.Payments.Application.Handlers;
public class RefundPaymentHandler : IRequestHandler<RefundPaymentCommand>
{
    private readonly IPaymentRepository _repository;

    public RefundPaymentHandler(IPaymentRepository repository)
    {
        _repository = repository;
    }
    public async Task Handle(RefundPaymentCommand request, CancellationToken cancellationToken)
    {
        await _repository.RefundPaymentAsync(request.PaymentId);
    }
}
