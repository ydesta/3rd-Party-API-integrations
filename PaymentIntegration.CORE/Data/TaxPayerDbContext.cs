using CUSTOR.PaymentIntegrationWithDerash.CORE.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUSTOR.PaymentIntegrationWithDerash.CORE
{
    public class TaxPayerDbContext : DbContext
    {
        public TaxPayerDbContext(DbContextOptions<TaxPayerDbContext> options):base(options)
        {

        }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<PaymentDetail> PaymentDetail { get; set; }
        public DbSet<TaxPayerGracePeriod> TaxPayerGracePeriod { get; set; }
        public DbSet<PaymentViewModel> PaymentViewModel { get; set; }
        public DbSet<HttpClientResponseMessage> HttpClientResponseMessage { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
       .Entity<PaymentViewModel>(
           eb =>
           {
               eb.HasNoKey();
               eb.Property(x => x.Tin).IsRequired(false);
               eb.Property(x => x.OrderNo).IsRequired(false);
              // eb.Property(x => x.TotalPayment).IsRequired(false);
               eb.Property(x => x.TeleNo).IsRequired(false);
               eb.Property(x => x.BusinessNameAmh).IsRequired(false);
           });

        }

        }
}
