using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class UserLinkService: IUserLinkService
    {
        private IUserLinkRepository userLinkRepository;
        public UserLinkService(IUserLinkRepository userLinkRepository)
        {
            this.userLinkRepository = userLinkRepository;
        }

        public void AddLink(string follower, string user)
        {
            //simple check can be added here to see if users are valid and if the association already exists or not
            userLinkRepository.AddLink(follower, user);
        }

        public IList<string> GetLinkedUsers(string user)
        {
            return userLinkRepository.GetLinkedUsers(user);
        }

        public void Dispose()
        {
            userLinkRepository = null;
        }
    }
}
