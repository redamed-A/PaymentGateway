using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BankService;
using PaymentGatewayModel;
using PaymentGatewayRepository.Operations;

namespace PaymentGatewayService
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IAcquiringBankService _acquiringBank;

        public PaymentService(IPaymentRepository paymentRepository, IAcquiringBankService acquiringBank)
        {
            _paymentRepository = paymentRepository;
            _acquiringBank = acquiringBank;
        }
        public Task<List<Payment>> GetPaymentsAsync()
        {
            return _paymentRepository.GetPaymentsAsync();
        }

        public Task<Payment> GetPaymentAsync(Guid paymentId)
        {
            return _paymentRepository.GetPaymentAsync(paymentId);
        }

        public Task<Payment> ProcessPaymentAsync(string cardNumber, string cvv, string expiryMonth, string expiryYear,
            string name, string amount, string currency, Guid merchantId)
        {
            var isPaymentSuccessful = _acquiringBank.ProcessPaymentAsync(cardNumber, cvv, expiryMonth, expiryYear, name, amount, currency, merchantId, out Guid bankIdTransaction).Result;

            // Save this payment to database
            if (isPaymentSuccessful)
            {
                return _paymentRepository.ProcessPaymentAsync(cardNumber, cvv, expiryMonth, expiryYear, name, amount, currency, merchantId, bankIdTransaction, true);
            }
            return null;
        }
    }
}
