using MediatR;
using ProductSystem.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSystem.Application.Features.Queries.GetProducts
{
    public class GetProductsQuery : IRequest<List<ProductDTO>>
    {
    }
}
