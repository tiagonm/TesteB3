using B3.FixedIncome.Domain.Commands;
using B3.FixedIncome.Domain.DTO;
using B3.FixedIncome.Domain.Handlers;
using B3.FixedIncome.Domain.Model;
using B3.FixedIncome.Domain.Repositories;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace B3.FixedIncome.Test.Handlers
{
    public class CalculateCdbCommandHandlerTest
    {
        [Theory]
        [InlineData(93.91,121.17)]
        public async Task Given_CalculateCdbCommand_When_Call_CalculateCdbCommandHandler_Then_Return_Valid_CdbCalculetedDto(double netValue,double grossValue)
        {
            var mockRepo = new Mock<ICdbRepository>();
            mockRepo.Setup(repo => repo.GetMonthRateByMonthQty(6))
                .Returns(GetMonthRateByMonthQty());

            CalculateCdbCommand command = new()
            {
                Months = 6,
                InitialValue = 20
            };

            CalculateCdbCommandHandler handler = new(mockRepo.Object);

            var response = await handler.Handle(command, new System.Threading.CancellationToken());

            //Assert
            Assert.NotNull(response);
            Assert.True(response.Success);
            Assert.NotNull(response.Data);
            Assert.Equal(((CdbCalculetedDto)response.Data).NetValue, netValue,2);
            Assert.Equal(((CdbCalculetedDto)response.Data).GrossValue, grossValue,2);
        }

        private static CdbMonthRates GetMonthRateByMonthQty()
        {
            return new CdbMonthRates { MinMonth = 6, Rate = 22.5 };
        }
    }
}
