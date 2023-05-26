using CTC.Application.PaymentCommand.DTO;
using CTC.Domain.Models.PaymentModels;
using CTC.Domain.Services.CardToCardService;
using Microsoft.Extensions.Configuration;

namespace CTC.Application.PaymentCommand
{
    public class PaymentCommandHandler : IPaymentCommand
    {
        private readonly IConfiguration _configuration;
        private readonly IPaymentService _paymentService;
        private readonly IPaymentManagementFactory _paymentManagementFactory;

        public PaymentCommandHandler(IConfiguration configuration, IPaymentService paymentService,
            IPaymentManagementFactory paymentManagementFactory)
        {
            _configuration = configuration;
            _paymentService = paymentService;
            _paymentManagementFactory = paymentManagementFactory;
        }

        public async Task<long> Handle(PaymentDTO command)
        {
            var bankInfoConfig = GetPaymentParameters();

            var payment = Payment.SetCartInfo(command.SourceCard, command.TargetCard, command.Ccv2, command.GetGregorian(), command.PhoneNumber);

            var bankName = _paymentService.BinChecker(command.SourceCard, bankInfoConfig);

            var paymentPanagement = _paymentManagementFactory.GetInstance(bankName);

            var model = await paymentPanagement.Payment(payment);


            return model.TransactionId;
        }

        private Dictionary<long, string> GetPaymentParameters() => _configuration.GetSection("BankInfoConfig")
            .GetChildren()
             .ToDictionary(x => long.Parse(x.Key), x => x.Value);
    }
}