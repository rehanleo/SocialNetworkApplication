using System;
using System.Xml.Linq;
using NUnit.Framework;
using Data;
using DomainModel;
using System.Collections.Generic;
using ServiceLayer;
using ServiceLayer.Builders;

namespace Application.Test.UnitTests
{
    [TestFixture]
    public class PostViewBuilderTests
    {
        private IPostViewBuilder builder;

        [SetUp]
        public void SetUp()
        {
            builder = new PostViewBuilder();
        }

        [Test]
        public void BuildUserPostView_ContainsText_AndDoesNotContain_User()
        {
            //arrange
            var post = new Post() { User = "user", Text = "text", Created = DateTime.Now};

            //act
            var result = builder.BuildUserPostView(post);

            //assert
            Assert.IsTrue(result.Contains("text"));
            Assert.IsTrue(!result.Contains("user"));
        }

        [Test]
        public void BuildWallPostView_ContainsTextAndUser()
        {
            //arrange
            var post = new Post() { User = "user", Text = "text", Created = DateTime.Now };

            //act
            var result = builder.BuildWallPostView(post);

            //assert
            Assert.IsTrue(result.Contains("text"));
            Assert.IsTrue(result.Contains("user"));
        }

        [TestCase(0, "second", true)]
        [TestCase(0, "seconds", false)]
        [TestCase(-2, "seconds", true)]
        [TestCase(-61, "minute", true)]
        [TestCase(-62, "minutes", false)]
        [TestCase(-161, "minutes", true)]
        public void BuildUserPostView_CreatesCorrectTimeMessage(int seconds, string messageText, bool result)
        {
            //arrange
            var post = new Post() { User = "user", Text = "text", Created = DateTime.Now.AddSeconds(seconds) };

            //act
            var message = builder.BuildUserPostView(post);

            //assert
            Assert.AreEqual(result, message.Contains(messageText));
        }

        [TestCase(0, "second", true)]
        [TestCase(0, "seconds", false)]
        [TestCase(-2, "seconds", true)]
        [TestCase(-61, "minute", true)]
        [TestCase(-62, "minutes", false)]
        [TestCase(-161, "minutes", true)]
        public void BuildWallPostView_CreatesCorrectTimeMessage(int seconds, string messageText, bool result)
        {
            //arrange
            var post = new Post() { User = "user", Text = "text", Created = DateTime.Now.AddSeconds(seconds) };

            //act
            var message = builder.BuildWallPostView(post);

            //assert
            Assert.AreEqual(result, message.Contains(messageText));
        }
    
    }
}
