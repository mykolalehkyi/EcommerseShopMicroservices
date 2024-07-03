using Ordering.API;
using Ordering.Application;
using Ordering.Infrastructure;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services
            .AddApplicationServices()
            .AddInfrastructureServices(builder.Configuration)
            .AddApiServices();

        var app = builder.Build();

        app.Run();
    }
}