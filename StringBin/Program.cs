using Microsoft.EntityFrameworkCore;
using StringBin.Repository;

namespace StringBin;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddControllers();

        builder.Services.AddDbContext<StringBinDbContext>(options =>
        {
            options.UseInMemoryDatabase("InMemoryDb");
        }, ServiceLifetime.Singleton, ServiceLifetime.Singleton);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseRouting();
        app.MapControllers();

        app.UseAuthorization();

        app.Run();
    }
}