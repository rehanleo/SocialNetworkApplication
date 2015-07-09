using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DataContext : IDataContext 
    {

        private IList<Post> posts;
        private IList<Link> linkedUsers;

        public DataContext()
        {
            posts = new List<Post>();
            linkedUsers = new List<Link>();
        }

        public IList<Post> Posts { get { return posts; } }
        public IList<Link> LinkedUsers { get { return linkedUsers; } }
        
    }
}
