using B3.FixedIncome.Domain.Commands.Helpers;
using Flunt.Notifications;
using MediatR;

namespace B3.FixedIncome.Domain.Commands
{
    public class CalculateCdbCommand : Notifiable<Notification>, IRequest<GenericCommandResult>
    {
        /// <summary>
        /// Valor inicial
        /// </summary>        
        public double InitialValue { get; set; }

        /// <summary>
        /// Meses
        /// </summary>
        public int Months { get; set; }

        public void Validate()
        {
            if (Months <= 1)
                AddNotification(new Notification("Months", "Mês deve ser maior 1"));

            if (InitialValue <= 0)
                AddNotification(new Notification("InitialValue", "Informe um valor inicial válido"));
        }
    }
}
