using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

public class Startup
{

    public IConfiguration Configuration { get; set; }


    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
    }

    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        loggerFactory.AddDebug();

        app.UseDefaultFiles();
        app.UseStaticFiles();

        app.UseMvc(x => x.MapRoute("default", "{controller=Home}/{action=Index}/{id?}"));
    }


    public static void Main(string[] args)
    {
        var config = new ConfigurationBuilder()
            .AddCommandLine(args)
            .Build();

        var host = new WebHostBuilder()
                    .UseKestrel()
                    .UseConfiguration(config)
                    .UseStartup<Startup>()
                    .Build();
        host.Run();
    }
}
