
using databasTest.Models;
using Microsoft.EntityFrameworkCore;
namespace databasTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<SalesQueryRepository>();
            builder.Services.AddScoped<SalesQueryService>();
            var connectionString = builder.Configuration.GetConnectionString("Default");
            Console.WriteLine("EF Core connection string: " + connectionString);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}