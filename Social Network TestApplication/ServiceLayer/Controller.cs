using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class Controller : IController
    {
        private IPostService postService;
        private IUserLinkService userLinkService;
        private IWallService wallService;
        private IPostViewBuilder postViewBuilder;
        public Controller(IPostService postService, IUserLinkService userService, IWallService wallService, IPostViewBuilder postViewBuilder)
        {
            this.postService = postService;
            this.userLinkService = userService;
            this.wallService = wallService;
            this.postViewBuilder = postViewBuilder;
        }

        public void ProcessCommand(string command)
        {
            var commandItems = command.Split(';');

            if (commandItems.Length == 1) // Get user posts
            {
                var msgs = postService.Read(commandItems[0]);
                foreach (var msg in msgs)
                {
                    Console.WriteLine(postViewBuilder.BuildUserPostView(msg));
                }
            }
            else if (commandItems.Length == 2 && commandItems[1] == "wall") // Get user wall
            {
                var msgs = wallService.GetUserWall(commandItems[0]);
                foreach (var msg in msgs)
                {
                    Console.WriteLine(postViewBuilder.BuildWallPostView(msg));
                }
            }
            else if (commandItems.Length == 2 && !string.IsNullOrEmpty(commandItems[1])) // Add user pos
            {
                postService.Post(commandItems[0], commandItems[1]);
            }
            else if (commandItems.Length == 3 && commandItems[1] == "follows") // Add user follower
            {
                userLinkService.AddLink(commandItems[0], commandItems[2]);
            }

            // ignoring any other commands //
        }

        public void Dispose()
        {
            postService = null;
        }
    }
}
