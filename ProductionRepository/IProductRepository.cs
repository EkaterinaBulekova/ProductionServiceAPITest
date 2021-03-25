using ProductionDAL;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ProductionRepository
{
    public interface IProductRepository: IGenericRepository<Product>
    {
    }
}