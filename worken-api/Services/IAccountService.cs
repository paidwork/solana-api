using Solnet.Wallet;

namespace worken_api.Services
{
    public interface IAccountService
    {
        PublicKey DeriveAssociatedTokenAccount(Account account);
        PublicKey DeriveAssociatedTokenAccount(PublicKey account);
        Account GetAccount(string privateKey, string publicKey);
    }
}