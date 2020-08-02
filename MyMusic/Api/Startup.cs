using Core;
using Core.Services;
using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Services;
using Swashbuckle.AspNetCore.Swagger;

namespace Api
{
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
            services.AddControllers();
            
            // dependency injection, scoped injection -> objects are same through the request
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // dependency injection, transient injection -> new objects are for each controller and each request
            services.AddTransient<IMusicService, MusicService>();
            services.AddTransient<IArtistService, ArtistService>();

            services
                .AddDbContext<MyMusicDbContext>(options => options
                    .UseSqlServer(Configuration
                        .GetConnectionString("Default"), 
                        x => x.MigrationsAssembly("Data")
                    )                
                );

            services.AddSwaggerGen(options => 
                {
                    options.SwaggerDoc("v1", new OpenApiInfo 
                        { 
                            Title = "My Music",
                            Version = "v1"
                        }
                    );
                }
            );
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
            app.UseSwagger();

            app.UseSwaggerUI(c =>
                {
                    c.RoutePrefix = "";
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Music V1");
                }
            );
        }
    }
}
