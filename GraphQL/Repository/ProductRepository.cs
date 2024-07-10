using GraphQL.Abstraction;
using GraphQL.Data;
using GraphQL.Dto;
using GraphQL.Models;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;

namespace GraphQL.Repository
{
    public class ProductRepository : IProductRepository
    {
        StorageContext storageContext;
        IMapper _mapper;
        IMemoryCache _memoryCache;
        public int AddProduct(ProductDto productDto)
        {
                if (storageContext.Products.Any(p => p.Name == productDto.Name))
                    throw new Exception("Уже есть с таким именем");

                var entity = _mapper.Map<Product>(productDto);
                storageContext.Products.Add(entity);
                storageContext.SaveChanges();
                _memoryCache.Remove("products");
                return entity.Id;
        }
        public IEnumerable<ProductDto> GetAllProducts()
        {
                if (_memoryCache.TryGetValue("products", out List<ProductDto> listDto)) return listDto;
                listDto = storageContext.Products.Select(_mapper.Map<ProductDto>).ToList();
                _memoryCache.Set("products", listDto, TimeSpan.FromMinutes(30));
                return listDto;
        }

        public void DeleteProduct(int id)
        {
            var product = storageContext.Products.Find(id);
            if (product == null)
            {
                throw new KeyNotFoundException("Продукт не найден.");
            }
            storageContext.Products.Remove(product);
            storageContext.SaveChanges();
            _memoryCache.Remove("products");
        }
    }
}
