using dotnethelloworld.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

public class Startup
{

    public IConfigurationRoot Configuration { get; set; }

    public static string[] Arguments { get; set; }


    public Startup(IHostingEnvironment env)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .AddCommandLine(Arguments);

        Configuration = builder.Build();
    }

    
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();

        services.Configure<MyOptions>(x=> { x.MyKey = Configuration["MyKey"]; });
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
        Startup.Arguments = args;
        var config = new ConfigurationBuilder().AddCommandLine(args).Build();


        var host = new WebHostBuilder()
                    .UseKestrel()
                    .UseStartup<Startup>()
                    .UseConfiguration(config)
                    .Build();
        host.Run();
    }
}
