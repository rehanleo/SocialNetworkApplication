using System;
using System.Xml.Linq;
using NUnit.Framework;
using Data;
using DomainModel;
using System.Collections.Generic;
using ServiceLayer;
using Rhino.Mocks;

namespace Application.Test.UnitTests
{
    [TestFixture]
    public class PostServiceTests
    {
        private IPostRepository postRepositoryMock;
        private IPostService postService;

        [SetUp]
        public void SetUp()
        {
            postRepositoryMock = MockRepository.GenerateMock<IPostRepository>();
            postService = new PostService(postRepositoryMock);
        }

        [Test]
        public void Post_Invokes_AddPostOn_Repository()
        {
            //arrange
            var user = "user";
            var text = "text";
            postRepositoryMock.Expect(x => x.AddPost(user, text));

            //act
            postService.Post(user, text);

            //assert
            postRepositoryMock.VerifyAllExpectations();
        }

        [Test]
        public void Read_ReadsDataFrom_Repository()
        {
            //arrange
            var user = "user";
            postRepositoryMock.Expect(x => x.ReadPosts(user));

            //act
            postService.Read(user);

            //assert
            postRepositoryMock.VerifyAllExpectations();
        }

        [Test]
        public void Read_ReturnsCorrectDataFrom_Repository()
        {
            //arrange
            var user = "User1";
            var dummyPosts = ReturnDummyPosts();
            postRepositoryMock.Expect(x => x.ReadPosts(user)).Return(dummyPosts); 

            //act
            var result = postService.Read(user);

            //assert
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Text2", result[0].Text);
        }

        private IList<Post> ReturnDummyPosts()
        {
            var posts = new List<Post>();

            posts.Add(new Post() { User = "User1", Text = "Text1", Created = DateTime.Now.AddMinutes(-1) });
            posts.Add(new Post() { User = "User1", Text = "Text2", Created = DateTime.Now });

            return posts;
        }
    
    }
}
