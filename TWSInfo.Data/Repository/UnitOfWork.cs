﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWSInfo.Data.Repository.IRepository;
using TWSInfo.Models.EFModels;

namespace TWSInfo.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TWSInfoDBContext _context;
        public IStoreRepository StoreRepository { get; }
        public IChainRepository ChainRepository { get; }

        public IStoreTypeRepository StoreTypeRepository { get; }

        public ICategoryRepository CategoryRepository { get; }

        public ISubTypeRepository SubTypeRepository { get; }

        public UnitOfWork(TWSInfoDBContext context)
        {
            _context = context;
            SubTypeRepository = new SubTypeRepository(_context);
            CategoryRepository = new CategoryRepository(_context);
            StoreTypeRepository = new StoreTypeRepository(_context);
            StoreRepository = new StoreRepository(_context);
            ChainRepository = new ChainRepository(_context);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
