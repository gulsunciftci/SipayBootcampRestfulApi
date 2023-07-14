using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PatikaSipayDotNet6RestfulApi.Context;
using PatikaSipayDotNet6RestfulApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatikaSipayDotNet6RestfulApi
{
    /// <summary>
    /// net6.0 i�erisinde startup.cs yok. �u anda net6.0 kullan�yoruz startup.cs ve program.cs dosyalar�n� oradan kopyalad�k.
    /// uygulamam�z i�in gerekli ayarlar� yapabilmemiz i�in Startup.cs dosyas�ndaki Startup class'� varsay�lan ayarlar ile kurulu olarak olu�turulur.
    /// Bu class i�erisindeki ayarlar ile uygulamam�z�n nas�l davranaca��n�, hangi bile�enleri kullanaca��n� belirtmi� oluruz.
    /// uygulama i�erisinde kullan�lacak konfigurasyon dosyas� Startup.cs dir.
    /// Startup.cs i�erisinde 2 adet temel metot bulunur. Bu metotlar arac�l��� ile uygulamam�z�n ayarlar�n� olu�tururuz.
    /// </summary>

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        ///
        /// Bu metot arac�l��� ile uygulamam�z�n i�erisinde kullanaca��m�z bile�enlerin ayarlar�n� yapabiliriz. 
        /// ConfigureServices metodu i�erisinde uygulaman�n kullanaca�� servisler ve Dependency Injection'lar(DI) eklenir ve konfig�re edilir.
        /// Servisleriyse belli bir i�i yapmaktan sorumlu kod par�alar�, s�n�flar yada k�t�phaneler gibi d���nebilirsiniz. K�saca onlara bile�enler de diyebiliriz.
        /// </summary>

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddControllers().AddNewtonsoftJson();
            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApplication1", Version = "v1" });
            });
        }

        /// <summary>
        /// 
        /// Bu metot uygulamam�za gelen HTTP isteklerini hangi a�amalardan ge�irerek bir HTTP cevab� olu�turaca��m�z� belirtti�imiz metottur. 
        /// Startup i�erisinde bu metodun doldurulmas� ve do�ru ayarlarlanmas� gereklidir.
        /// Middleware'ler kullan�larak uygulama i�erisinde bir pipeline olu�turulur. ��te bu pipeline configure() dosyas� i�erisinde belirlenir.
        /// </summary>

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication1 v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
     
    }
}
