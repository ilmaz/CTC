using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace CTC.Application.PaymentCommand.DTO
{
    public class PaymentDTO
    {
        [Required(ErrorMessage = "کارت مبدا اجباری می باشد")]
        public long SourceCard { get; set; }

        [Required(ErrorMessage = "کارت مقصد اجباری می باشد")]
        public long TargetCard { get; set; }

        [Required(ErrorMessage = "CCv2 اجباری می باشد")]
        public int Ccv2 { get; set; }

        [Required(ErrorMessage = "ماه اجباری می باشد")]
        public int Month { get; set; }


        [Required(ErrorMessage = "سال اجباری می باشد")]
        public int Year { get; set; }

        public long PhoneNumber { get; set; }

        public DateTime GetGregorian()
        {
            Year = Year == 0 ? 1401 : Year;
            Month = Month == 0 ? 1 : Month;
            //TODO:استعلام سال انقضا کارت از سرویس گرفته شود
            return DateTime.Parse($"{Year}/{Month}/01", new CultureInfo("fa-IR"));
        }
    }

}
