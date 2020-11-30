using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Persistence;
using Microsoft.EntityFrameworkCore;
using Service;

namespace SolicitudPermisos
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
            var connection = Configuration.GetConnectionString("Dev");
            services.AddDbContext<PermisoDbContext>(options => options.UseSqlServer(connection));

            services.AddTransient<IPermisoService, PermisoService>();
            services.AddTransient<ITipoPermisoService, TipoPermisoService>();

            //services.AddControllers();
            // connect vue app - middleware  
            services.AddSpaStaticFiles(options => options.RootPath = "frontend");
            services.AddCors();
            /*  services.AddCors(options =>
              {
                  options.AddPolicy("AllowSpecificOrigin", builder =>
                      builder.AllowAnyHeader()
                             .AllowAnyMethod()
                             .AllowAnyOrigin()
                  );
              });*/
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }       

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
