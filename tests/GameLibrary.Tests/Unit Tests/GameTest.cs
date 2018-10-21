﻿using FluentValidation;
using System;
using System.Collections.Generic;
using FluentValidation.Results;
using System.Text;
using Xunit;
using System.Linq;
using GameLibrary.Tests.Builders;
using ExpectedObjects;
using Bogus;
using GameLibrary.Domain;
using GameLibrary.Domain.Games;

namespace GameLibrary.Tests.Unit_Tests
{
    public class GameTest
    {
        private readonly string _title;
        private readonly string _description;

        public GameTest()
        {
            var fake = new Faker();
            _title = fake.Lorem.Text();
            _description = fake.Lorem.Paragraphs(2);
        }

        [Fact]
        public void Game_CreateGame_ReturnSuccess()
        {
            var expectedGame = new
            {
                Title = _title,
                Description = _description
            };

            var game = new Game(expectedGame.Title, expectedGame.Description);

            expectedGame.ToExpectedObject().ShouldMatch(game);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("E")]
        public void Game_CreateGameWithoutTitle_ReturnFail(string p)
        {
            //Arrange                        
            var ret = GameBuilder.Create().SetTitle(p).Build();

            //Act
            var x = ret.IsValid();
            IList<ValidationFailure> failures = ret.ValidationResult.Errors;

            //Assert
            Assert.Contains("Game name must be provided and must be between 2 and 150 characters", failures.Select(y => y.ErrorMessage).ToList());
        }
    }
}
