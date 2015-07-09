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
    public class ControllerTests
    {
        private IPostService postServiceMock;
        private IUserLinkService userLinkServiceMock;
        private IWallService wallServiceMock;
        private IPostViewBuilder postViewBuilderMock;

        private IController controller;

        [SetUp]
        public void SetUp()
        {
            postServiceMock = MockRepository.GenerateMock<IPostService>();
            userLinkServiceMock = MockRepository.GenerateMock<IUserLinkService>();
            wallServiceMock = MockRepository.GenerateMock<IWallService>();
            postViewBuilderMock = MockRepository.GenerateMock<IPostViewBuilder>();
            controller = new Controller(postServiceMock, userLinkServiceMock, wallServiceMock, postViewBuilderMock);
        }

        [Test]
        public void ProcessCommand_InvokesReadOn_PostService()
        {
            //arrange
            var command = "user1";
            postServiceMock.Expect(x => x.Read(command)).Return(new List<Post>());

            //act
            controller.ProcessCommand(command);

            //assert
            postServiceMock.VerifyAllExpectations();
        }

        [Test]
        public void ProcessCommand_InvokesReadOn_PostService_And_BuildUserPostView()
        {
            //arrange
            var command = "user1";
            postServiceMock.Expect(x => x.Read(command)).Return(ReturnDummyPosts());
            postViewBuilderMock.Expect(x => x.BuildUserPostView(null)).IgnoreArguments().Return("");

            //act
            controller.ProcessCommand(command);

            //assert
            postViewBuilderMock.VerifyAllExpectations();
        }

        [Test]
        public void ProcessCommand_InvokesGetUserWallOn_WallService()
        {
            //arrange
            var command = "user1;wall";
            wallServiceMock.Expect(x => x.GetUserWall("user1")).Return(new List<Post>());

            //act
            controller.ProcessCommand(command);

            //assert
            wallServiceMock.VerifyAllExpectations();
        }

        [Test]
        public void ProcessCommand_InvokesGetUserWallOn_WallService_And_BuildUserPostView()
        {
            //arrange
            var command = "user1;wall";
            wallServiceMock.Expect(x => x.GetUserWall("user1")).Return(ReturnDummyPosts());
            postViewBuilderMock.Expect(x => x.BuildWallPostView(null)).IgnoreArguments().Return("");

            //act
            controller.ProcessCommand(command);

            //assert
            postViewBuilderMock.VerifyAllExpectations();
        }

        [Test]
        public void ProcessCommand_InvokesPostOn_PostService()
        {
            //arrange
            var command = "user1;text";
            postServiceMock.Expect(x => x.Post("user1", "text"));

            //act
            controller.ProcessCommand(command);

            //assert
            postServiceMock.VerifyAllExpectations();
        }

        [Test]
        public void ProcessCommand_InvokesAddLinkOn_UserLinkService()
        {
            //arrange
            var command = "user1;follows;user2";
            userLinkServiceMock.Expect(x => x.AddLink("user1", "user2"));

            //act
            controller.ProcessCommand(command);

            //assert
            postServiceMock.VerifyAllExpectations();
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
