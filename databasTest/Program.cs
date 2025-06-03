
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
            builder.Services.AddDbContext<AdventureWorks2022Context>(options =>
                options.UseSqlServer("Server=91.107.162.209,1433;Database=AdventureWorks2022;User Id=sa;Password=Mr5568###;TrustServerCertificate=true;Encrypt=false;"));
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