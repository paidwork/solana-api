using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using worken_api.CustomAttributes;

namespace worken_api.Controllers
{
    public class CreateTransactionRequest
    {
        [Required(ErrorMessage = $"{nameof(FromAccountPublicKey)} must be provided")]
        public string FromAccountPublicKey { get; set; }

        [Required(ErrorMessage = $"{nameof(FromAccountPrivateKey)} must be provided")]
        public string FromAccountPrivateKey { get; set; }

        [Required(ErrorMessage = $"{nameof(AssociatedAccountPublicKey)} must be provided")]
        public string AssociatedAccountPublicKey { get; set; }

        [Required(ErrorMessage = $"{nameof(LamPorts)} must be provided")]
        public ulong LamPorts {  get; set; }

        [MaxArrayLength(5)]
        public string[] Memo { get; set; } = new string[] { Guid.NewGuid().ToString() };

        public ulong SolAmount { get; set; } = 0;

    }
}