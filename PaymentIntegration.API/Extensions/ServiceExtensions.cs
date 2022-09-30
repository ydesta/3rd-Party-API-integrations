using CUSTOR.PaymentIntegrationWithDerash.CORE.Interface;
using CUSTOR.PaymentIntegrationWithDerash.CORE.Repository;

namespace CUSTOR.PaymentIntegrationWithDerash.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {
            });
        }

        public static void ConfigureRepositoryManager(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<ITaxPayerGracePeriodRepository, TaxPayerGracePeriodRepository>();
            services.AddScoped<IHttpClientResponseMessageRepository, HttpClientResponseMessageRepository>();
        }
    }
}
