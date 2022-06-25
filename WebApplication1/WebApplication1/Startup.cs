using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using WebApplication1.Controllers;
using WebApplication1.Services;

namespace WebApplication1;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.
            AddControllers()
            .AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.Formatting = Formatting.Indented;
        });
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApplication1", Version = "v1" });
        });

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddDbContext<DatabaseContext>(opt =>
        {
            opt.UseSqlServer(Configuration.GetConnectionString("BetServer"));
        });
        services.AddScoped<BetsService>();
        services.AddScoped<EventInformationService>();
        services.AddScoped<StatisticsService>();
        services.AddScoped<UpdateEventResultService>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        
            app.UseSwagger();
            app.UseSwaggerUI();
        

        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}