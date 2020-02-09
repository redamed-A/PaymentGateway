using System;
using System.Threading.Tasks;

namespace BankService
{
    public interface IAcquiringBankService
    {
        Task<bool> ProcessPaymentAsync(string cardNumber, string cvv, string expiryMonth, string expiryYear, string name, string amount, string currency, Guid merchantId, out Guid bankIdTransaction);
    }
}
