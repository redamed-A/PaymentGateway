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
    public class GetAllPaymentsHandler : IRequestHandler<GetAllPaymentsQuery, List<PaymentDetailsResponse>>
    {
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;

        public GetAllPaymentsHandler(IPaymentService paymentService, IMapper mapper)
        {
            _paymentService = paymentService;
            _mapper = mapper;
        }
        public async Task<List<PaymentDetailsResponse>> Handle(GetAllPaymentsQuery request, CancellationToken cancellationToken)
        {
            var payments = await _paymentService.GetPaymentsAsync();
            return _mapper.Map<List<PaymentDetailsResponse>>(payments);
        }
    }
}
