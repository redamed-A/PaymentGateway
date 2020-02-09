using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PaymentGateway.Queries;
using PaymentGateway.Responses;
using PaymentGatewayService;

namespace PaymentGateway.Handlers
{
    public class GetPaymentByIdHandler : IRequestHandler<GetPaymentByIdQuery, PaymentDetailsResponse>
    {
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;

        public GetPaymentByIdHandler(IPaymentService paymentService, IMapper mapper)
        {
            _paymentService = paymentService;
            _mapper = mapper;
        }
        public async Task<PaymentDetailsResponse> Handle(GetPaymentByIdQuery request, CancellationToken cancellationToken)
        {
            var payments = await _paymentService.GetPaymentsAsync();
            return _mapper.Map<PaymentDetailsResponse>(payments);
        }
    }
}
