using GraphQL.Abstraction;
using GraphQL.Dto;
using GraphQL.Repository;

namespace GraphQL.Graph.Query
{
    public class Query
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductGroupRepository _productGroupRepository;
        private readonly IStorageRepository _storageRepository;

        public Query(IProductRepository productRepository, IProductGroupRepository productGroupRepository, IStorageRepository storageRepository)
        {
            _productRepository = productRepository;
            _productGroupRepository = productGroupRepository;
            _storageRepository = storageRepository;
        }

        public IEnumerable<ProductDto> GetProducts() => _productRepository.GetAllProducts();
        public IEnumerable<ProductGroupDto> GetProductGroups() => _productGroupRepository.GetAllProductGroups();
        public IEnumerable<StorageDto> GetStorages() => _storageRepository.GetAllStorages();
    }
}
