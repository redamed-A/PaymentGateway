using PaymentGatewayModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentGatewayService
{
    public interface IPaymentService
    {
        Task<List<Payment>> GetPaymentsAsync();
        Task<Payment> GetPaymentAsync(Guid paymentId);
        Task<Payment> ProcessPaymentAsync(string cardNumber, string cvv, string expiryMonth, string expiryYear, string name, string amount, string currency, Guid merchantId);
    }
}
