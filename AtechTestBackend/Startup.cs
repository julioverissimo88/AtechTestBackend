using AtechTestBackend.Domain.Models;
using AtechTestBackend.infrastructure.Data.Context;
using AtechTestBackend.infrastructure.Data.Repository;
using AtechTestBackend.infrastructure.Service;
using AtechTestBackend.infrastructure.Validators;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;


namespace AtechTestBackend
{
    public class Startup
    {
        private readonly string systemName = "Julio Atech Teste";
        private readonly string systemVersion = "v1";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string strConn = Configuration.GetValue<string>("ConnectionStrings:DatabaseConn");
            services.AddDbContext<ContextApp>(options => options.UseSqlServer(strConn));

            services.AddScoped<PessoaRepository>();
            services.AddScoped<PessoaService>();

            services.AddMvc().AddFluentValidation();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(systemVersion, new OpenApiInfo { Title = systemName, Version = systemVersion });
            });

            services.AddAutoMapper(config =>
            {
                config.AllowNullCollections = true;
            }, typeof(Startup));

            services.AddTransient<IValidator<Pessoa>, PessoaValidator>();
            services.AddControllers();
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


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", systemName);
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
