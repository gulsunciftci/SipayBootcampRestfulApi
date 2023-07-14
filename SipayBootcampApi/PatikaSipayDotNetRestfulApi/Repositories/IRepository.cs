namespace PatikaSipayDotNet6RestfulApi.Repositories
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Interface nedir?
        /// Interface normal bir class gibi tip(type) tanımlamak için kullanılır.İçerisindeki default ve static tanımlanan metotlar hariç, 
        /// metotların implementasyonları bulunmaz ve state tutmaz.
        /// Bir çok class tarafından implement edilebilirler.Birden fazla interface’i extend edebilirler.
        /// </summary>


       List<T> GetAllTList();
       void TAdd(T p);
       void TUpdate(T p);

       void TDelete(T p);

       T TGetById(int id);

  
    }
}