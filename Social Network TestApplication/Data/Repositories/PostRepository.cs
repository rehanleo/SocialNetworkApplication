using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class PostRepository : IPostRepository
    {
        private IDataContext dataContext;
        public PostRepository(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void AddPost(string user, string text)
        {
            dataContext.Posts.Add(new Post() { User = user, Text = text, Created = DateTime.Now });
        }

        public IList<Post> ReadPosts(string userName)
        {
            return dataContext.Posts.Where(x => x.User == userName).ToList();
        }

        public IList<Post> ReadPosts(IList<string> userNames)
        {
            return dataContext.Posts.Where(x => userNames.Contains(x.User)).ToList();
        }

        public void Dispose()
        {
        }
    }
}
