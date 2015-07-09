using DomainModel;
using System;
using System.Collections.Generic;
namespace ServiceLayer
{
    public interface IPostViewBuilder
    {
        string BuildUserPostView(Post post);
        string BuildWallPostView(Post post);
    }
}
