using DomainModel;
using System;
using System.Collections.Generic;
namespace Data
{
    public interface IDataContext
    {
        IList<Post> Posts { get; }
        IList<Link> LinkedUsers { get; }
    }
}
