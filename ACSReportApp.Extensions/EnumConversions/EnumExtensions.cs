using ACSReportApp.Models.Enums;

namespace ACSReportApp.Extensions.EnumConversions
{
    namespace ACSReportApp.Extensions
    {
        public static class EnumExtensions
        {
            public static char ToChar(this CableDelimiter delimiter)
            {
                return delimiter switch
                {
                    CableDelimiter.Colors => 'x',
                    CableDelimiter.Numbers => 'G',
                    CableDelimiter.Grounding => '+',
                    _ => throw new ArgumentOutOfRangeException(nameof(delimiter), delimiter, null)
                };
            }

            public static char? ToNullableChar(this CableDelimiter? delimiter)
            {
                return delimiter?.ToChar();
            }
        }
    }

}
