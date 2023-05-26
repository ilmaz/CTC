namespace CTC.Domain.Services.CardToCardService
{
    public interface IPaymentService
    {
        //Bank Identification Number
        string BinChecker(long cardNumber, Dictionary<long, string> bankInfos);
    }
}
