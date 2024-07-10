using GraphQL.Abstraction;
using GraphQL.Dto;
using GraphQL.Repository;

namespace GraphQL.Graph.Mutation
{
    public class Mutation
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductGroupRepository _productGroupRepository;
        private readonly IStorageRepository _storageRepository;

        public Mutation(IProductRepository productRepository, IProductGroupRepository productGroupRepository, IStorageRepository storageRepository)
        {
            _productRepository = productRepository;
            _productGroupRepository = productGroupRepository;
            _storageRepository = storageRepository;
        }

        public int AddProduct(ProductDto productDto) => _productRepository.AddProduct(productDto);
        public int AddProductGroup(ProductGroupDto productGroupDto) => _productGroupRepository.AddProductGroup(productGroupDto);
        public int AddStorage(StorageDto storageDto) => _storageRepository.AddStorage(storageDto);
    }
}
