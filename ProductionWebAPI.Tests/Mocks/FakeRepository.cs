using ProductionDAL;
using ProductionRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionWebAPI.Tests.Mocks
{

    public class FakeRepository : IProductRepository
    {
        private static int ProductsCount = 3;
        private static List<Product> Products = new List<Product>(){
            new Product()
            {
                ProductID = 1,
                Name = "Product1",
                ProductNumber = "Product1_Number"
            },
            new Product()
            {
                ProductID = 2,
                Name = "Product2",
                ProductNumber = "Product2_Number"
            },
            new Product()
            {
                ProductID = 3,
                Name = "Product3",
                ProductNumber = "Product3_Number"
            },
            };

        public void Create(Product item)
        {
            item.ProductID = ++ProductsCount;
            Products.Add(item);
        }

        public Product FindById(int id)
        {
            return Products.FirstOrDefault(p=>p.ProductID == id);
        }

        public IEnumerable<Product> Get()
        {
            return Products;
        }

        public IEnumerable<Product> Get(Func<Product, bool> predicate)
        {
            return Products.Where(predicate);
        }

        public Product Remove(int key)
        {
            var existing = Products.FirstOrDefault(p => p.ProductID == key);
            if (existing != null)
                Products.Remove(existing);
            return existing;
        }

        public Product Update(int key, Product item)
        {
            var existing = Products.FirstOrDefault(p => p.ProductID == key);
            if (existing != null)
            {
                existing.Name = item.Name;
                existing.ProductNumber = item.ProductNumber;
            }
               
            return existing;
        }
    }
}
