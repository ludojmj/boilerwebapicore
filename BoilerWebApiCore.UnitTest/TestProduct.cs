using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using BoilerWebApiCore.Models;
using BoilerWebApiCore.Repository;
using BoilerWebApiCore.Controllers;
using BoilerWebApiCore.Shared;
using Xunit;

namespace BoilerWebApiCore.UnitTest
{
    public class TestProduct
    {

        private Mock<IProductRepo> _mockService;
        private readonly IList<Product> _dataSource = new AppDb().AppTable;
        private readonly string _firstValue = new AppDb().AppTable.First().Id;
        private readonly int _errorValue = 1;

        /// <summary>
        /// Test ProductController
        /// </summary>
        [Fact]
        public void ProductController_Get_ShouldReturnAllProducts()
        {
            // Arrange
            _mockService = new Mock<IProductRepo>();
            _mockService.Setup(x => x.GetProductsFromRepo(It.IsAny<int>())).Returns(_dataSource);
            ProductController controller = new ProductController(_mockService.Object);

            // Act
            IActionResult actionResult = controller.Get(int.Parse(_firstValue));

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(actionResult);
            var contentResult = Assert.IsType<List<Product>>(okResult.Value);
            Assert.Equal(_firstValue, contentResult.ToArray()[0].Id);
        }

        /// <summary>
        /// Test Repo OK
        /// </summary>
        [Fact]
        public void GetProductsFromRepo_ShouldReturnAllProducts()
        {
            // arrange
            IProductRepo service = new ProductRepo();

            // act
            IList<Product> test = service.GetProductsFromRepo(int.Parse(_firstValue));
            string result = test.First(x => x.Id == _firstValue).Lib;
            string expected = _dataSource.First(x => x.Id == _firstValue).Lib;

            // assert
            Assert.Equal(result, expected);
        }

        /// <summary>
        /// Test Repo KO
        /// </summary>
        [Fact]
        public void GetProductsFromRepo_ShouldReturnBusinessException()
        {
            string message = "Human message for my app exception.";
            IProductRepo test = new ProductRepo();
            var ex = Assert.Throws<BusinessException>(() => test.GetProductsFromRepo(_errorValue));
            Assert.Equal(message, ex.Message);
        }
    }
}
