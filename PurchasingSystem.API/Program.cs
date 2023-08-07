using Application.Common;
using Application.Common.Exceptions;
using IoC;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Data;

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

            // exception handler
            app.UseExceptionHandler(a => a.Run(async context =>
            {
                var exception = context.Features
                    .Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerPathFeature>()
                    .Error;


                if (exception is BusinessException)
                    context.Response.StatusCode = StatusCodes.Status422UnprocessableEntity;

                var result = JsonConvert.SerializeObject(new { error = exception.Message });

                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(result);
            }));

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI( o => {
                    o.RoutePrefix = string.Empty;
                    o.SwaggerEndpoint("/swagger/v1/swagger.json", "Purchase System API V1");
                });
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