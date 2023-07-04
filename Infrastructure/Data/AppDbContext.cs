using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Infrastructure.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) {}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // probar esto
            //foreach (var entity in modelBuilder.Model.GetEntityTypes())
            //{
            //    var type = entity.ClrType;
            //    if (typeof(BaseEntity).IsAssignableFrom(type))
            //    {
            //        modelBuilder.Entity(type.Name, b =>
            //        {
            //            b.HasKey(nameof(BaseEntity.Id));
            //        });
            //    }
            //}

            base.OnModelCreating(modelBuilder); 
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<MeasurementUnit> MeasurementUnits { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
    }
}
