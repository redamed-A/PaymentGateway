using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PaymentGatewayModel;

namespace PaymentGatewayRepository
{
    public class PaymentDbContext: DbContext
    {
        public DbSet<Payment> Payment { get; set; }
        public PaymentDbContext(DbContextOptions<PaymentDbContext> options) : base(options)
        {
            
        }

    }
}
