using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vira.Core.DTOs;
using Vira.Core.DTOs.Storage;
using Vira.DataLayer.Entities.Storage;
using Vira.DataLayer.Entities.User;
using Microsoft.AspNetCore.Http;

namespace Vira.Core.Services.Interfaces
{
    public interface IStorageService
    {
        int AddStorage(AddStorageViewModel storage);

        List<Storage> GetListStoragesProduct(int productId);

        Storage GetStorageById(int id);
        void EditStorage(int id, AddStorageViewModel storage, List<string> imageName);
        Storage GetStoragesById(int storageId);
        void DeleteStorage(int storageId);
        StorageViewModel GetDeleteStorage(int pageId = 1, string productName = "", string Size = "");
        public Tuple<List<Storage>, int> GetListStorage(int pageId = 1, string productName = "", string Size = "");

    }
}
