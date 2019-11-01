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

    //readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {

      services.AddDbContext<PingPongContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

      services.AddDbContext<PingPongContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:pingpong"]));

      //services.AddCors(options =>
      //{
      //  options.AddPolicy(MyAllowSpecificOrigins,
      //  builder =>
      //  {
      //    builder.WithOrigins("http://localhost:4200",
      //                            "http://localhost:5000")
      //                        .AllowAnyOrigin()
      //                        .AllowAnyMethod()
      //                        .AllowAnyHeader();

      //  });
      //});
      services.AddControllers().AddNewtonsoftJson();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      //app.UseCors();

      app.UseAuthorization();

      //app.UseCors(MyAllowSpecificOrigins);

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });

      //app.UseCors(builder =>
      //      builder.WithOrigins("http://localhost:4200", "http://localhost:5000")
      //          .AllowAnyHeader()
       //         .AllowAnyMethod());

      // Add header:
      //app.Use((context, next) =>
      //{
      //  context.Response.Headers["Access-Control-Allow-Origin"] = "*";
      //  return next.Invoke();
      //});

     
    }
  }
}
