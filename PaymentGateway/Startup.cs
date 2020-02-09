using AutoMapper;
using BankService;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PaymentGatewayRepository;
using PaymentGatewayRepository.Operations;
using PaymentGatewayService;

namespace PaymentGateway
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Here we add dbcontext to startup service configuration
            services.AddDbContext<PaymentDbContext>(opts =>
                opts.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<PaymentDbContext>();

            // ADD Mediator DI
            services.AddMediatR(typeof(Startup));

            // Add AutoMapper DI
            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IAcquiringBankService, AcquiringBankService>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
