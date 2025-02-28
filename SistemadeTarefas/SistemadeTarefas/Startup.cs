using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SistemadeTarefas.Data;
using SistemadeTarefas.Repositories;
using SistemadeTarefas.Repositories.Interfaces;

namespace SistemadeTarefas
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // M�todo para configurar os servi�os da aplica��o
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Configurando o Entity Framework com SQL Server
            services.AddDbContext<SistemaTarefasDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Database")));

            // Inje��o de Depend�ncia dos Reposit�rios
            services.AddScoped<InterfaceUsuarioRepositorio, UsuarioRepositorio>();

            // Configura��o do Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SistemadeTarefas", Version = "v1" });
            });
        }

        // M�todo para configurar o pipeline de requisi��es HTTP
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SistemadeTarefas v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
