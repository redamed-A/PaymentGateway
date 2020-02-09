using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Responses
{
    public class PaymentTransactionResponse
    {
        public bool StatusPayment { get; set; }
        public Guid BankIdTransaction { get; set; }
    }
}
