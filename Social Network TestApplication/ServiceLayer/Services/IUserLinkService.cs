using DomainModel;
using System;
using System.Collections.Generic;
namespace ServiceLayer
{
    public interface IUserLinkService : IDisposable
    {
        void AddLink(string follower, string user);
        IList<string> GetLinkedUsers(string user);
    }
}
