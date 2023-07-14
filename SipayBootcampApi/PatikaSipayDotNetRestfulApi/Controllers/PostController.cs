using Azure;
using CoreApiResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PatikaSipayDotNet6RestfulApi.Context;
using PatikaSipayDotNet6RestfulApi.Models;
using PatikaSipayDotNet6RestfulApi.Repositories;
using System;
using System.Linq;
using static System.Net.WebRequestMethods;

namespace PatikaSipayDotNet6RestfulApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostController : BaseController //Bir controller bir class'tan inherit(miras) almış.
    {


        ApplicationDbContext _dbContext;
        PostRepository postRepository;

        public PostController(ApplicationDbContext dbContext) //controller içerisinde enjekte ettim.
        {
            _dbContext = dbContext;
            postRepository = new PostRepository(_dbContext);
        }



        /// <summary>
        /// **** Get:
        /// Bu metod sunucudan veri almak için kullanılır. 
        /// Bunun en önemli faydası kullanıcıların bookmark edebilmeleri ve aynı sorguyu içeren istekleri daha sonra gönderebilmelerini sağlaması ve 
        /// tarayıcıda önceki sorguların “geri” tuşu ile veya tarayıcı geçmişinden çağrılarak aynı sayfalara ulaşabilmeleridir.
        /// Güvenlik açısından URL’lerin ekranda görüntüleniyor olması ve 
        /// URL’in hedefine ulaşıncaya kadar ve hedef sunucu üzerinde iz kayıtlarında görülebilmesi gönderilen parametrelerin gizlilik ihtiyacı varsa sıkıntı yaratabilir. 
        /// Bu nedenlerle hassas istekler GET ile gönderilmemelidir.
        /// GET ve POST metodları en sık kullanılan metodlar olup sunucudaki kaynaklara erişmek için kullanılırlar.
        /// Kendimizin bir REST API oluşturduğu bir senaryoyu düşünelim. Geliştirme aşamasında Postman yardımıyla gelen isteklere karşı uygulamamızın vereceği cevapları test edebiliriz.
        /// </summary>



        ///<summary>
        ///**** Action Methodlar:
        ///Eylemlere parametre geçmenin birden fazla yolu vardır. En çok kullanılan 3 yöntem FromBody , FromQuery ve FromRoute attribute'leri kullanılarak yapılanlardır.
        ///1) FromBody: Http request inin body'si içerisinde gönderilen parametreleri okumak için kullanılır.
        ///2) FromQuery: Url içerisine gömülen parametreleri okumak için kullanılan attribute dur.
        ///3) FromRoute: Endpoint url'i içerisinde gönderilen parametreleri okumak için kullanılır. Yaygın olarak resource'a ait id bilgisi okurken kullanılır.
        /// 
        /// </summary>




        [HttpGet]
        public IActionResult GetAll() //Post tablomuzdaki bütün verileri listeleyen metottur.
        {
            try
            {
                //var posts = _dbContext.Posts.ToList();
                var posts = postRepository.GetAllTList();
                return Ok(posts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetByIdRoute([FromRoute] int id) //Kullanıcıdan istenen Id'ye ait verileri listeleyen metottur.
        {

            try
            {

                var post = postRepository.TGetById(id);
                if (post == null)
                {
                    return NotFound();
                }
                return Ok(post);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetByIdQuery([FromQuery] int id)
        {

            try
            {
                var post = postRepository.TGetById(id);
                if (post == null)
                {
                    return NotFound();
                }
                return Ok(post);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        public IActionResult GetAllCreatedDateOrderBy() //
        {

            try
            {

                var post = postRepository.GetAllTList().OrderBy(c => c.CreatedDate.Year).ThenByDescending(c => c.Title).ToList();
                // OrderBy ile parametre olarak belirtien alan küçükten büyüğe doğru sıralanmaktadır.
                // OrderBy metodunu kullanarak bir sıralama işlemi yaptıktan sonra tekrardan başka bir alan üzerinde de büyükten küçüğe sıralama işlemi yapmak istersek
                // Bu işlemi gerçekleştirmek için ThenByDescending metodunu kullanırız. 
                if (post == null)
                {
                    return NotFound();
                }
                return Ok(post);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAllTitleLengthOrderByDescending()
        {

            try
            {

                var post = postRepository.GetAllTList().OrderByDescending(c => c.Title.Length).ThenBy(c => c.CreatedDate.Day).ToList();
                //OrderByDescending ile parametre olarak belirtilen alan büyükten küçüğe doğru sıralanmaktadır.
                // OrderByDescending metodunu kullanarak bir sıralama işlemi yaptıktan sonra tekrardan başka bir alan üzerinde de küçükten büyüğe sıralama işlemi yapmak istersek
                // Bu işlemi gerçekleştirmek için ThenBy metodunu kullanırız. 
                if (post == null)
                {
                    return NotFound();
                }
                return Ok(post);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{text}")]
        public IActionResult PostTitleSearch([FromRoute]string text) //Title'ının içerisinde text'i bulunduran Postları listeler.
        {

            try
            {

                var posts = postRepository.GetAllTList().Where(c=>c.Title.Contains(text));
                return Ok(posts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{title}")]
        public IActionResult PostTitleFiltering([FromRoute] string title) //Title'ı parametre olarak gelen title'a eşit olan Postları listeler.
        {

            try
            {

                var posts = _dbContext.Posts.Where(c => c.Title.ToLower() == title.ToLower()).ToList();
                return Ok(posts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




        /// <summary>
        /// **** POST:
        /// Bu metod ile sunucuya veri yazdırabilirsiniz. 
        /// Bu metodla istek parametreleri hem URL içinde hem de mesaj gövdesinde gönderilebilir.
        /// Sadece mesaj gövdesinin kullanımı yukarıda sayılan riskleri engelleyecektir. 
        /// Tarayıcılar geri butonuna basıldığında POST isteğinin mesaj gövdesinde yer alan parametreleri tekrar göndermek isteyip istemedimizi sorarlar. 
        /// Bunun temel nedeni bir işlemi yanlışlıkla birden fazla yapmayı engellemektir. 
        /// Bu özellik ve de güvenlik gerekçeleriyle bir işlem gerçekleştirileceğinde POST metodunun kullanılması önerilir.
        /// </summary>

        [HttpPost]
        public IActionResult Add([FromBody] Post post) //Yeni bir Post eklemek için kullanılan metot.
        {

            try
            {
                post.CreatedDate = DateTime.Now;
                postRepository.TAdd(post);
               
                return Created("", post);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// **** PUT:
        /// Bu metod ile servis sağlayıcı üzerindeki bir kaynağı güncelleyebilirsiniz. 
        /// Hangi kaynağı güncelleyecekseniz o kaynağın id’sini göndermek zorunludur.
        /// </summary>

        [HttpPut("{id}")]
        public IActionResult Edit([FromRoute, FromBody]int id, Post post) //Var olan bir Post'u değiştirmek için kullanılan metot.
        { 

            try
            {
                if (id == 0)
                {
                    return BadRequest("Id is missing");
                }
                if (postRepository.TGetById(id)== null)
                {
                    return BadRequest("This id does not exist!");
                }
                post.Id = id;
                postRepository.TUpdate(post);
                
                return Ok(post);
               
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        /// <summary>
        /// **** DELETE:
        /// Bu metod ile sunucudaki herhangi bir veriyi silebilirsiniz.
        /// </summary>

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]int id) //Kullanıcıdan alınan Id'ye göre Post silen metot.
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                var post = postRepository.TGetById(id);
                if (post == null)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    postRepository.TDelete(post);
                    return Ok("Post has been deleted");
                }
               
                return BadRequest("Post delete failed");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpPut("{id:int}")]
        public IActionResult EditPatch([FromRoute, FromBody] int id, JsonPatchDocument<Post> post) //Bu metod, girilen Id değerinin Post'unda istediğimiz küçük çaplı değişimi yapar.
        {

            try
            {
                if (id == 0)
                {
                    return BadRequest("Id is missing");
                }
                var pst = postRepository.TGetById(id);
                if (pst == null)
                {
                    return BadRequest("This id does not exist!");
                }
                post.ApplyTo(pst, ModelState);
                return Ok(post);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


    }
    ///<summary>
    /// **** DİĞER HTTP METOTLARI: 
    /// 1) HEAD:
    ///  GET metoduyla benzer işleve sahiptir ancak geri dönen yanıtta mesaj gövdesi bulunmaz (yani başlıklar ve içerikleri GET metoduyla aynıdır). 
    ///  Bu nedenle GET mesajı gönderilmeden önce bir kaynağın var olup olmadığını kontrol etmek için kullanılabilir.
    /// 2) CONNECT:
    /// Bir proxy sunucu üzerinden başka bir sunucuya bağlanmak ve proxy sunucuyu bir tünel gibi kullanmak için kullanılır.
    /// 3) OPTIONS:
    /// Bu metot belli bir kaynak için kullanılabilecek HTTP metotlarını sunucudan sorgulamak için kullanılır.
    /// 4) TRACE:
    /// Teşhis amaçlı kullanılan bir metoddur. Sunucu bu metodla gelen istek mesajının içeriğini aynen yanıt gövdesinde geri göndermelidir. 
    /// Bu yöntemle sunucu ile istemci arasında bir vekil sunucu varsa bu sunucunun ve yaptığı değişikliklerin tespiti mümkün olabilir.
    /// 4) PATCH: 
    /// Bu metod bir kaynağa istediğiniz küçük çaplı değişimi yapmanızı sağlar.
    /// 5) SEARCH: 
    /// Bir dizinin altındaki kaynakları sorgulamak için kullanılır.
    /// </summary>
}
