using MediatR;
using ProductSystem.Application.Adapters;
using ProductSystem.Application.Contracts;
using ProductSystem.Application.Models;
using ProductSystem.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProductSystem.Application.Features.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IProductRepositoryAdapter _productRepository;
        private readonly IMailService _mailService;

        public CreateProductCommandHandler(IProductRepositoryAdapter productRepository, IMailService mailService)
        {
            _productRepository = productRepository;
            _mailService = mailService;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var createdProduct = await _productRepository.AddAsync(request);
            await SendEmail(createdProduct.Id);
            return createdProduct.Id;
        }

        private async Task SendEmail(int id)
        {
            try
            {
                await _mailService.SendEmail(id.ToString());
            }
            catch (Exception)
            {
                // make logge here
            }
        }
    }
}
