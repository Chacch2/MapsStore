﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWSInfo.Models.DTOs;
using TWSInfo.Models.EFModels;

namespace TWSInfo.Data.Repository.IRepository
{
    public interface IStoreRepository : IRepository<Stores>
    {
        Task<IEnumerable<Stores>> GetStoresByCategoriesAsync(string? mainCategory, string? subCategory, string? chainName);
    }
}
