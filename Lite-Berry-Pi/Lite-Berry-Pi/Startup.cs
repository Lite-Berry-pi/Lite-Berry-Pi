using Lite_Berry_Pi.Data;
using Lite_Berry_Pi.Models.Interfaces;
using Lite_Berry_Pi.Models.Interfaces.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Lite_Berry_Pi
{
  public class Startup
  {
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;

    }



    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<LiteBerryDbContext>(options =>
     {
       string connectionString = Configuration.GetConnectionString("DefaultConnection");
       options.UseSqlServer(connectionString);
     });

      services.AddTransient<IActivityLog, ActivityLogRepository>();
      services.AddTransient<IDesign, DesignRepository>();
      services.AddTransient<IUser, UserRepository>();

      services.AddMvc();

      services.AddControllers().AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
      );

      services.AddSwaggerGen(options =>
      {
        options.SwaggerDoc("v1", new OpenApiInfo()
        {
          Title = "LiteBerry",
          Version = "v1",
        });
      });
    }




    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseRouting();

      app.UseSwagger(options =>
     {
       options.RouteTemplate = "/api/{documentName}/swagger.json";
     });

      app.UseSwaggerUI(options =>
     {
       options.SwaggerEndpoint("/api/v1/swagger.json", "LiteBerry");
       options.RoutePrefix = "";
     });

      app.UseEndpoints(endpoints =>
      {

        {
          endpoints.MapControllers();
        }
      });

    }
  }
}
