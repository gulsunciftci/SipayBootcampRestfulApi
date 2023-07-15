# Asp .Net Core Web Api .Net 6.0 ile Restful Api Geliştirme 👩‍💻

Merhaba, bu projede bir Restful Api geliştirdim. Projemden bahsetmeden önce gelin birlikte bazı terimlerin anlamlarına ve nerelerde kullanıldıklarına bakalım. 

## API (Application Programming Interface) Nedir :

* En basitleştirilmiş tanımıyla API; Bir kod bölümünün başka bir kod bölümüyle iletişime geçmesidir.(Genel olarak iki yazılımın birbiriyle iletişime geçmesidir.)
* Bir yazılımın gerçekleştirebildiği işlemlere belirli koşullar dahilinde dışarıdan erişilip bu işlemlerin kullanılmasını sağlayan arayüzdür.
* API'ların kullanımında kendi yazdığımız uygulamalar ile kullandığımız API'lar farklı programlama dillerine sahip olabilirler 
* Ayrıca API'lar platform bağımsız çalışırlar.
* Özetle, bir uygulamada gerçekleştirmek istediğimiz ek bir işlemi, o işlemi sağlayan başka bir uygulamadan API kullanarak gerçekleştirebiliriz.

## Neden API Kullanırız?

* API kullanımı bizi ilgili işlemin gerektireceği iş yükünden kurtarır. “API hayatı kolaylaştırır”.
* API lar özel kullanıcı kitlelerine yönelik hazırlanırlar ve ilgili verileri hızlı bir şekilde oluşturmamızı sağlarlar. ( IMDB API, GitHub API ..)
* Platform bağımsız çalışırlar.
* Güncelleme durumunda bizim yapmamız gereken işlemler sınırlıdır.


![API](https://upload.wikimedia.org/wikipedia/commons/3/36/Web_API.png)

## REST API Nedir?

* Representational state transfer; İlgili isteğe karşılık gelen verinin JSON / XML gibi dosya formatlarında gönderilmesidir. 
* REST API, REST mimarisinin prensiplerine taşıyan API’lardır. Tüm prensiplerin karşılanması durumunda RESTful API olarak da adlandırılır.
* Özetle, bir uygulamada gerçekleştirmek istediğimiz ek bir işlemi, o işlemi sağlayan başka bir uygulamadan API kullanarak gerçekleştirebiliriz.


<img src="https://upload.wikimedia.org/wikipedia/commons/f/f1/Rest-API.png" alt="alt text" width="320" height="180">

## API Kulanımının Avantajları

* Platform bağımsız olmaları
* Verimliliği arttırmaları
* İlgili verilere kolay ulaşım
* İş yükünün azalması

## Postman Kullanımı:
* Postman bir API platformudur. 
* API geliştirmek , test etmek ve/veya hazır bir API kullanımı için gerekli isteklerde bulunabileceğimiz bir uygulamadır. 
* Insomnia REST Client, HTTPie gibi alternatifleri de bulunmasına karşın en çok kullanılan API aracıdır.

## Postman Kullanım Senaryoları:
* Bir uygulama geliştirmek istiyoruz ve geliştirmeye başlamada kullanmak istediğimiz ücretli veya ücretsiz bir REST API tarafına ilgili istekleri göndererek gelen sunumları inceleyebiliriz.

## Swagger UI Nedir ?
* Swagger UI, oluşturduğumuz API'lar ile ilgili bilgileri görselleştirmemiz ve otomatik dökümantasyon oluşturabilmemize yarayan yardımcı bir arayüzdür. 
* Bu arayüz sayesinde web api projemizde hangi resource'lara sahip olduğumuzu ve bu resourcelarla ilgili hangi eylemleri yapabileceğimizle ilgili bir dökümantasyon oluşturmuş oluruz. 
* Bu sayede hem ekip içindeki, hem de API'mizi kullanacak diğer geliştirici arkadaşların bilgi sahibi olmasını sağlamış oluruz.
* Bir .net core web api projesi yarattığımızda proje içerisine varsayılan olarak swagger ui eklentisi eklenmiş olarak gelir.

## Swagger UI içerisinde bir eylemle ilgili olarak temel iki çeşit bilgi bulunur.

1) Parameters : Http Put ve Http Post çağrımlarının beklediği parametreleri gördüğümüz yerdir.
2) Responses : Http talebine karşılık olarak nasıl bir HTTP response'u oluşturabileceğini, response içerisinde hangi tipte bir data döneceğini detaylı olarak görebiliriz.

* Swagger UI aracılığı ile eylemlerin beklediği parametreleri kolay bir şekilde doldurarak örnek çağrımlar yapabilir, dönen cevapları gözlemleyebiliriz.

## HTTP Metotları
1) GET:  Verileri almak - listelemek için kullanılan istek metodudur.
2) POST: Belirli bir kaynağa veri göndermek için kullanılır.
3) PUT:  Belirli bir kaynaktaki verinin tamamının değiştirilmesi için kullanılan metodtur.
4) PATCH: Belirli bir kaynaktaki verilerin bir kısmının değiştirilmesi için kullanılan metodtur.
5) DELETE: Belirli bir kaynaktaki verilerin silinmesi için kullanılan metodtur.

# Bu proje kapsamında Geliştirdiğim Restful Api'nin özellikleri şu şekildedir:

