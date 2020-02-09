using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using PaymentGateway.Responses;

namespace PaymentGateway.Commands
{
    public class ProcessPaymentCommand : IRequest<PaymentTransactionResponse>
    {
        public string Name { get; set; }
        public string CardNumber { get; set; }
        public string Cvv { get; set; }
        public string ExpiryMonth { get; set; }
        public string ExpiryYear { get; set; }
        public string Currency { get; set; }
        public string Amount { get; set; }
        public Guid MerchantId { get; set; }
    }
}
