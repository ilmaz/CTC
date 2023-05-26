using CTC.Domain.Services.CardToCardService;
using FluentAssertions;

namespace CTC.Tests.Unit.Domain.Services
{
    public class PaymentServiceTests
    {
        private readonly Dictionary<long, string> _bankInfoDic;
        public PaymentServiceTests()
        {
            _bankInfoDic = new Dictionary<long, string>()
                        {
                        {610433, "Mellat"},
                        {603769, "Saderat"},
                        {636214, "Ayandeh"}
                        };
        }

        [Fact]
        public void Check_the_name_of_cardNumber()
        {
            var cardNumber = 6104331234456791;
            var result = "mellat";

            var mut = new PaymentService().BinChecker(cardNumber, _bankInfoDic);

            mut.ToLower().Should().Be(result);
        }
    }
}
