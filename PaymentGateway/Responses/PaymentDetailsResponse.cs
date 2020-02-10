using System;

namespace PaymentGateway.Responses
{
    public class PaymentDetailsResponse
    {
        public string Name { get; set; }
        public string CardNumber { get; set; }
        public string Cvv { get; set; }
        public string ExpiryMonth { get; set; }
        public string ExpiryYear { get; set; }
        public string Currency { get; set; }
        public string Amount { get; set; }
        public Guid MerchantId { get; set; }
        public bool IsStatusPaymentSuccessful { get; set; }
        public Guid BankIdTransaction { get; set; }
    }
}