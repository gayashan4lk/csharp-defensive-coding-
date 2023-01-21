using ACME.WEB.ControllerServices;

namespace ACME.WEB.Test
{
    public class PriceControllerTest
    {
        [Fact]
        public void CaculateMargin_WhenInvalidNonNumber_ShouldReturnException()
        {
            // Arrange
            var priceInput = "NaN";
            var costInput = "NaN";
            var service = new ProductControllerService();

            // Act
            var ex = Assert.Throws<ArgumentException>(() => service.CalculateMargin(priceInput, costInput));

            // Assert
            Assert.Equal("The value must be a number", ex.Message);
        }
    }
}