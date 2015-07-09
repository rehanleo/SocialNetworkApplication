using DomainModel;
using System;
using System.Collections.Generic;
namespace ServiceLayer
{
    public interface IPostService : IDisposable
    {
        void Post(string userName, string message);
        IList<Post> Read(string userName);
    }
}
