using Azure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PatikaSipayDotNet6RestfulApi.Context;
using System.Runtime.ConstrainedExecution;

namespace PatikaSipayDotNet6RestfulApi.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T:class,new() //IRepository interface'ini inherit etmiş.
    {
        /// <summary>
        /// Generic Repository Design Pattern:
        /// Her model için bazı ortak işlemler vardır.Bu ortak işlemlere kısaca CRUD (Create, Read, Update, Delete) işlemler diyebiliriz.
        /// Modellerimiz farklı olsa da yaptığımız iş aslında aynı. 
        /// Projemizde modeller/nesneler arttıkça, bu ortak metotlar her bir model için ayrı ayrı uygulanmak zorunda. 
        /// Örneğin CreatePost ve CreateUser metotları aynı veritabanı sorgularını çalıştırıp aynı işlemi yapmakta, değişen tek parametre ise bu işlemi hangi model için yaptıkları. 
        /// Birisi bunu Post modeli için yaparken, diğeri User modeli için yapmakta.
        /// İşte bu kod tekrarına düşmemek adına, tüm modeller için kullanılabilir ortak bir yapı oluşturmalıyız.
        /// Generic Repository Pattern, “generic” kelimesinden de anlaşılacağı gibi bu“genel” yapıyı oluşturmamızı sağlıyor.
        /// Yani, ortak işlemlerimiz için genel bir yapı kurup, her bir modelin bu genel yapı üzerinden o işlemi gerçekleştirmesini sağlayacağız.
        /// Böylece, kod tekrarlarından kaçınırken, gelecekteki değişiklikler için efor sarfetmemizi gerektirmeyecek bir yapı oluşturmuş olacağız.
        /// programımızda asıl işi yapan bölümler ile veriye erişen bölümlerin birbirinden soyutlanması mantığını da sağlar.
        /// </summary>
      

        ApplicationDbContext _dbContext = new ApplicationDbContext();

        public GenericRepository(ApplicationDbContext dbContext) //ApplicationDbContext’i enjekt ettim
        {
            _dbContext = dbContext;
        }


        /// <summary>
        /// Generic(T)'ler tasarlandığımız interface, class, metod yada parametrelerin (argümanların) belirli bir tip için değil 
        /// bir şablon yapısına uyan her tip için çalışmasını sağlayan bir yapıdır.
        /// </summary>
        /// <returns></returns>

        public List<T> GetAllTList()
        {
            return _dbContext.Set<T>().ToList();
        }

        public void TAdd(T p)
        {
            _dbContext.Set<T>().Add(p);
            _dbContext.SaveChanges();
        }
        public void TUpdate(T p)
        {
            _dbContext.Set<T>().Update(p);
            _dbContext.SaveChanges();
        }
        public void TDelete(T p)
        {
            _dbContext.Set<T>().Remove(p);
            _dbContext.SaveChanges();
        }
        public T TGetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }
        

    }
}
