using Microsoft.AspNetCore.Mvc;
using Solnet.Wallet.Bip39;
using System.ComponentModel.DataAnnotations;
using worken_api.Interfaces;
using worken_api.Models;

namespace worken_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : Controller
    {
        private readonly IWalletService walletService;

        public WalletController(IWalletService walletService)
        {
            this.walletService = walletService;
        }

        [HttpPost("CreateWallet")]
        public async Task<IActionResult> CreateWallet()
        {
            var wallet = walletService.CreateWallet();

            return Json(wallet);
        }

        [HttpPost("CreateWalletWordCount")]
        public async Task<IActionResult> CreateWallet(
            [FromBody][RegularExpression(@"^(12|15|18|21|24)$", ErrorMessage = "Value must be equal to 12, 15, 18, 21, or 24")] int wordCount = 12 )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var wallet = walletService.CreateWallet((WordCount)wordCount);

            return Json(wallet);
        }

        [HttpPost("CreateWalletWordList")]
        public async Task<IActionResult> CreateWallet(
            [FromBody][AllowedValues("English", "Japanese", "ChineseSimplified", "ChineseTraditional", "Spanish", "French", "PortugueseBrazil", "Czech")] string wordList = "English")
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            WordList words = walletService.ConvertStringToWordList(wordList);

            var wallet = walletService.CreateWallet(words);

            return Json(wallet);
        }

        [HttpPost("CreateWalletFull")]
        public async Task<IActionResult> CreateWallet([FromBody] WalletCreationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            WordList words = walletService.ConvertStringToWordList(request.WordList);

            var wallet = walletService.CreateWallet((WordCount)request.WordCount, words);

            return Json(wallet);
        }
    }
}
