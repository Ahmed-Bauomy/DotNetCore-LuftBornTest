using Moq;
using ProductSystem.Adapters.TestApis;
using ProductSystem.Application.Features.Commands.CreateProduct;
using ProductSystem.Domain.Entities;

namespace ProductSystem.UnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task HandleCreateProduct_Test()
        {
            // arrange
            var resultProductId = 1;
            // act
            var productNumber = await TestApi.simulateCreateProduct(resultProductId);

            // assert
            Assert.That(productNumber, Is.EqualTo(resultProductId));
        }
    }
}