using Business.Interfaces;
using Business.Negocio;
using DesafioAeC.Dominio.Interfaces.Repositorios;
using DesafioAeC.Dominio.Interfaces.Servicos;
using DesafioAeC.Dominio.Servicos;
using DesafioAeC.Infra.Data.Contexto;
using DesafioAeC.Infra.Data.Repositories;
using DesafioAeC.Web.AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace DesafioAeC.Web
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
            services.AddControllersWithViews();

            // Configuração do AutoMapper
            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddScoped<AutoMapperProfile>();
            // Configuração do DbContext
            services.AddDbContext<DesafioAeCContexto>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DesafioAeCContext")));

            services.AddScoped<IEnderecoRepositorio, EnderecoRepositorio>();
            services.AddScoped<IEnderecoService, EnderecoServico>();
            services.AddScoped<IEnderecoNegocio, EnderecoNegocio>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
