using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BankService
{
    /// <summary>
    /// In this class we simulate the bank acquiring operations and response
    /// </summary>
    public class AcquiringBankService : IAcquiringBankService
    {
        public Task<bool> ProcessPaymentAsync(string cardNumber, string cvv, string expiryMonth, string expiryYear, string name,
            string amount, string currency, Guid merchantId, out Guid bankIdTransaction)
        {
            var isPaymentSuccess = false;
            bankIdTransaction = default;

            // 1- Validation
            var isCardInfoValid = ValidateCardInfo(cardNumber, cvv, expiryMonth, expiryYear);
            if (isCardInfoValid)
            {
                // 2- Payment
                isPaymentSuccess = PayOutMerchant(cardNumber, cvv, expiryMonth, expiryYear, name, amount, currency, merchantId, out bankIdTransaction);
            }

            // 3- Send Response back to Api gateway
            return Task.FromResult(isPaymentSuccess);
        }

        private bool PayOutMerchant(string cardNumber, string cvv, string expiryMonth, string expiryYear, string name,
            string amount, string currency, Guid merchantId, out Guid bankIdTransaction)
        {
            // Generate/ Mocking id of bank response transaction
            // we assume at this stage the payment was successful

            bankIdTransaction = Guid.NewGuid();

            return true;

        }

        private bool ValidateCardInfo(string cardNumber, string cvv, string expiryMonth, string expiryYear)
        {
            ValidateCardNumber(cardNumber);
            var cardCheck = new Regex(@"^(1298|1267|4512|4567|8901|8933)([\-\s]?[0-9]{4}){3}$");
            var monthCheck = new Regex(@"^(0[1-9]|1[0-2])$");
            var yearCheck = new Regex(@"^20[0-9]{2}$");
            var cvvCheck = new Regex(@"^\d{3}$");

            if (!cardCheck.IsMatch(cardNumber) && !ValidateCardNumber(cardNumber))
                return false;

            if (!cvvCheck.IsMatch(cvv)) 
                return false;

          
            if (!monthCheck.IsMatch(expiryMonth) || !yearCheck.IsMatch(expiryYear))
                return false;

            var year = int.Parse(expiryYear);
            var month = int.Parse(expiryMonth);
            var lastDateOfExpiryMonth = DateTime.DaysInMonth(year, month); 
            var cardExpiry = new DateTime(year, month, lastDateOfExpiryMonth, 23, 59, 59);

            
            return (cardExpiry > DateTime.Now && cardExpiry < DateTime.Now.AddYears(6));
        }

        private bool ValidateCardNumber(string cardNumber)
        {

            if (string.IsNullOrEmpty(cardNumber))
            {
                return false;
            }
            int sumOfDigits = cardNumber.Where((e) => e >= '0' && e <= '9')
                .Reverse()
                .Select((e, i) => ((int)e - 48) * (i % 2 == 0 ? 1 : 2))
                .Sum((e) => e / 10 + e % 10);

            return sumOfDigits % 10 == 0;
        }
    }
}
