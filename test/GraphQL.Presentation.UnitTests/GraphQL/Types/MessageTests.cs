﻿using GraphQL.Presentation.GraphQL.Types;
using GraphQL.Types;
using Shouldly;
using Xunit;

namespace GraphQL.Presentation.UnitTests.GraphQL.Types
{
    public class MessageTests
    {
        private readonly Message _instance;

        public MessageTests()
        {
            _instance = new Message();
        }

        [Fact]
        public void Constructor_Name_IsSet()
        {
            _instance.Name.ShouldBe("message");
        }

        [Fact]
        public void Constructor_Description_IsSet()
        {
            _instance.Description.ShouldBe("A message that contains an author and a content.");
        }

        [Fact]
        public void Constructor_AuthorField_HasRightName()
        {
            _instance.GetField("Author").ShouldNotBeNull();
        }

        [Fact]
        public void Constructor_AuthorField_HasRightDescription()
        {
            _instance.GetField("Author").Description.ShouldBe("The author of the message.");
        }

        [Fact]
        public void Constructor_AuthorField_HasRightType()
        {
            _instance.GetField("Author").Type.ShouldBe(typeof(NonNullGraphType<StringGraphType>));
        }

        [Fact]
        public void Constructor_ContentField_HasRightName()
        {
            _instance.GetField("Content").ShouldNotBeNull();
        }

        [Fact]
        public void Constructor_ContentField_HasRightDescription()
        {
            _instance.GetField("Content").Description.ShouldBe("The content of the message.");
        }

        [Fact]
        public void Constructor_ContentField_HasRightType()
        {
            _instance.GetField("Content").Type.ShouldBe(typeof(NonNullGraphType<StringGraphType>));
        }
    }
}
