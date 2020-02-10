CREATE TABLE Payment
(PaymentId UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
Name varchar(50) NOT NULL,
CardNumber varchar(20) NOT NULL,
Cvv varchar(5) NOT NULL,
ExpiryMonth varchar(5) NOT NULL,
ExpiryYear varchar(5) NOT NULL,
Currency varchar(20) NOT NULL,
Amount varchar(20) NOT NULL,
MerchantId UNIQUEIDENTIFIER NOT NULL,
IsStatusPaymentSuccessful bit NOT NULL,
BankIdTransaction UNIQUEIDENTIFIER NOT NULL);