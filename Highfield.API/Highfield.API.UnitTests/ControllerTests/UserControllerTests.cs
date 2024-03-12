using Highfield.API.Controllers;
using Highfield.Data.DTOs.DTOs;
using Microsoft.Extensions.Logging;
using Moq;

namespace Highfield.API.UnitTests.ControllerTests
{
    [TestClass]
    public class UserControllerTests
    {
        private UserController? _userController;
        private Mock<ILogger<UserController>>? _mockLogger;

        [TestInitialize]
        public void Setup()
        {
            _mockLogger = new Mock<ILogger<UserController>>();
            _userController = new UserController();
        }


        [TestMethod]
        public void GetUser_Returns_Users()
        {
            // Arrange
            var expectedUserData = new List<UserDto>
            {
                new UserDto
                {
                    Id = Guid.Parse("c9cacc2f-08a6-483f-a03e-653a71664260"),
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com"
                }
            };


            // Act
            var result = _userController?.GetUserData();

            // Assert
            Assert.IsInstanceOfType(result?.Result, typeof(IEnumerable<UserDto>));
        }
    }
}