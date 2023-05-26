namespace CTC.Domain.Models.PaymentModels
{
    public class Payment : Entity<int>
    {
        public long SourceCard { get; }

        public long TargetCard { get; }

        public int Ccv2 { get; }

        public DateTime ExpireDate { get; }

        public long PhoneNumber { get; }

        public int StatusCode { get; private set; }

        public string Description { get; private set; }

        public string Digital { get; private set; }

        public long TransactionId { get; private set; }


        private Payment() { }

        private Payment(long sourceCard, long targetCard, int ccv2, DateTime expireDate, long phoneNumber)
        {
            CheckCardSize(sourceCard, "شماره کارت مبدا صحیح نمی باشد");
            CheckCardSize(targetCard, "شماره کارت مقصد صحیح نمی باشد");
            CheckSourceCardIsEqualTargetCard(sourceCard, targetCard);



            SourceCard = sourceCard;
            TargetCard = targetCard;
            Ccv2 = ccv2;
            ExpireDate = expireDate;
            PhoneNumber = phoneNumber;
        }

        public static Payment SetCartInfo(long sourceCard, long targetCard, int ccv2, DateTime expireDate, long phoneNumber) =>
            new(sourceCard, targetCard, ccv2, expireDate, phoneNumber);


        public void SetResponce(int statusCode, string description, string digital, long transactionId)
        {
            StatusCode = statusCode;
            Description = description;
            Digital = digital;
            TransactionId = transactionId;
        }


        private void CheckCardSize(long cardNumber, string message)
        {
            if (Math.Floor(Math.Log10(cardNumber) + 1) != 16)
            {
                throw new Exception(message);
            }
        }

        private void CheckSourceCardIsEqualTargetCard(long sourceCard, long targetCard)
        {
            if (sourceCard == targetCard)
                throw new Exception("کارت مبدا و مقصد نمی تواند یکی باشد");
        }
    }
}
