using B3.FixedIncome.Domain.Model;
using B3.FixedIncome.Domain.Repositories;

namespace B3.FixedIncome.Infra.Repositories
{
    public class CdbRepository : ICdbRepository
    {
        private readonly List<CdbMonthRates> MonthRates;
        public CdbRepository()
        {
            this.MonthRates = new List<CdbMonthRates>
                                {
                                    new CdbMonthRates{ MinMonth=6, Rate=22.5 },
                                    new CdbMonthRates{ MinMonth=12, Rate=20 },
                                    new CdbMonthRates{ MinMonth=24, Rate=17.5 },
                                    new CdbMonthRates{ MinMonth=25, Rate=15 }
                                };
        }
        

        public CdbMonthRates GetMonthRateByMonthQty(int monthsCommited)
        {
            var monthRate = this.MonthRates.LastOrDefault(d => d.MinMonth <= monthsCommited);
            return monthRate;
        }
    }
}
