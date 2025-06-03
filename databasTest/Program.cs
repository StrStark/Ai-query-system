
using databasTest.Models;
using Microsoft.Data.SqlClient;
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
            var sqlBuilder = new SqlConnectionStringBuilder
            {
                DataSource = "91.107.162.209,1433",
                InitialCatalog = "AdventureWorks2022",
                UserID = "sa",
                Password = "Mr5568###",
                Encrypt = false,
                TrustServerCertificate = true,
                IntegratedSecurity = false
            };

            builder.Services.AddDbContext<AdventureWorks2022Context>(options =>
                options.UseSqlServer(sqlBuilder.ConnectionString));
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