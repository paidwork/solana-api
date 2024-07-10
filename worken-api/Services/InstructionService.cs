using Solnet.Programs;
using Solnet.Programs.Utilities;
using Solnet.Rpc.Builders;
using Solnet.Rpc.Models;
using Solnet.Wallet;
using worken_api.Interfaces;

namespace worken_api.Services
{
    public class InstructionService : IInstructionService
    {
        public InstructionService() { }

        public TransactionBuilder DefaultInstruction(Account feePayer, LatestBlockHash blockHash)
        {
            return new TransactionBuilder()
                .SetRecentBlockHash(blockHash.Blockhash)
                .SetFeePayer(feePayer);
        }

        public TransactionInstruction AssociatedTokenAccount(Account payer, PublicKey owner)
        {
            return AssociatedTokenAccountProgram.CreateAssociatedTokenAccount(
                    payer,
                    owner,
                    Program.WorkenMintPublicKey);
        }

        #region Temp
        /// <summary>
        /// The public key of the ComputeBudget Program.
        /// </summary>
        private static readonly PublicKey ProgramIdKey = new("ComputeBudget111111111111111111111111111111");

        /// <summary>
        /// The program's name.
        /// </summary>
        private const string ProgramName = "Compute Budget Program";
        public TransactionInstruction ComputeUnitLimit(uint units)
        {
            List<AccountMeta> keys = new();

            byte[] instructionBytes = new byte[9];
            instructionBytes.WriteU8(2, 0);
            instructionBytes.WriteU64(units, 1);

            return new TransactionInstruction
            {
                ProgramId = ProgramIdKey.KeyBytes,
                Keys = keys,
                Data = instructionBytes
            };
        }
        /// <summary>
        /// Set Compute Unit Price Instruction for Priority Fees
        /// </summary>
        /// <param name="priority_rate"></param>
        /// <returns></returns>
        public TransactionInstruction ComputeUnitPrice(ulong priority_rate)
        {
            List<AccountMeta> keys = new();

            byte[] instructionBytes = new byte[9];
            instructionBytes.WriteU8(3, 0);
            instructionBytes.WriteU64(priority_rate, 1);

            return new TransactionInstruction
            {
                ProgramId = ProgramIdKey.KeyBytes,
                Keys = keys,
                Data = instructionBytes
            };
        } 
        #endregion

        public TransactionInstruction Memo(Account account, string memo)
        {
            return MemoProgram.NewMemo(account, memo);
        }

        public TransactionInstruction Transfer(PublicKey FromAssociatedTokenAccount, PublicKey ToAssociatedTokenAccount, ulong LamPorts, PublicKey ownerAccount)
        {
            return TokenProgram.Transfer(
                 FromAssociatedTokenAccount,
                 ToAssociatedTokenAccount,
                 LamPorts,
                 ownerAccount);
        }

        public TransactionInstruction Burn(Account authority, PublicKey source, ulong amount)
        {
            return TokenProgram.Burn(
                        source,
                        Program.WorkenMintPublicKey,
                        amount,
                        authority);
        }

        public byte[] Build(ref TransactionBuilder transactionBuilder, Account signer)
        {
            return transactionBuilder.Build(signer);
        }
    }
}
