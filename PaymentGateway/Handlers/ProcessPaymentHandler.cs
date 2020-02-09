using AutoMapper;
using MediatR;
using PaymentGateway.Commands;
using PaymentGateway.Responses;
using PaymentGatewayService;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace PaymentGateway.Handlers
{
    public class ProcessPaymentHandler : IRequestHandler<ProcessPaymentCommand, PaymentTransactionResponse>
    {
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;
        private readonly ILogger<ProcessPaymentHandler> _logger;
        public ProcessPaymentHandler(IPaymentService paymentService, IMapper mapper, ILogger<ProcessPaymentHandler> logger)
        {
            _paymentService = paymentService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<PaymentTransactionResponse> Handle(ProcessPaymentCommand request, CancellationToken cancellationToken)
        {
            var payment = await _paymentService.ProcessPaymentAsync(request.CardNumber, request.Cvv,
                request.ExpiryMonth, request.ExpiryYear, request.Name, request.Amount, request.Currency,
                request.MerchantId);
            _logger.LogInformation($"Payment processed : {payment.PaymentId} for shopper: {payment.Name}");
            return _mapper.Map<PaymentTransactionResponse>(payment);
        }
    }
}
