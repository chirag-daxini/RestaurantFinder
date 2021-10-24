using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantFinder.Domain;
using System.Threading.Tasks;

namespace RestaurantFinder.Tests
{
    [TestClass]
    public class ValidationServiceTests
    {
        private ValidationService _validationService;
        [TestInitialize]
        public void Intialize()
        {
            _validationService = new ValidationService();
        }

        [TestMethod]
        public async Task Should_Return_True_For_ValidData_ValidatePostCode()
        {
            //arrange
            string testCode = "EC4M 7RF";

            //act
            bool validationResult = await _validationService.ValidatePostCode(testCode);

            //assert
            Assert.IsTrue(validationResult);
        }
        [TestMethod]
        public async Task Should_Return_False_For_InvalidData_ValidatePostCode()
        {
            string testCode = "EC4M";

            //act
            bool validationResult = await _validationService.ValidatePostCode(testCode);

            //assert
            Assert.IsFalse(validationResult);
        }
    }
}
