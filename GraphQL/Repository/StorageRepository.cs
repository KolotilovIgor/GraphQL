using GraphQL.Abstraction;
using GraphQL.Data;
using GraphQL.Dto;
using GraphQL.Models;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic; 

namespace GraphQL.Repository
{
    public class StorageRepository : IStorageRepository
    {
        private readonly StorageContext _storageContext;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;

        public StorageRepository(StorageContext storageContext, IMapper mapper, IMemoryCache memoryCache)
        {
            _storageContext = storageContext;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        public int AddStorage(StorageDto storageDto)
        {
            var entity = _mapper.Map<Storage>(storageDto);
            _storageContext.Storages.Add(entity);
            _storageContext.SaveChanges();
            _memoryCache.Remove("storages");
            return entity.Id;
        }

        public IEnumerable<StorageDto> GetAllStorages()
        {
            if (_memoryCache.TryGetValue("storages", out List<StorageDto> listDto))
                return listDto;

            listDto = _storageContext.Storages.Select(_mapper.Map<StorageDto>).ToList();
            _memoryCache.Set("storages", listDto, TimeSpan.FromMinutes(30));
            return listDto;
        }

        public void DeleteStorage(int id)
        {
            var storage = _storageContext.Storages.Find(id);
            if (storage == null)
                throw new KeyNotFoundException("Складское место не найдено.");

            _storageContext.Storages.Remove(storage);
            _storageContext.SaveChanges();
            _memoryCache.Remove("storages");
        }
    }
}
