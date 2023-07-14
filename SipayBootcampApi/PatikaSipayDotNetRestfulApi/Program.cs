using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace PatikaSipayDotNet6RestfulApi
{
    // Bir dotnet uygulamas� aya�a kalkt���nda ilk olarak Program.cs �al���r.(�lk initialization etti�i yerdir.)
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run(); 
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>    //Host aya�a kald�r�l�yor. 
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();  //Host i�in startup config'i kullanmas�n� s�yl�yor. Web uygulamal�r�n� standart olarak kulland��� y�ntemdir.
                    //Console uygulamas� �zerinden bir port �zerinden �al��an uygulama aya�a kalk�yor. Browser'da �al��an bir web uygulamas� geli�tiriliyor.
                    //Browser'da swagger(Api dok�mantasyon arac�) arac�l���yla kodlar yorumlanarak bir dokumantasyon sayfas� olu�turuluyor.
                });

    
        /// <summary> 
        ///
        ///Swagger UI:
        ///Bir .net core web api projesi yaratt���m�zda proje i�erisine varsay�lan(Default) olarak swagger ui eklentisi eklenmi� olarak gelir.
        ///Swagger UI, olu�turdu�umuz API'lar ile ilgili bilgileri g�rselle�tirmemiz ve otomatik d�k�mantasyon olu�turabilmemize yarayan yard�mc� bir aray�zd�r.
        ///Bu aray�z sayesinde web api projemizde hangi resource'lara sahip oldu�umuzu ve bu resourcelarla ilgili hangi eylemleri yapabilece�imizle ilgili bir d�k�mantasyon olu�turmu� oluruz.
        ///Bu sayede hem ekip i�indeki, hem de API'mizi kullanacak di�er geli�tirici arkada�lar�n bilgi sahibi olmas�n� sa�lam�� oluruz.

        ///Swagger UI i�erisinde bir eylemle ilgili olarak temel iki �e�it bilgi bulunur:
        ///1) Parameters : Http Put ve Http Post �a�r�mlar�n�n bekledi�i parametreleri g�rd���m�z yerdir.
        ///2) Responses : Http talebine kar��l�k olarak nas�l bir HTTP response'u olu�turabilece�ini, response i�erisinde hangi tipte bir data d�nece�ini detayl� olarak g�rebiliriz.
        ///****** Swagger UI arac�l��� ile eylemlerin bekledi�i parametreleri kolay bir �ekilde doldurarak �rnek �a�r�mlar yapabilir, d�nen cevaplar� g�zlemleyebiliriz.
        /// 
        /// </summary>


    }
}
