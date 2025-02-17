using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWSInfo.Data.Repository.IRepository;
using TWSInfo.Models.EFModels;

namespace TWSInfo.Data.Repository
{
    public class TypeRepository: Repository<StoreTypes>, ITypeRepository
    {
        private readonly TWSInfoDBContext _context;
        public TypeRepository(TWSInfoDBContext context) : base(context)

        {
            _context = context;
        }
    }
}
