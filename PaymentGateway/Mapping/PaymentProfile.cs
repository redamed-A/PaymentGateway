using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PaymentGateway.Responses;
using PaymentGatewayModel;

namespace PaymentGateway.Mapping
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<Payment, PaymentDetailsResponse>();
            CreateMap<Payment, PaymentTransactionResponse>();
        }
    }
}
