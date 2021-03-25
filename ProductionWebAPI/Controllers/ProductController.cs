using AutoMapper;
using ProductionDAL;
using ProductionRepository;
using ProductionWebAPI.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace ProductionWebAPI.Controllers
{
    /// <summary>
    /// An product controller
    /// </summary>
    public class ProductController : ApiController
    {
        private ILogger Logger { get; }
        private IMapper Mapper { get; }
        private IProductRepository Repository { get; }
        public ProductController(ILogger logger, IMapper mapper, IProductRepository repository)
        {
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            Repository = repository ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Get all of the products
        /// </summary>
        /// <returns>IEnumerable of ProductViewModel</returns>
        // GET: api/Product
        public IEnumerable<ProductViewModel> Get()
        {
            return Mapper.Map<IEnumerable<ProductViewModel>>(Repository.Get());
        }

        /// <summary>
        /// Get a product by id
        /// </summary>
        /// <param name="id">The value identifier</param>
        /// <returns>Requested product</returns>
        // GET: api/Product/5
        public ProductViewModel Get(int id)
        {
            Logger.Information($"Product with id='{id}' is requested");
            var product = Mapper.Map<ProductViewModel>(Repository.FindById(id));
            return product;
        }

        /// <summary>
        /// Create a new product
        /// </summary>
        /// <param name="value">New product value</param>
        // POST: api/Product
        public void Post([FromBody]ProductViewModel value)
        {
            Repository.Create(Mapper.Map<Product>(value));
        }

        /// <summary>
        /// Update the previously created product
        /// </summary>
        /// <param name="id">The product identifier</param>
        /// <param name="value">New product value</param>
        // PUT: api/Product/5
        public void Put(int id, [FromBody]ProductViewModel value)
        {
            Repository.Update(id, Mapper.Map<Product>(value));
        }

        /// <summary>
        /// Remove the earlier created product
        /// </summary>
        /// <param name="id">The product identifier</param>
        // DELETE: api/Product/5
        public void Delete(int id)
        {
            Repository.Remove(id);
        }
    }
}
