using AppCoreStudy.Presentation.Profiles;
using AppCoreStudy.Repository;
using AppCoreStudy.Services;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace AppCoreStudy.Presentation
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
            //Mapear repository de produto
            //Injeção de dependencia
            //services.AddTransient<IProdutoService>();
            services.AddTransient(typeof(IProdutoService), typeof(ProdutoService));
            services.AddTransient<ProdutoRepository>();
            //services.AddTransient<ProdutoRepository>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //registrando a classe DomainProfile do AutoMapper
            Mapper.Initialize(z => z.AddProfile<DomainProfile>());

            //Registrando o Swagger
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Info
                {
                    Title = "Projeto Asp.Net Core Web Api",
                    Version = "V1",
                    Description = "Aula de C# WebDeveloper - COTI Informática",
                    Contact = new Contact
                    {
                        Name = "Nelson Neto",
                        Email = "nelson.ash@outlook.com",
                        Url = "http://cotiinformatica.com.br"
                    }
                });
            });


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

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "projetoAspNetCore Web Api");
            });
        }
    }
}
