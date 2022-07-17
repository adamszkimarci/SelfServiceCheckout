namespace SelfServiceCheckout.Models.Enums
{
    public class HufDenomination
    {
        public enum HufDenominations
        {
            [Description("5")]
            Five = 5,
            [Description("10")]
            Ten = 10,
            [Description("20")]
            Twenty = 20,
            [Description("50")]
            Fifty = 50,
            [Description("100")]
            OneHundred = 100,
            [Description("200")]
            TwoHundred = 200,
            [Description("500")]
            FiveHundred = 500,
            [Description("1000")]
            OneThousand = 1000,
            [Description("2000")]
            TwoThousand = 2000,
            [Description("5000")]
            FiveThousand = 5000,
            [Description("10000")]
            TenThousand = 10000,
            [Description("20000")]
            TwentyThousand = 20000
        }
    }
}
