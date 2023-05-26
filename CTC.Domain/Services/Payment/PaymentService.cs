namespace CTC.Domain.Services.CardToCardService
{
    public class PaymentService : IPaymentService
    {
        public string BinChecker(long cardNumber, Dictionary<long, string> bankInfoDic)
        {
            cardNumber = BinParser(cardNumber);

            bankInfoDic.TryGetValue(cardNumber, out string bankInfo);

            return bankInfo ?? "";
        }

        private int BinParser(long cardNumber) => int.Parse(cardNumber.ToString()[..6]);

    }
}
