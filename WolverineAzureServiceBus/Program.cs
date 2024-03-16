using JasperFx.CodeGeneration;
using Wolverine;
using WolverineAzureServiceBus.Data;
using WolverineAzureServiceBus.Handlers;

namespace WolverineAzureServiceBus;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();
        
        // Add controllers
        builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Add the mock book respository
        builder.Services.AddSingleton<IBookRepository, BookRepository>();
        
        builder.Host.UseWolverine(opts =>
        {
            opts.ApplicationAssembly = typeof(Program).Assembly;
            Console.WriteLine(opts.DescribeHandlerMatch(typeof(CreateBookHandler)));
            Console.WriteLine(opts.DescribeHandlerMatch(typeof(BookQueryHandler)));
        });
        
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