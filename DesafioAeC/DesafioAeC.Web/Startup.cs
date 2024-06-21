using DesafioAeC.Business.Interfaces;
using DesafioAeC.Business.Negocio;
using DesafioAeC.Dominio.Interfaces.Repositorios;
using DesafioAeC.Dominio.Interfaces.Servicos;
using DesafioAeC.Dominio.Servicos;
using DesafioAeC.Infra.Data.Contexto;
using DesafioAeC.Infra.Data.Repositories;
using DesafioAeC.Integracoes.ViaCEP;
using DesafioAeC.Web.AutoMapper;
using DesafioAeC.Web.Util;
using DesafioAeC.Web.Util.Interface;
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

            //DI AutoMapper
            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddScoped<AutoMapperProfile>();
            //DI DbContext
            services.AddDbContext<DesafioAeCContexto>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DesafioAeCContext")));

            //DI fluxo Endereço
            services.AddScoped<IEnderecoRepositorio, EnderecoRepositorio>();
            services.AddScoped<IEnderecoService, EnderecoServico>();
            services.AddScoped<IEnderecoNegocio, EnderecoNegocio>();

            //DI fluxo usuário
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddScoped<IUsuarioService, UsuarioServico>();
            services.AddScoped<IUsuarioNegocio, UsuarioNegocio>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ISessao, Sessao>();
            services.AddSession(x =>
            {
                x.Cookie.HttpOnly = true;
                x.Cookie.IsEssential = true;
            });

            //DI integração ViaCEP
            var urlBase = Configuration["ViaCepUrlBase"];
            services.AddHttpClient<IViaCepClient, ViaCepClient>(x =>
            {
                x.BaseAddress = new Uri("https://viacep.com.br/ws/");
                x.DefaultRequestHeaders.Add("Accept", "application/json");
                x.Timeout = new TimeSpan(0, 0, 50);
            });
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

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}
