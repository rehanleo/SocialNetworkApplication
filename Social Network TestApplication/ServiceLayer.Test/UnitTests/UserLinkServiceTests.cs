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
    public class UserLinkServiceTests
    {
        private IUserLinkRepository userLinkRepositoryMock;
        private IUserLinkService userLinkService;

        [SetUp]
        public void SetUp()
        {
            userLinkRepositoryMock = MockRepository.GenerateMock<IUserLinkRepository>();
            userLinkService = new UserLinkService(userLinkRepositoryMock);
        }

        [Test]
        public void AddLink_Invokes_AddLinkOn_Repository()
        {
            //arrange
            var follower = "user1";
            var user = "user2";
            userLinkRepositoryMock.Expect(x => x.AddLink(follower, user));

            //act
            userLinkService.AddLink(follower, user);

            //assert
            userLinkRepositoryMock.VerifyAllExpectations();
        }

        [Test]
        public void GetLinkedUsers_ReadsDataFrom_Repository()
        {
            //arrange
            var user = "user";
            userLinkRepositoryMock.Expect(x => x.GetLinkedUsers(user));

            //act
            userLinkService.GetLinkedUsers(user);

            //assert
            userLinkRepositoryMock.VerifyAllExpectations();
        }

        [Test]
        public void GetLinkedUsers_ReturnsCorrectDataFrom_Repository()
        {
            //arrange
            var user = "User1";
            var dummyLinks = ReturnDummyLinks();
            userLinkRepositoryMock.Expect(x => x.GetLinkedUsers(user)).Return(dummyLinks);

            //act
            var result = userLinkService.GetLinkedUsers(user);

            //assert
            Assert.AreEqual(2, result.Count);
        }

        private IList<string> ReturnDummyLinks()
        {
            return new List<string>() { "user2", "user3" };
        }
    
    }
}
