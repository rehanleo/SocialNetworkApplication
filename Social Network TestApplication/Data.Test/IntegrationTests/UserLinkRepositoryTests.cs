using System;
using System.Xml.Linq;
using NUnit.Framework;
using Data;
using NSubstitute;
using DomainModel;
using System.Collections.Generic;

namespace Application.Test.IntegrationTests
{
    [TestFixture]
    public class UserLinkRepositoryTests
    {
        private IDataContext dataContext;
        private IUserLinkRepository userLinkRepository;

        [SetUp]
        public void SetUp()
        {
            dataContext = new DataContext();
            userLinkRepository = new UserLinkRepository(dataContext);
        }

        [Test]
        public void AddLink_AddsDataTo_DataContext()
        {
            //arrange
            var follower = "follower";
            var user = "user";

            //act
            userLinkRepository.AddLink(follower, user);

            //assert
            Assert.AreEqual(1, dataContext.LinkedUsers.Count);
        }

        [TestCase("User1", 2)]
        [TestCase("User2", 0)]
        [TestCase("User3", 1)]
        public void ReadPosts_ReadsDataFrom_DataContext_ForSingleUser(string user, int resultCount)
        {
            //arrange
            AddDummyLinks();

            //act
            var results = userLinkRepository.GetLinkedUsers(user);

            //assert
            Assert.AreEqual(resultCount, results.Count);
        }

       
        private void AddDummyLinks()
        {
            dataContext.LinkedUsers.Add(new Link() { Follower = "User1", User = "User2" });
            dataContext.LinkedUsers.Add(new Link() { Follower = "User1", User = "User3" });
            dataContext.LinkedUsers.Add(new Link() { Follower = "User3", User = "User2" });
        }
    
    }
}
