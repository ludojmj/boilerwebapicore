using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using BoilerWebApiCore.Models;
using BoilerWebApiCore.Repository;
using BoilerWebApiCore.Controllers;
using Xunit;

namespace BoilerWebApiCore.UnitTest
{
    public class TestOtherProduct
    {
        private Mock<IOtherProductRepo> _mockService;
        private readonly IList<Product> _dataSource = new AppDb().AppTable;
        private readonly Product _firstValue = new AppDb().AppTable.First();
        private readonly Product _errorValue = new Product() { Id = "1", Lib = "Label1" };

        /// <summary>
        /// Test OtherProductController
        /// </summary>
        [Fact]
        public void OtherProductController_Post_ShouldReturnAllProducts()
        {
            // Arrange
            _mockService = new Mock<IOtherProductRepo>();
            _mockService.Setup(x => x.GetOtherProductsFromRepo(It.IsAny<Product>())).Returns(_dataSource);
            OtherProductController controller = new OtherProductController(_mockService.Object);

            // Act
            IActionResult actionResult = controller.Post(_firstValue);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(actionResult);
            var contentResult = Assert.IsType<List<Product>>(okResult.Value);
            Assert.Equal(_firstValue.Id, contentResult.ToArray()[0].Id);
            Assert.Equal(_firstValue.Lib, contentResult.ToArray()[0].Lib);
        }

        /// <summary>
        /// Test Repo OK
        /// </summary>
        [Fact]
        public void GetOtherProductsFromRepo_ShouldReturnAllProducts()
        {
            // arrange
            OtherProductRepo service = new OtherProductRepo();

            // act
            IList<Product> test = service.GetOtherProductsFromRepo(_firstValue);
            string result = test.First(x => x.Id == _firstValue.Id).Lib;
            string expected = _dataSource.First(x => x.Id == _firstValue.Id).Lib;

            // assert
            Assert.Equal(result, expected);
        }

        /// <summary>
        /// Test Repo KO
        /// </summary>
        [Fact]
        public void GetOtherProductsFromRepo_ShouldReturnDivideByZeroException()
        {
            string message = "Attempted to divide by zero.";
            IOtherProductRepo test = new OtherProductRepo();
            var ex = Assert.Throws<DivideByZeroException>(() => test.GetOtherProductsFromRepo(_errorValue));
            Assert.Equal(message, ex.Message);
        }
}
}
