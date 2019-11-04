using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PingPong.Models;

namespace PingPong
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {

      services.AddDbContext<PingPongContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

      services.AddDbContext<PingPongContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:pingpong"]));

      // CORS Policy to allow dev environtments across different port domains and allow all HHTP methods
      services.AddCors(o => o.AddPolicy("DevEnvironment", builder =>
      {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
      }));

      services.AddControllers().AddNewtonsoftJson();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseRouting();

      
      app.UseAuthorization();

      app.UseCors("DevEnvironment");

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
