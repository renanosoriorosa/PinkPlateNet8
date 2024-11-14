using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PinkPlate.Domain.Produto.Models;

namespace PinkPlate.Infrastructure.Context
{
    public class RNContext : IdentityDbContext
    {
        public RNContext(DbContextOptions<RNContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Produto> Produto { get; set; }
    }
}
