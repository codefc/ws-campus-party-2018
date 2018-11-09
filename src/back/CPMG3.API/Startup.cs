using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using CPMG3.API.Extensions;

namespace CPMG3.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Configuração do Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(ApplicationConstants.Documentation.API_CURRENT_VERSION, new Info 
                    { 
                        Title = ApplicationConstants.Documentation.API_NAME, 
                        Version = ApplicationConstants.Documentation.API_CURRENT_VERSION,
                        Description = ApplicationConstants.Documentation.API_DESCRIPTION,
                        TermsOfService = "None",
                        Contact = new Contact
                        {
                            Name = ApplicationConstants.Documentation.API_CONTACT_NAME,
                            Email = ApplicationConstants.Documentation.API_CONTACT_EMAIL,
                            Url = "http://www.codefc.com.br"
                        }
                });


                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            // Adicionando Factory do Refit
            services.AddRefit();

            // Adicionando ConfigCat para Feature Toggle
            services.AddConfigCat(Configuration.GetValue<string>("ConfigCatKey"));
        }

       
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            // Configurações do Swagger
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", ApplicationConstants.Documentation.API_NAME);
                c.RoutePrefix = string.Empty;
            });
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
