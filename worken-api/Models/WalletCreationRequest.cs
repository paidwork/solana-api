using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace worken_api.Models
{
    public class WalletCreationRequest
    {
        [FromBody]
        [AllowedValues("English", "Japanese", "ChineseSimplified", "ChineseTraditional", "Spanish", "French", "PortugueseBrazil", "Czech")]
        public string WordList { get; set; } = "English";

        [FromBody]
        [RegularExpression(@"^(12|15|18|21|24)$", ErrorMessage = "Value must be equal to 12, 15, 18, 21, or 24")]
        public int WordCount { get; set; } = 12;
    }
}
