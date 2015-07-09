using Data;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class WallService : IWallService
    {
        private IPostRepository messageRepository;
        private IUserLinkService userLinkService;
        public WallService(IPostRepository messageRepository, IUserLinkService userLinkService)
        {
            this.messageRepository = messageRepository;
            this.userLinkService = userLinkService;
        }

        public IList<Post> GetUserWall(string user)
        {
            var users = userLinkService.GetLinkedUsers(user);
            users.Add(user);

            return messageRepository.ReadPosts(users).OrderByDescending(x => x.Created).ToList();
        }

        public void Dispose()
        {
            messageRepository = null;
            userLinkService = null;
        }
    }
}
