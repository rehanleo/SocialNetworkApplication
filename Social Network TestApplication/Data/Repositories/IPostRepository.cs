using DomainModel;
using System;
using System.Collections.Generic;
namespace Data
{
    public interface IPostRepository : IDisposable
    {
        void AddPost(string user, string text);
        IList<Post> ReadPosts(string userName);
        IList<Post> ReadPosts(IList<string> userNames);
    }
}
