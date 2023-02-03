using B3.FixedIncome.Domain.Model;

namespace B3.FixedIncome.Domain.Repositories
{
    public interface ICdbRepository
    {
        CdbMonthRates GetMonthRateByMonthQty(int monthsCommited);
    }
}
