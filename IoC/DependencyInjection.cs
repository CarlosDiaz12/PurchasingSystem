using Application.Articles.Interfaces;
using Application.Articles.Services;
using Application.Brands.Interfaces;
using Application.Brands.Services;
using Application.Departments.Interface;
using Application.Departments.Services;
using Application.MeasurementUnits.Interface;
using Application.MeasurementUnits.Services;
using Application.PurchaseOrders.Interfaces;
using Application.PurchaseOrders.Services;
using Application.Repositories;
using Application.Suppliers.Interfaces;
using Application.Suppliers.Services;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            // db context
            var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            services.AddDbContext<AppDbContext>(db => db.UseSqlServer(connectionString));
            // generic dependencies
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            // services
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<IMeasurementUnitService, MeasurementUnitService>();
            services.AddScoped<IPurchaseOrderService, PurchaseOrderService>();
            services.AddScoped<ISupplierService, SupplierService>();
            // repository
            return services;
        }
    }
}
