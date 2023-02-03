using B3.FixedIncome.Domain.Commands;
using B3.FixedIncome.Domain.Commands.Helpers;
using B3.FixedIncome.Domain.Repositories;
using Flunt.Notifications;
using MediatR;

namespace B3.FixedIncome.Domain.Handlers
{
    public class CalculateCdbCommandHandler : Notifiable<Notification>, IRequestHandler<CalculateCdbCommand, GenericCommandResult>
    {

        private readonly ICdbRepository _CDBRepository;

        public CalculateCdbCommandHandler(ICdbRepository CDBRepository)
        {
            this._CDBRepository = CDBRepository;
        }

        public async Task<GenericCommandResult> Handle(CalculateCdbCommand command, CancellationToken cancellationToken)
        {
            command.Validate();

            if (!command.IsValid)
                return new GenericCommandResult(false, "Problemas na validação da requisição", command.Notifications);

            var cdbValue = CdbCalculator.GetAcumulatedCDBValue(command.Months, command.InitialValue);

            var monthRateTask = Task.Run(() => this._CDBRepository.GetMonthRateByMonthQty(command.Months));
            var monthRate = await monthRateTask;

            if (monthRate == null)
                return new GenericCommandResult(success: false, message: "Problemas na configuração do CDB");

            var cdbResponde = CdbCalculator.CalculateFinalValue(monthRate.Rate, cdbValue);

            return new GenericCommandResult(true, "Sucesso", cdbResponde);
        }
    }
}
