using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NoCast.App.Models;

namespace NoCast.App.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,
        ApplicationRole,
        Guid>
    {
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<AIContentRequest> AIContentRequests { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<PaymentGatewayLog> PaymentGatewayLogs { get; set; }
        public DbSet<ServiceExecution> ServiceExecutions { get; set; }
        public DbSet<ServiceRequest> ServiceRequests { get; set; }
        public DbSet<SocialAccount> SocialAccounts { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<WalletTransaction> WalletTransactions { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>()
            .HasOne(u => u.Wallet)
            .WithOne(w => w.User)
            .HasForeignKey<Wallet>(w => w.Id)
            .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<ChatMessage>(entity =>
            {
                entity.HasOne(m => m.Sender)
                    .WithMany()
                    .HasForeignKey(m => m.SenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(m => m.Receiver)
                    .WithMany()
                    .HasForeignKey(m => m.ReceiverId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasIndex(m => new { m.SenderId, m.ReceiverId });
            });
        }
    }
}
