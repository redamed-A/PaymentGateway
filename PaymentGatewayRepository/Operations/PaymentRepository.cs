using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentGatewayModel;

namespace PaymentGatewayRepository.Operations
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly PaymentDbContext _db;

        public PaymentRepository(PaymentDbContext db)
        {
            _db = db;
        }
        public Task<List<Payment>> GetPaymentsAsync()
        {
            return Task.FromResult(_db.Payment.ToList());
        }

        public Task<Payment> GetPaymentAsync(Guid paymentId)
        {
            return Task.FromResult(_db.Payment.SingleOrDefault(s => s.PaymentId == paymentId));
        }

        public Task<Payment> ProcessPaymentAsync(string cardNumber, string cvv, string expiryMonth, string expiryYear, string name,
            string amount, string currency, Guid merchantId, Guid bankIdTransaction, bool statusPayment)
        {
            var payment = new Payment
            {
                PaymentId = Guid.NewGuid(),
                CardNumber = cardNumber,
                Cvv = cvv,
                ExpiryMonth = expiryMonth,
                ExpiryYear = expiryYear,
                Name = name,
                Amount = amount,
                Currency = currency,
                MerchantId = merchantId,
                BankIdTransaction = bankIdTransaction,
                IsStatusPaymentSuccessful = statusPayment
            };

             _db.Payment.Add(payment);
             _db.SaveChanges();
             return Task.FromResult(payment);
        }
    }
}
