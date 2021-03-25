using ProductionDAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionRepository
{
    public class ProductRepository: EFGenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DbContext context):base(context)
        {

        }

    }
}
