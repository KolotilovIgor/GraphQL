using GraphQL.Dto;
using GraphQL.Models;
using Microsoft.AspNetCore.Mvc;

namespace GraphQL.Abstraction
{
    public interface IStorageRepository
    {
        IEnumerable<StorageDto> GetAllStorages();
        int AddStorage(StorageDto storageDto);
        void DeleteStorage(int id);
    }
}
