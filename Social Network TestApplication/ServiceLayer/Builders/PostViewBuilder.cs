using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Builders
{
    //should be moved to presentation layer
    public class PostViewBuilder : IPostViewBuilder
    {
        public string BuildUserPostView(Post post)
        {
            return string.Format("{0} ({1} ago)", post.Text, FormatTimeMessage(post.Created));
        }

        public string BuildWallPostView(Post post)
        {
            return string.Format("{0} - {1} ({2} ago)", post.User, post.Text, FormatTimeMessage(post.Created));
        }

        private string FormatTimeMessage(DateTime dateTime)
        {
            var createdSinceSeconds = (int)(DateTime.Now - dateTime).TotalSeconds;

            if (createdSinceSeconds < 2)
                return string.Format("{0} second", createdSinceSeconds); 
            if (createdSinceSeconds < 60)
                return string.Format("{0} seconds", createdSinceSeconds);
            if (createdSinceSeconds >= 60 && createdSinceSeconds < 120)
                return "1 minute";
            if (createdSinceSeconds >= 120)
                return string.Format("{0} minutes", (int)(createdSinceSeconds / 60));
            //hours, days etc....

            return null;
        }
    }
}
