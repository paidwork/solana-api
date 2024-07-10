using Solnet.Rpc.Builders;
using Solnet.Rpc.Models;
using Solnet.Wallet;

namespace worken_api.Interfaces
{
    public interface IInstructionService
    {
        TransactionInstruction AssociatedTokenAccount(Account payer, PublicKey owner);
        byte[] Build(ref TransactionBuilder transactionBuilder, Account signer);
        TransactionInstruction Burn(Account authority, PublicKey source, ulong amount);
        TransactionBuilder DefaultInstruction(Account feePayer, LatestBlockHash blockHash);
        TransactionInstruction Memo(Account account, string memo);
        TransactionInstruction Transfer(PublicKey FromAssociatedTokenAccount, PublicKey ToAssociatedTokenAccount, ulong LamPorts, PublicKey ownerAccount);
        TransactionInstruction ComputeUnitLimit(uint units);
        TransactionInstruction ComputeUnitPrice(ulong priority_rate);
    }
}