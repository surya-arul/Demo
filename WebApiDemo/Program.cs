using Microsoft.AspNetCore.Authentication.JwtBearer;
using WebApiDemo.Services;

namespace WebApiDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            // Add configuration for the external API base URL
            builder.Configuration.AddJsonFile("appsettings.json");

            // Add authentication services
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    // Configure JWT authentication options here
                    options.Authority = "your_auth_server_url";
                    options.Audience = "your_api_identifier";
                });


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add service for crud process
            builder.Services.AddTransient<UserService, UserService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}