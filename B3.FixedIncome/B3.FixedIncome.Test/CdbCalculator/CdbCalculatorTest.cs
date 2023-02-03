using B3.FixedIncome.Domain.Model;
using Xunit;
using Calculator = B3.FixedIncome.Domain.Commands.Helpers.CdbCalculator;

namespace B3.FixedIncome.Test.CdbCalculator
{
    public class CdbCalculatorTest
    {
        [Theory]
        [InlineData(10, 10.097)]
        public void Given_Greater_Than_Value_When_Call_CalculateCDB_Then_Return_FinalValue(double initialValue, double finalValue)
        {
            var cdbValue = Calculator.CalculateCDB(initialValue);

            // Assert
            Assert.Equal(finalValue, cdbValue, 2);

        }

        [Theory]
        [InlineData(12, 14, 169.63)]
        public void Given_Acumulated_value_When_Call_GetAcumulatedCDBValue_Then_Return_FinalValue(int month, double initialValue, double finalValue)
        {
            var cdbValue = Calculator.GetAcumulatedCDBValue(month, initialValue);

            // Assert
            Assert.Equal(finalValue, cdbValue, 2);

        }

        [Theory]
        [InlineData(50, 70, 35)]
        public void When_Call_CalculateFinalValue_Then_Return_CdbCalculetedDto(double rate, double grossValue, double netValue)
        {
            var calculatedDto = Calculator.CalculateFinalValue(rate, grossValue);

            // Assert
            Assert.NotNull(calculatedDto);
            Assert.Equal(calculatedDto.GrossValue, grossValue, 2);
            Assert.Equal(calculatedDto.NetValue, netValue, 2);

        }
    }
}
