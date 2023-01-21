using ACME.BL.Services;
using ACME.BL.Models;

namespace ACME.BL.Test
{
    public class ProductTest
    {
        [Fact]
        public void CaculateMargin_WhenValidCost50PercentOfPrice_ShouldReturn50()
        {
            // Arrange
            var product = new Product(100, 50);
            decimal expected = 50;

            // Act
            decimal actual = ProductService.calculateMargin(product);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CaculateMargin_WhenValidCostISOneThirdOfPrice_ShouldReturn66Point7()
        {
            // Arrange
            var product = new Product(150, 50);
            decimal expected = 66.7M;

            // Act
            decimal actual = ProductService.calculateMargin(product);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CaculateMargin_WhenValidCostISEqualToPrice_ShouldReturn0()
        {
            // Arrange
            var product = new Product(200, 200);
            decimal expected = 0;

            // Act
            decimal actual = ProductService.calculateMargin(product);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CaculateMargin_WhenValidCostIsMoreThanPrice_ShouldReturnNegetive()
        {
            // Arrange
            var product = new Product(99, 100);
            decimal expected = -1;

            // Act
            decimal actual = ProductService.calculateMargin(product);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CaculateMargin_WhenValidCostISLessThan1_ShouldReturn100()
        {
            // Arrange
            var product = new Product(100, 0.99M);
            decimal expected = 100M;

            // Act
            decimal actual = ProductService.calculateMargin(product);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CaculateMargin_WhenValid_ShouldReturn33point3()
        {
            // Arrange
            var product = new Product(30, 20);
            decimal expected = 33.3M;

            // Act
            decimal actual = ProductService.calculateMargin(product);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CaculateMargin_WhenInvalidPriceIsZero_ShouldReturnException()
        {
            // Arrange
            var product = new Product(0, 99);


            // Act
            Action act = () => ProductService.calculateMargin(product);

            //Asert
            var ex = Assert.Throws<DivideByZeroException>(act);
            Assert.Equal("Price cannot be zero.", ex.Message);

        }
    }
}