using Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // probar esto
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                var type = entity.ClrType;
                var x = typeof(BaseEntity).CustomAttributes.ToList();
                if (typeof(BaseEntity).IsAssignableFrom(type))
                {
                    modelBuilder.Entity(type.Name, b =>
                    {
                        b.HasKey(typeof(BaseEntity).CustomAttributes.First().GetType().Name);
                    });
                }
            }

            base.OnModelCreating(modelBuilder); 
        }
    }
}
