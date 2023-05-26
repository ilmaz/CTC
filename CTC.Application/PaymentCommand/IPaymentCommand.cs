using CTC.Application.PaymentCommand.DTO;

namespace CTC.Application.PaymentCommand
{
    public interface IPaymentCommand
    {
        Task<long> Handle(PaymentDTO command);
    }
}