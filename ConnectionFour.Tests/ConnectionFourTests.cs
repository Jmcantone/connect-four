using ConnectionFour.Service.Services.Validator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using ConnectionFour.Model.Enums;
using ConnectionFour.Tests.Data;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using ConnectionFour.Api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace ConnectionFour.Tests
{
    public class ConnectionFourTests
    {
        private readonly IValidatorService _validatorService;
        protected ConnectionFourController controller;

        public ConnectionFourTests()
        {
            SetUpTest();
        }

        [TestInitialize]
        private void SetUpTest()
        {
            ValidatorService validatorService = new();
            controller = new ConnectionFourController(validatorService);
        }

        [Theory]
        [InlineData(GameData.diagonal_ldru_a)]
        public void GetWinner_Diagonal_ShouldReturnTeamA(string inputBoard)
        {
            var response = controller.GetWinner(inputBoard).Result as OkObjectResult;

            Assert.AreEqual(response.Value, ResponseEnum.TeamAHasWon.GetDescription());
        }

        [Theory]
        [InlineData(GameData.diagonal_lurd_b)]
        public void GetWinner_Diagonal_ShouldReturnTeamB(string inputBoard)
        {
            var response = controller.GetWinner(inputBoard).Result as OkObjectResult;

            Assert.AreEqual(response.Value, ResponseEnum.TeamBHasWon.GetDescription());
        }

        [Theory]
        [InlineData(GameData.vertical_a)]
        public void GetWinner_Vertical_ShouldReturnTeamA(string inputBoard)
        {
            var response = controller.GetWinner(inputBoard).Result as OkObjectResult;

            Assert.AreEqual(response.Value, ResponseEnum.TeamAHasWon.GetDescription());
        }

        [Theory]
        [InlineData(GameData.vertical_b)]
        public void GetWinner_Vertical_ShouldReturnTeamB(string inputBoard)
        {
            var response = controller.GetWinner(inputBoard).Result as OkObjectResult;

            Assert.AreEqual(response.Value, ResponseEnum.TeamBHasWon.GetDescription());
        }

        [Theory]
        [InlineData(GameData.x_0)]
        [InlineData(GameData.x_1)]
        [InlineData(GameData.x_2)]
        public void GetWinner_Nothing_ShouldReturnOnGoing(string inputBoard)
        {
            var response = controller.GetWinner(inputBoard).Result as OkObjectResult;

            Assert.AreEqual(response.Value, ResponseEnum.TheGameIsOngoing.GetDescription());
        }
    }
}
