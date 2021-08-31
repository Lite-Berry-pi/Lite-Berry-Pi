using Lite_Berry_Pi.Data;
using Lite_Berry_Pi.Models;
using Lite_Berry_Pi.Models.Interfaces;
using Lite_Berry_Pi.Models.Interfaces.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
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
    bool addSwag = false;
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;

    }



    public void ConfigureServices(IServiceCollection services)
    {
      services.AddAuthentication(options =>
      {
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      })
      .AddJwtBearer(options =>
        {
          options.TokenValidationParameters = JwtTokenService.GetValidationParameters(Configuration);
        });

      services.AddAuthorization(options =>
      {
        options.AddPolicy("create", policy => policy.RequireClaim("permissions", "create"));
        options.AddPolicy("update", policy => policy.RequireClaim("permissions", "update"));
        options.AddPolicy("delete", policy => policy.RequireClaim("permissions", "delete"));
        options.AddPolicy("read", policy => policy.RequireClaim("permissions", "read"));
        options.AddPolicy("send", policy => policy.RequireClaim("permissions", "send"));
      });

      services.AddDbContext<LiteBerryDbContext>(options =>
     {
       //Appsetting.json entry
       //string connectionString = Configuration.GetConnectionString("DefaultConnection");
       string connectionString = Configuration.GetConnectionString("ProductionConnection");
       options.UseSqlServer(connectionString);
     });

      //We are not using email so do we need this
      services.AddIdentity<ApplicationUser, IdentityRole>(options =>
      {
        options.User.RequireUniqueEmail = false;

      })
      .AddEntityFrameworkStores<LiteBerryDbContext>();

      services.AddTransient<IUserService, IdentityUserService>();

      services.AddTransient<IActivityLog, ActivityLogRepository>();
      services.AddTransient<IDesign, DesignRepository>();
      services.AddTransient<IUser, UserRepository>();

      services.AddSignalR()
         .AddAzureSignalR();

      services.AddMvc();

      services.AddScoped<JwtTokenService>();

      services.AddControllers().AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
      );
      if (addSwag)
      {
        services.AddSwaggerGen(options =>
        {
          options.SwaggerDoc("v1", new OpenApiInfo()
          {
            Title = "LiteBerry",
            Version = "v1",
          });
        });
      }
      else
      {
        services.AddSpaStaticFiles(configuration =>
        {
          configuration.RootPath = "ClientApp/build";
        });
      }
    }




    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {


      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseRouting();

      app.UseAuthentication();
      app.UseAuthorization();


      app.UseFileServer();

      if (addSwag)
      {
        app.UseSwagger(options =>
       {
         options.RouteTemplate = "/api/{documentName}/swagger.json";
       });

        app.UseSwaggerUI(options =>
       {
         options.SwaggerEndpoint("/api/v1/swagger.json", "LiteBerry");
         options.RoutePrefix = string.Empty;
       });
      }
      else
      {
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseSpaStaticFiles();
      }
      app.UseEndpoints(endpoints =>
      {
        {
          endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "/api/{controller}/{action=Index}/{id?}");
        }
      });
      app.UseSpa(spa =>
      {
        spa.Options.SourcePath = "ClientApp";

        if (env.IsDevelopment())
        {
          spa.UseReactDevelopmentServer(npmScript: "start");
        }
      });
    }
  }
}
