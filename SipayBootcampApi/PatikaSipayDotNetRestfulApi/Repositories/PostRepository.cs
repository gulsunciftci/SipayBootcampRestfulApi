using PatikaSipayDotNet6RestfulApi.Context;
using PatikaSipayDotNet6RestfulApi.Models;

namespace PatikaSipayDotNet6RestfulApi.Repositories
{
    public class PostRepository : GenericRepository<Post>
    {
        public PostRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