* Rest standartlarına uygun.
* GET,POST,PUT,DELETE,PATCH methodlarını(Crud işlemleri) içeriyor.
* Http status code standartlarına uygun. 
* Error Handler ile 500, 400, 404, 200, 201 hatalarını standart format ile veriyor.
! Modellerde zorunlu alanların kontrolü yapılmış.
* Routing kullanıldı.
* Model binding işlemleri hem body den hemde query den yapılacak şekilde örneklendirilmiş durumda.
* Standart crud işlemlerine ek olarak, listeleme ve sıralama işlevlerini içeriyor.

# Restful Api Geliştirirken Kullandığım Teknolojiler:

* .Net Core
* C# dili
* Entity Framework Core
* Repository Design Pattern
  

# Aşamalar:

1) Model Oluşturma

İlk olarak Model katmanında Post isminde modelimi oluşturdum. Daha sonra Modelime ona özgü property'leri ekledim. Model aslında bizim veritabanımızda yer alan tablolara karşılık gelen classlarımızdır.Yani veritabanı üzerindeki her bir tablo için biz uygulama tarafında model oluşturmalıyız. 


📁 [Post.cs](https://github.com/gulsunciftci/SipayBootcampRestfulApi/blob/main/SipayBootcampApi/PatikaSipayDotNetRestfulApi/Models/Post.cs)

2) DbContext Oluşturma

* Model oluşturduktan sonra Context katmanına projede kullanacağım DbContext’i ekledim. DBContext, Veritabanına karşılık gelen obje yapısıdır.İçinde tablo yapısına karşılık gelen DbSet objelerini bulundurur. DbContext kullanarak tablo ve view yapılarına erişebilir, DbSet yapısını kullanarak tablo üzerinde CRUD işlemlerini gerçekleştirebiliriz. 
* DBContext içerisine Modelimi DbSet olarak ekledim. DbContext sınıfını kullanabilmek için “Microsoft.EntityFrameworkCore” paketini projeye dahil etmek gerekiyor, paketi projeye dahil ettim. Bu işlemide yaptıktan sonra Startup.cs tarafında ConfigureServices metodunda DbContext’i servis konteynerine ekledim. Aynı zamanda DatabaseConnection adlı ConnectionString’i appsettings.json’da tanımlamakta gerekiyor. Bu aşamadan sonra DbContext’im hazır, migration işlemlerini uygulamaya başladım.

📁 [ApplicationDbContext.cs](https://github.com/gulsunciftci/SipayBootcampRestfulApi/blob/main/SipayBootcampApi/PatikaSipayDotNetRestfulApi/Context/ApplicationDbContext.cs)

3) Migration İşlemleri

Visual Studio Tools kısmından Package Manager Console'u açtım. 
* Console'a 'PM > Add-Migration Initial' yazarak Migration ekleme işlemini yaptım. Bu işlemi database tarafına değişiklik yapmak için yaparız.
* Migration uygulamamıza "Initial" ismiyle eklenince, henüz işlem database yansıdı demek değildir bunu database’e yansıtabilmek için migration’ı database’e push etmemiz gerekir bunun için console'a 'PM > Update-Database' komutunu yazdım. Bu işlemleri sırayla yapıp tamamladıktan sonra veritabanım ve tablom kullanıma hazır bir hale geldi.

```
PM> add-migration initial
```

```
PM > Update-Database
```

4) Generic Repository Oluşturma

* Repository kalıbı her modelin ortak olarak ihtiyaç duyduğu metotları kapsayacak şekilde oluşturulmalıdır. GenericRepository sınıfını miras alması için kullanacağım ve sadece bu ortak metotları içeren IRepository ismindeki arayüzümü oluşturmakla başladım. Interface'de farkedilecek ilk şey generic T tipidir. Bu aslında bizim için şu an veritabanındaki tablolara karşılık gelmektedir(Post...). Örneğin, T değerini Post olarak gönderdiğimde CRUD işlemlerini Post modeline göre çalıştıracağım demektir.
* Arayüzümü oluşturduktan sonra GenericRepository classımı bu arayüzden miras alarak oluşturmaya başladım. DbContext’i enjekte etmek için Constructur injection kullanarak, yapıcı metoda(Constructor) parametre olarak geçirdim. Daha sonra veri tabanına bağlanarak asıl kodlarımı yazmaya başladım.GenericRepository'den DbContext içerisinde tanımladığımı DbSet<Post> nesnesine erişmek için _dbContext.Set<T>() gibi bir metot kullandım.Bu GenericRepository’i Post için implemente ettiğimde bütün işlemleri otomatik olarak o modele göre yaptı. 


📁 [GenericRepository.cs](https://github.com/gulsunciftci/SipayBootcampRestfulApi/blob/main/SipayBootcampApi/PatikaSipayDotNetRestfulApi/Repositories/GenericRepository.cs)


5) Controller Ekleme

* En son artık Controllers katmanına Controller ekleme kısmına geçtim ve Post isminde bir Controller ekledim. Daha sonra Controller içerisine istediğim bütün Http metotlarımı ekledim. Metotlar ve Metot açıklamalarım proje içerisinde bulunuyor.

📁 [PostController.cs](https://github.com/gulsunciftci/SipayBootcampRestfulApi/blob/main/SipayBootcampApi/PatikaSipayDotNetRestfulApi/Controllers/PostController.cs)


## Badges

Add badges from somewhere like: [shields.io](https://shields.io/)

[![MIT License](https://img.shields.io/badge/License-MIT-green.svg)](https://choosealicense.com/licenses/mit/)
[![GPLv3 License](https://img.shields.io/badge/License-GPL%20v3-yellow.svg)](https://opensource.org/licenses/)
[![AGPL License](https://img.shields.io/badge/license-AGPL-blue.svg)](http://www.gnu.org/licenses/agpl-3.0)
