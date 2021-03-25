using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using ProductionDAL;
using ProductionRepository;
using ProductionWebAPI.Controllers;
using ProductionWebAPI.Models;
using ProductionWebAPI.Tests.Mocks;
using Serilog;

namespace ProductionWebAPI.Tests
{
        [TestClass]
        public class ProductControllerTest
        {
        static private IMapper _mapper;
        static private ILogger _logger;
        static private IProductRepository _repository;

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            Action<IMapperConfigurationExpression> mapperConfigurationExp = cfg =>
            {
                cfg.CreateMap<Product, ProductViewModel>();
                cfg.CreateMap<ProductViewModel, Product>();
            };

            var mapperConfiguration = new MapperConfiguration(mapperConfigurationExp);
            _mapper = mapperConfiguration.CreateMapper();
            _logger = new LoggerConfiguration()
               .CreateLogger();
            _repository = new FakeRepository();
        }

        [TestMethod]
        public void Get()
        {

            // Arrange
            ProductController controller = new ProductController(_logger, _mapper, _repository);
            var initialCount = _repository.Get().Count();

            // Act
            IEnumerable<ProductViewModel> result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(initialCount, result.Count());
            Assert.AreEqual("Product1", result.ElementAt(0).Name);
            Assert.AreEqual("Product2", result.ElementAt(1).Name);
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            ProductController controller = new ProductController(_logger, _mapper, _repository);

            // Act
            ProductViewModel result = controller.Get(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Product1", result.Name);
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            ProductController controller = new ProductController(_logger, _mapper, _repository);
            var newProduct = new ProductViewModel() { ProductID = 0, ProductNumber = "Product4_Number", Name = "Product4" };

            // Act
            controller.Post(newProduct);
            Product result = _repository.FindById(4);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(newProduct.Name, result.Name);
        }

        [TestMethod]
        public void Put()
        {
            // Arrange
            ProductController controller = new ProductController(_logger, _mapper, _repository);
            var updetedProduct = new ProductViewModel() { ProductID = 1, ProductNumber = "New_Product_Number", Name = "New_Product_Name" };

            // Act
            controller.Put(updetedProduct.ProductID, updetedProduct);
            Product result = _repository.FindById(updetedProduct.ProductID);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(updetedProduct.Name, result.Name);
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            ProductController controller = new ProductController(_logger, _mapper, _repository);
            var initialCount = _repository.Get().Count();

            // Act
            controller.Delete(3);
            Product result = _repository.FindById(3);
            var resultCount = _repository.Get().Count();

            // Assert
            Assert.IsNull(result);
            Assert.AreEqual(initialCount - 1, resultCount);
        }
    }
}

