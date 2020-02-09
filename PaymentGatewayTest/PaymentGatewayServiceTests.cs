using BankService;
using Moq;
using PaymentGatewayModel;
using PaymentGatewayRepository.Operations;
using PaymentGatewayService;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PaymentGatewayTest
{
    public class PaymentGatewayServiceTests
    {
        private readonly PaymentService _paymentService;
        private readonly Mock<IPaymentRepository> _paymentRepositoryMock;
        private readonly Mock<IAcquiringBankService> _acquiringBankMock;
        private readonly Guid _paymentId = Guid.NewGuid();
        private readonly string _cardNumber = "4612025586169186";
        private readonly string _cvv = "180";
        private readonly string _expiryMonth = "05";
        private readonly string _expiryYear = "2020";
        private readonly string _name = "CheckoutCustomerName";
        private readonly string _amount = "120";
        private readonly string _currency = "EUR";
        private readonly Guid _merchantId = Guid.NewGuid();
        private readonly Guid _bankIdTransaction = Guid.NewGuid();
        private readonly bool _statusPayment = true;

        public PaymentGatewayServiceTests()
        {
            _paymentRepositoryMock = new Mock<IPaymentRepository>();
            _acquiringBankMock = new Mock<IAcquiringBankService>();
            _paymentService = new PaymentService(_paymentRepositoryMock.Object, _acquiringBankMock.Object);
        }

        [Fact]
        public async void GetPaymentAsync_ShouldReturnPayment_WhenPaymentExists()
        {
            // Arrange
            var expectedPayment = new Payment
            {
                PaymentId = _paymentId,
                CardNumber = _cardNumber,
                Cvv = _cvv,
                ExpiryMonth = _expiryMonth,
                ExpiryYear = _expiryYear,
                Name = _name,
                Amount = _amount,
                Currency = _currency,
                MerchantId = _merchantId,
                BankIdTransaction = _bankIdTransaction,
                IsStatusPaymentSuccessful = _statusPayment
            };
            _paymentRepositoryMock.Setup(x => x.GetPaymentAsync(_paymentId)).ReturnsAsync(expectedPayment);

            // Act
            var payment = await _paymentService.GetPaymentAsync(_paymentId);

            // Assert
            Assert.Equal(expectedPayment.PaymentId, payment.PaymentId);
            Assert.Equal(expectedPayment.CardNumber, payment.CardNumber);
            Assert.Equal(expectedPayment.Cvv, payment.Cvv);
            Assert.Equal(expectedPayment.ExpiryMonth, payment.ExpiryMonth);
            Assert.Equal(expectedPayment.ExpiryYear, payment.ExpiryYear);
            Assert.Equal(expectedPayment.Name, payment.Name);
            Assert.Equal(expectedPayment.Amount, payment.Amount);
            Assert.Equal(expectedPayment.Currency, payment.Currency);
            Assert.Equal(expectedPayment.MerchantId, payment.MerchantId);
            Assert.Equal(expectedPayment.BankIdTransaction, payment.BankIdTransaction);
            Assert.Equal(expectedPayment.IsStatusPaymentSuccessful, payment.IsStatusPaymentSuccessful);
        }

        [Fact]
        public async void GetPaymentAsync_ShouldReturnNothing_WhenPaymentDoesNotExist()
        {
            // Arrange
            _paymentRepositoryMock.Setup(x => x.GetPaymentAsync(It.IsAny<Guid>())).ReturnsAsync(() => null);

            // Act
            var payment = await _paymentService.GetPaymentAsync(Guid.NewGuid());

            // Assert
            Assert.Null(payment);
        }

        [Fact]
        public async void ProcessPaymentAsync_ShouldReturnPayment_WhenPaymentSucceed()
        {
            // Arrange
            Guid bankIdTransaction = Guid.NewGuid();

            var expectedPayment = new Payment
            {
                PaymentId = _paymentId,
                CardNumber = _cardNumber,
                Cvv = _cvv,
                ExpiryMonth = _expiryMonth,
                ExpiryYear = _expiryYear,
                Name = _name,
                Amount = _amount,
                Currency = _currency,
                MerchantId = _merchantId,
                BankIdTransaction = bankIdTransaction,
                IsStatusPaymentSuccessful = true
            };

            _acquiringBankMock.Setup(x => x.ProcessPaymentAsync(_cardNumber, _cvv, _expiryMonth, _expiryYear, _name,
                _amount, _currency, _merchantId, out bankIdTransaction)).ReturnsAsync(true);

            _paymentRepositoryMock.Setup(x => x.ProcessPaymentAsync(_cardNumber, _cvv, _expiryMonth, _expiryYear, _name,
                _amount, _currency, _merchantId, bankIdTransaction, true)).ReturnsAsync(expectedPayment);


            // Act
            var payment = await _paymentService.ProcessPaymentAsync(_cardNumber, _cvv,
                _expiryMonth, _expiryYear, _name, _amount, _currency,
                _merchantId);

            // Assert
            Assert.Same(expectedPayment, payment);

        }
    }

    

}
