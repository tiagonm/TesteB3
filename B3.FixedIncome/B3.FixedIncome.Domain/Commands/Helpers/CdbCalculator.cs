using B3.FixedIncome.Domain.DTO;

namespace B3.FixedIncome.Domain.Commands.Helpers
{
    public static class CdbCalculator
    {
        const double CDI = 0.009;
        const double TB = 1.08;

        public static double GetAcumulatedCDBValue(int months, double initialValue)
        {
            double cdbValue = 0;
            for (int i = 0; i < months; i++)
            {
                cdbValue += CalculateCDB(initialValue);
            }
            return Math.Round(cdbValue, 2);
        }

        public static double CalculateCDB(double value)
        {
            return value * (1 + (CDI * TB));
        }

        public static CdbCalculetedDto CalculateFinalValue(double rate, double cdbValue)
        {
            var cdbResponse = new CdbCalculetedDto
            {
                GrossValue = cdbValue,
                NetValue = Math.Round(cdbValue * ((100 - rate) / 100), 2)
            };

            return cdbResponse;
        }
    }
}
