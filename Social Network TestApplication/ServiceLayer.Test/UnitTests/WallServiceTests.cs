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
    public class WallServiceTests
    {
        private IPostRepository postRepositoryMock;
        private IUserLinkService userLinkServiceMock;
        private IWallService wallService;

        [SetUp]
        public void SetUp()
        {
            postRepositoryMock = MockRepository.GenerateMock<IPostRepository>();
            userLinkServiceMock = MockRepository.GenerateMock<IUserLinkService>();
            wallService = new WallService(postRepositoryMock, userLinkServiceMock);
        }

        [Test]
        public void GetUserWall_Invokes_GetLinkedUsersOn_UserLinkService()
        {
            //arrange
            var user = "user1";
            var users = new List<string>(){"user1", "user2"};
            userLinkServiceMock.Expect(x => x.GetLinkedUsers(user)).Return(users);
            postRepositoryMock.Expect(x => x.ReadPosts(users));

            //act
            wallService.GetUserWall(user);

            //assert
            userLinkServiceMock.VerifyAllExpectations();
        }

        [Test]
        public void GetUserWall_Invokes_ReadPostsOn_PostRepository()
        {
            //arrange
            var user = "user1";
            var users = new List<string>() { "user1", "user2" };
            userLinkServiceMock.Expect(x => x.GetLinkedUsers(user)).Return(users);
            postRepositoryMock.Expect(x => x.ReadPosts(users));

            //act
            wallService.GetUserWall(user);

            //assert
            postRepositoryMock.VerifyAllExpectations();
        }

        [Test]
        public void GetUserWall_ReturnsCorrectData()
        {
            //arrange
            var user = "user1";
            var users = new List<string>() { "user1", "user2" };
            var dummyPosts = ReturnDummyPosts();
            userLinkServiceMock.Expect(x => x.GetLinkedUsers(user)).Return(users);
            postRepositoryMock.Expect(x => x.ReadPosts(users)).Return(dummyPosts);

            //act
            var result = wallService.GetUserWall(user);

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
