using Microsoft.EntityFrameworkCore;
using PatikaSipayDotNet6RestfulApi.Models;
using System.Collections.Generic;

namespace PatikaSipayDotNet6RestfulApi.Context
{
    public class ApplicationDbContext:DbContext //Entity framework core,tools,design ve server paketlerini indirdim.
    {
        /// <summary>
        /// Öncelikle DbContext sınıfını kullanabilmek için “Microsoft.EntityFrameworkCore” pakedini projeme dahil ettim.
        /// Startup.cs tarafında ConfigureServices metodunda DbContext’imi servis konteynerine ekledim.
        /// DatabaseConnection adlı ConnectionString’imi appsettings.json’da tanımladım.
        /// </summary>
        public ApplicationDbContext()
        {
        }

        /// <summary>
        /// DBContext:
        /// Veritabanına karşılık gelen obje yapısıdır.İçinde tablo yapısına karşılık gelen DbSet objelerini bulundurur.
        /// DbContext kullanarak tablo ve view yapılarına erişebilir, DbSet yapısını kullanarak tablo üzerinde CRUD işlemlerini gerçekleştirebilirsiniz.
        /// </summary>

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options): base(options)
        {
               
        } 


        public DbSet<Post> Posts { get; set; } //Tablo yapısına karşılık gelen dbset objesini oluşturdum.
    }
}
