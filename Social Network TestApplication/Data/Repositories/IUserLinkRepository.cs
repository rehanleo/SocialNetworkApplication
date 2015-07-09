using System;
using System.Collections.Generic;
namespace Data
{
    public interface IUserLinkRepository : IDisposable
    {
        void AddLink(string follower, string user);
        IList<string> GetLinkedUsers(string user);
    }
}
