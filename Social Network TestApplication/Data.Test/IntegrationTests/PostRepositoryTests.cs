using System;
using System.Xml.Linq;
using NUnit.Framework;
using Data;
using DomainModel;
using System.Collections.Generic;

namespace Application.Test.IntegrationTests
{
    [TestFixture]
    public class PostRepositoryTests
    {
        private IDataContext dataContext;
        private IPostRepository postRepository;

        [SetUp]
        public void SetUp()
        {
            dataContext = new DataContext();
            postRepository = new PostRepository(dataContext);
        }

        [Test]
        public void AddPost_AddsDataTo_DataContext()
        {
            //arrange
            var user = "user";
            var text = "text";

            //act
            postRepository.AddPost(user, text);

            //assert
            Assert.AreEqual(1, dataContext.Posts.Count);
        }

        [Test]
        public void ReadPosts_ReadsDataFrom_DataContext_ForSingleUser()
        {
            //arrange
            AddDummyPosts();

            //act
            var results = postRepository.ReadPosts("User1");

            //assert
            Assert.AreEqual(2, results.Count);
        }

        [Test]
        public void ReadPosts_ReadsDataFrom_DataContext_ForMultipleUsers()
        {
            //arrange
            AddDummyPosts();

            //act
            var results = postRepository.ReadPosts(new List<string>() {"User1", "User2"});

            //assert
            Assert.AreEqual(4, results.Count);
        }

        private void AddDummyPosts()
        {
            dataContext.Posts.Add(new Post() { User = "User1", Text = "Text1", Created = DateTime.Now });
            dataContext.Posts.Add(new Post() { User = "User1", Text = "Text2", Created = DateTime.Now });
            dataContext.Posts.Add(new Post() { User = "User2", Text = "Text1", Created = DateTime.Now });
            dataContext.Posts.Add(new Post() { User = "User2", Text = "Text2", Created = DateTime.Now });
            dataContext.Posts.Add(new Post() { User = "User3", Text = "Text1", Created = DateTime.Now });
        }
    
    }
}
