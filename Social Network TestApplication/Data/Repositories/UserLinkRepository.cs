using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UserLinkRepository : IUserLinkRepository
    {
        private IDataContext dataContext;
        public UserLinkRepository(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void AddLink(string follower, string user)
        {
            dataContext.LinkedUsers.Add(new Link() { Follower = follower, User = user });
        }

        public IList<string> GetLinkedUsers(string user)
        {
            return (from ls in dataContext.LinkedUsers
                    where ls.Follower == user
                    select ls.User).ToList();
        }

        public void Dispose()
        {
        }
    }
}
