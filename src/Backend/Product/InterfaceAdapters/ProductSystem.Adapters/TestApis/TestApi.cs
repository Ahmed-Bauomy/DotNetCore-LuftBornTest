using Moq;
using ProductSystem.Application.Adapters;
using ProductSystem.Application.Contracts;
using ProductSystem.Application.Features.Commands.CreateProduct;
using ProductSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSystem.Adapters.TestApis
{
    public static class TestApi
    {
        private static Mock<IProductRepositoryAdapter> productRespositoryAdapterMock = new();
        private static Mock<IMailService> mailServiceMock = new();
        private static CreateProductCommand createProductCommand = new CreateProductCommand()
        {
            Name = "Samsung A35",
            Category = "Mobile",
            Summary = "Mobile Samsung 8 core",
            Description = "4 Gb Ram, with 128 space",
            ImageFile = "file",
            Price = 13000
        };
        private static Product resultProduct = new Product()
        {
            Name = createProductCommand.Name,
            Category = createProductCommand.Category,
            Summary = createProductCommand.Summary,
            Description = createProductCommand.Description,
            ImageFile = createProductCommand.ImageFile,
            Price = createProductCommand.Price
        };
        public static async Task<int> simulateCreateProduct(int id)
        {
            resultProduct.Id = id;
            productRespositoryAdapterMock.Setup(x => x.AddAsync(It.IsAny<CreateProductCommand>()))
                                         .ReturnsAsync(resultProduct);
            var CreateProductHandler = new CreateProductCommandHandler(productRespositoryAdapterMock.Object,mailServiceMock.Object);
            var result = await CreateProductHandler.Handle(createProductCommand, default);
            return result;
        }
    }
}
