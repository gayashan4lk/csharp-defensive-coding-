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
        public void CaculateMargin_WhenValidCostOneThirdOfPrice_ShouldRoundTo66()
        {
            // Arrange
            var product = new Product(150, 50);
            decimal expected = 66;

            // Act
            decimal actual = ProductService.calculateMargin(product);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CaculateMargin_WhenValidCostEqualToPrice_ShouldReturn0()
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
        public void CaculateMargin_WhenValidCostLessThan1_ShouldReturn100()
        {
            // Arrange
            var product = new Product(100, 0.99M);
            decimal expected = 100M;

            // Act
            decimal actual = ProductService.calculateMargin(product);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}