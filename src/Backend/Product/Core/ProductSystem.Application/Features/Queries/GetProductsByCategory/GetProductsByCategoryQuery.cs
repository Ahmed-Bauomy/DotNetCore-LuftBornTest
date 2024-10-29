using MediatR;
using ProductSystem.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSystem.Application.Features.Queries.GetProductsByCategory
{
    public class GetProductsByCategoryQuery : IRequest<List<ProductDTO>>
    {
        public string Category { get; set; }

        public GetProductsByCategoryQuery(string category)
        {
            Category = category;
        }
    }
}
