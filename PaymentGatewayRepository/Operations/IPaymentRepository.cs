using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PaymentGatewayModel;

namespace PaymentGatewayRepository.Operations
{
    public interface IPaymentRepository
    {
        Task<List<Payment>> GetPaymentsAsync();
        Task<Payment> GetPaymentAsync(Guid paymentId);
        Task<Payment> ProcessPaymentAsync(string cardNumber, string cvv, string expiryMonth, string expiryYear, string name, string amount, string currency, Guid merchantId, Guid bankIdTransaction, bool statusPayment);
    }
}
