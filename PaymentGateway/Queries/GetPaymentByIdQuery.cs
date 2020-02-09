using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using PaymentGateway.Responses;

namespace PaymentGateway.Queries
{
    public class GetPaymentByIdQuery : IRequest<PaymentDetailsResponse>
    {
        public Guid PaymentId { get;}

        public GetPaymentByIdQuery(Guid paymentId)
        {
            PaymentId = paymentId;
        }
    }
   
}
