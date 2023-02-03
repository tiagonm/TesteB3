using B3.FixedIncome.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace B3.FixedIncome.Test.Commands
{
    public class CalculateCdbCommandTest
    {
        [Fact]
        public void Given_Valid_InitalValue_When_Call_Valid_Then_Return_Valid()
        {
            var command = new CalculateCdbCommand
            {
                InitialValue = 10,
                Months = 6
            };

            command.Validate();

            // Assert
            Assert.True(command.IsValid);
        }

        [Fact]
        public void Given_Invalid_InitalValue_When_Call_Valid_Then_Return_Invalid()
        {
            var command = new CalculateCdbCommand
            {
                InitialValue = -1,
                Months = 6
            };

            command.Validate();

            // Assert
            Assert.False(command.IsValid);
        }


        [Fact]
        public void Given_Invalid_Months_When_Call_Valid_Then_Return_Invalid()
        {
            var command = new CalculateCdbCommand
            {
                InitialValue = 10,
                Months = 1
            };

            command.Validate();

            // Assert
            Assert.False(command.IsValid);
        }
    }
}
