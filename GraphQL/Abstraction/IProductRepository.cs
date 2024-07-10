using GraphQL.Dto;
using GraphQL.Models;
using Microsoft.AspNetCore.Mvc;

namespace GraphQL.Abstraction
{
    public interface IProductRepository
    {
        IEnumerable<ProductDto> GetAllProducts();
        int AddProduct(ProductDto productDto);
        void DeleteProduct(int id);
    }
}
