using ACME.WEB.ControllerServices;

namespace ACME.WEB.Test
{
    public class ProductControllerServiceTest
    {
        ProductControllerService service;

        public ProductControllerServiceTest()
        {
            service = new ProductControllerService();
        }

        [Fact]
        public void CaculateMargin_WhenValid_ShouldReturn50()
        {
            // Arrange
            var priceInput = "100";
            var costInput = "50";

            // Act
            var actual = service.CalculateMargin(priceInput, costInput);

            // Assert
            Assert.Equal((decimal)50, actual);            
        }

        [Fact]
        public void CaculateMargin_WhenInvalidPriceCostNaN_ShouldReturnException()
        {
            // Arrange
            var priceInput = "NaN";
            var costInput = "NaN";

            // Act
            var ex = Assert.Throws<ArgumentException>(() => service.CalculateMargin(priceInput, costInput));

            // Assert
            Assert.Equal("The value must be a number", ex.Message);
        }

        [Fact]
        public void CaculateMargin_WhenInvalidPriceNaN_ShouldReturnException()
        {
            // Arrange
            var priceInput = "NaN";
            var costInput = "99";

            // Act
            var ex = Assert.Throws<ArgumentException>(() => service.CalculateMargin(priceInput, costInput));

            // Assert
            Assert.Equal("The value must be a number", ex.Message);
        }

        [Fact]
        public void CaculateMargin_WhenInvalidCostNaN_ShouldReturnException()
        {
            // Arrange
            var priceInput = "99";
            var costInput = "NaN";

            // Act
            var ex = Assert.Throws<ArgumentException>(() => service.CalculateMargin(priceInput, costInput));

            // Assert
            Assert.Equal("The value must be a number", ex.Message);
        }

        [Fact]
        public void CaculateMargin_WhenInvalidPriceNegetiveNumber_ShouldReturnException()
        {
            // Arrange
            var priceInput = "-10";
            var costIpnut = "99";

            // Act
            var ex = Assert.Throws<ArgumentException>(() => service.CalculateMargin(priceInput, costIpnut));

            // Assert
            Assert.Equal("Value must be equal or greater than zero.", ex.Message);
        }

        [Fact]
        public void CaculateMargin_WhenInvalidCostNegetiveNumber_ShouldReturnException()
        {
            // Arrange
            var priceInput = "99";
            var costIpnut = "-32";

            // Act
            var ex = Assert.Throws<ArgumentException>(() => service.CalculateMargin(priceInput, costIpnut));

            // Assert
            Assert.Equal("Value must be equal or greater than zero.", ex.Message);
        }


    }
}