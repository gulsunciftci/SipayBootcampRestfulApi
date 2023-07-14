using Microsoft.EntityFrameworkCore.Migrations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PatikaSipayDotNet6RestfulApi.Models
{
    /// <summary>
    /// Model aslında bizim veritabanımızda yer alan tablolara karşılık gelen classlarımızdır.
    /// Yani veritabanı üzerindeki her bir tablo için biz uygulama tarafında model oluşturmalıyız. 
    /// Model classlarımızı da uygulamada model katmanında oluşturacağız. 
    /// </summary>
    public class Post //Burada post adında bir model oluşturdum. 
    {
        //[JsonIgnore]-->Swagger'da ıd'yi gizlemek için kullanılır.
        public int Id { get; set; } 
        [Required(ErrorMessage ="Please enter title.")] //Zorunlu alanların kontrolünü yaptım.
        public string Title { get; set; }

        [Required(ErrorMessage ="Please enter description")]
        public string Description { get; set; } //Property
        public DateTime CreatedDate { get; set; }


        ///<summary>
        ///Migration Nedir?
        ///İngilizcede kelime anlamı göç, yani şöyle düşünelim benim buradaki bilgilerim, kurallarım veritabanına göç ediyor.
        ///Migration 3 adımlı bir işlemdir.
        ///1) Öncelikle model oluşturdum. Oluşturduğum modelimi ApplicationDbContext'e DbSet olarak, bağlanacağımın veritabanının isminide appsettings.json dosyasına ekledim.
        ///2) Daha sonra migration ekleme işlemi yaptım. Bu işlemi database tarafına değişiklik yapmak için yaparız.(nuget package console'a PM > Add-Migration Initial yazarız.)
        ///3) Migration uygulamamıza bir isimle eklenince, henüz işlem database yansıdı demek değildir bunu database’e yansıtabilmek için migration’u database’e push etmemiz gerekir.
        ///(nuget package console'a PM > Update-Database yazarız.)
        /// </summary>

    }
}
