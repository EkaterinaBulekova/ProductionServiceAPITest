using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionRepository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly DbContext _repoContext;
        private IProductRepository _product;

        public IProductRepository Product
        {
            get
            {
                if (_product == null)
                {
                    _product = new ProductRepository(_repoContext);
                }

                return _product;
            }
        }

        public RepositoryWrapper(DbContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
    }
}
