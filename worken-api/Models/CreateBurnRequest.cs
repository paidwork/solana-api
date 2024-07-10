using System.ComponentModel.DataAnnotations;
using worken_api.CustomAttributes;

namespace worken_api.Models
{
    public class CreateBurnRequest
    {
        [Required(ErrorMessage = $"{nameof(FromAccountPublicKey)} must be provided")]
        public string FromAccountPublicKey { get; set; }

        [Required(ErrorMessage = $"{nameof(FromAccountPrivateKey)} must be provided")]
        public string FromAccountPrivateKey { get; set; }

        [Required(ErrorMessage = $"{nameof(FromAccountPrivateKey)} must be provided")]
        public ulong Amount { get; set; }

        [MaxArrayLength(5)]
        public string[] Memo { get; set; } = new string[] { Guid.NewGuid().ToString() };
    }
}