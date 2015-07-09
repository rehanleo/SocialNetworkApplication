using Data;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class PostService : IPostService
    {
        private IPostRepository postRepository;
        public PostService(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }

        public IList<Post> Read(string userName)
        {
            return postRepository.ReadPosts(userName).OrderByDescending(x => x.Created).ToList();
        }

        public void Post(string userName, string message)
        {
            postRepository.AddPost(userName, message);
        }

        public void Dispose()
        {
            postRepository = null;
        }
    }
}
