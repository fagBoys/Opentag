using Vira.DataLayer.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vira.Core.DTOs.Storage
{
    public class StorageViewModel
    {
        public List<DataLayer.Entities.Storage.Storage> Storages { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
    }

}
