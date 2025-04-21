using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace AZ_Gateway;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
        builder.Services.AddOcelot(builder.Configuration);

        builder.Services.AddControllers();
        builder.Services.AddAuthorization();


        var app = builder.Build();

        // Configure the HTTP request pipeline.

        app.UseHttpsRedirection();

        app.UseAuthorization();
        app.MapControllers();

        app.UseOcelot();
        app.Run();
    }
}

