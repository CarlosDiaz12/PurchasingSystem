using Application.Common;
using IoC;
namespace PurchasingSystem.API
{
    public class Program
    {
        private const string _corsPolicyName = "DefaultPolicy";
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDependencyInjection(builder.Configuration);

            // http client
            builder.Services.AddHttpClient(Constants.ACCOUNTING_CLIENT_KEY, c =>
            {
                c.BaseAddress = new Uri(builder.Configuration["AccountingService:APIUrl"]);
            });

            //cors
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(_corsPolicyName,
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                    });
            });
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(_corsPolicyName);
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors();

            app.MapControllers();

            app.Run();
        }
    }
}