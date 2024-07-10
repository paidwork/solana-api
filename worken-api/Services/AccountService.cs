using Solnet.Programs;
using Solnet.Wallet;

namespace worken_api.Services
{
    public class AccountService : IAccountService
    {
        public AccountService() { }

        public PublicKey DeriveAssociatedTokenAccount(Account account)
        {
            return AssociatedTokenAccountProgram.DeriveAssociatedTokenAccount(account, Program.WorkenMintPublicKey);
        }
        
        public PublicKey DeriveAssociatedTokenAccount(PublicKey account)
        {
            return AssociatedTokenAccountProgram.DeriveAssociatedTokenAccount(account, Program.WorkenMintPublicKey);
        }

        public Account GetAccount(string privateKey, string publicKey)
        {
            return new(privateKey, publicKey);
        }
    }
}
