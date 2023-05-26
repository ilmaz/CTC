using CTC.Domain.Models.PaymentModels;

namespace CTC.Infrastructure.Acl.Payments.Banks
{
    public class AyandehPaymentAclService : IPaymentPanagementAclService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private AyandehPaymentAclService(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;

        public static AyandehPaymentAclService New(IHttpClientFactory httpClientFactory) => new(httpClientFactory);
        public async Task<Payment> Payment(Payment payment)
        {
            await Task.Delay(1000);

            payment.SetResponce(100, "", "123ddf", 638205532192726284);

            return payment;
        }
    }
}
