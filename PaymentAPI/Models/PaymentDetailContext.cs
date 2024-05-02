using Microsoft.EntityFrameworkCore;

namespace PaymentAPI.Models
{
    public class PaymentDetailContext : DbContext
    {
        public PaymentDetailContext(DbContextOptions options): base(options)
        {
        }

        public DbSet<PaymentDetail> PaymentDetails { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users");
        }
    }
}
