using DomainModel;
using System;
using System.Collections.Generic;
namespace ServiceLayer
{
    public interface IWallService : IDisposable
    {
        IList<Post> GetUserWall(string user);
    }
}
