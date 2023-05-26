using CTC.Domain.Models.PaymentModels;

namespace CTC.Infrastructure.Acl.Payments.Banks
{
    public class SaderatPaymentAclService : IPaymentPanagementAclService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private SaderatPaymentAclService(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;

        public static SaderatPaymentAclService New(IHttpClientFactory httpClientFactory) => new(httpClientFactory);

        public async Task<Payment> Payment(Payment payment)
        {
            await Task.Delay(1000);

            payment.SetResponce(100, "", "456ddf", 638205532192726284);

            return payment;
        }
    }
}
