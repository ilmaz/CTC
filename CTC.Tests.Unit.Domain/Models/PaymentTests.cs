using CTC.Domain.Models.PaymentModels;
using FluentAssertions;

namespace CTC.Tests.Unit.Domain.Models
{
    public class PaymentTests
    {
        private readonly Payment _payment;
        private long _sourceCard;
        private long _targetCard;
        private readonly int _ccv2;
        private readonly DateTime _expireDate;
        private readonly long _phoneNumber;

        public PaymentTests()
        {
            _sourceCard = 6104331234456791;
            _targetCard = 6104331234456792;
            _ccv2 = 123;
            _expireDate = DateTime.Now;
            _phoneNumber = 9121237856235;


            _payment = Payment.SetCartInfo(_sourceCard, _targetCard, _ccv2, _expireDate, _phoneNumber);
        }

        [Fact]
        public void SetCartInfo_is_set_correctly()
        {

            _payment.SourceCard.Should().Be(_sourceCard);
            _payment.TargetCard.Should().Be(_targetCard);
            _payment.Ccv2.Should().Be(_ccv2);
            _payment.ExpireDate.Should().Be(_expireDate);
            _payment.PhoneNumber.Should().Be(_phoneNumber);
        }

        [Fact]
        public void SetResponce_is_set_correctly()
        {
            var statusCode = 100;
            var description = "test1";
            var digital = "B9872BAFF18924B1";
            var transactionId = 1684671604613989817;

            var _payment = Payment.SetCartInfo(_sourceCard, _targetCard, _ccv2, _expireDate, _phoneNumber);
            _payment.SetResponce(statusCode, description, digital, transactionId);


            _payment.StatusCode.Should().Be(statusCode);
            _payment.Description.Should().Be(description);
            _payment.Digital.Should().Be(digital);
            _payment.TransactionId.Should().Be(transactionId);
        }

        [Fact]
        public void Check_the_incorrect_sourceCard()
        {
            _sourceCard = 0;

            Action sut = () =>
            {
                Payment.SetCartInfo(_sourceCard, _targetCard, _ccv2, _expireDate, _phoneNumber);
            };

            sut.Should().Throw<Exception>();

        }

        [Fact]
        public void Check_the_incorrect_targetCard()
        {
            _targetCard = 0;

            Action sut = () =>
            {
                Payment.SetCartInfo(_sourceCard, _targetCard, _ccv2, _expireDate, _phoneNumber);
            };

            sut.Should().Throw<Exception>();

        }

        [Fact]
        public void Check_sourceCard_is_equal_targetCard()
        {
            _targetCard = 6104331234456791;

            Action sut = () =>
            {
                Payment.SetCartInfo(_sourceCard, _targetCard, _ccv2, _expireDate, _phoneNumber);
            };

            sut.Should().Throw<Exception>();

        }
    }
}
