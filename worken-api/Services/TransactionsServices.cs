using Solnet.Programs;
using Solnet.Rpc;
using Solnet.Rpc.Builders;
using Solnet.Rpc.Models;
using Solnet.Wallet;
using System.Security.Principal;
using worken_api.Interfaces;

namespace worken_api.Services
{
    public class TransactionsServices : ITransactionsService
    {
        private readonly IAccountService accountService;
        private readonly IInstructionService instructionService;
        private readonly IRpcService rpcService;

        public TransactionsServices(IAccountService accountService, IInstructionService instructionService, IRpcService rpcService)
        {
            this.accountService = accountService;
            this.instructionService = instructionService;
            this.rpcService = rpcService;
        }

        public async Task<byte[]> CreateTransaction(Account ownerAccount, PublicKey to, LatestBlockHash blockHash, ulong LamPorts, string[] memo, ulong solAmount)
        {
            //get associated acounts
            var FromAssociatedTokenAccount = accountService.DeriveAssociatedTokenAccount(ownerAccount);
            var ToAssociatedTokenAccount = accountService.DeriveAssociatedTokenAccount(to);

            //create initial transaction
            var transaction = instructionService.DefaultInstruction(ownerAccount, blockHash);

            transaction.AddInstruction(instructionService.ComputeUnitLimit(200000));
            transaction.AddInstruction(instructionService.ComputeUnitPrice(300000));

            //add instruction if receiver doesnt have associated account
            if (ToAssociatedTokenAccount == null)
                transaction.AddInstruction(instructionService.AssociatedTokenAccount(ownerAccount, to));

            //add transfer instruction
            transaction.AddInstruction(instructionService.Transfer(
                 FromAssociatedTokenAccount,
                 ToAssociatedTokenAccount,
                 LamPorts,
                 ownerAccount));

            //add memo
            if (memo.Length > 0)
                foreach (var content in memo)
                    transaction.AddInstruction(instructionService.Memo(ownerAccount, content));

            if(solAmount > 0)
            {
                var client = rpcService.GetClientMainNet();

                var minimumRent = await rpcService.GetMinimumBalanceForRentExemption(client);

                if (solAmount < minimumRent)
                    throw new Exception("SOL Amount is less than minimum rent.");

                transaction.AddInstruction(instructionService.Transfer(
                     ownerAccount,
                     to,
                     LamPorts,
                     ownerAccount));
            }


            //build and return
            return transaction.Build(new List<Account> { ownerAccount });
        }

        public async Task<byte[]> CreateBurn(Account authority, LatestBlockHash blockHash, ulong amount, string[] memo)
        {
            //get source
            var source = accountService.DeriveAssociatedTokenAccount(authority);

            //create default transaction with fee payer and blockhash
            var transaction = instructionService.DefaultInstruction(authority, blockHash);

            //add burn instruction
            transaction.AddInstruction(instructionService.Burn(authority,
                        source,
                        amount));

            //add memo
            if (memo.Length > 0)
                foreach (var content in memo)
                    transaction.AddInstruction(instructionService.Memo(authority, content));

            //build
            return instructionService.Build(ref transaction, authority);
        }

        public async Task<byte[]> CreateTransactionAndBurn(Account ownerAccount, PublicKey to, LatestBlockHash blockHash, ulong LamPorts,ulong LamPortsBurn, string[] memo, ulong solAmount)
        {
            //get associated acounts
            var FromAssociatedTokenAccount = accountService.DeriveAssociatedTokenAccount(ownerAccount);
            var ToAssociatedTokenAccount = accountService.DeriveAssociatedTokenAccount(to);

            //create initial transaction
            var transaction = instructionService.DefaultInstruction(ownerAccount, blockHash);

            transaction.AddInstruction(instructionService.ComputeUnitLimit(200000));
            transaction.AddInstruction(instructionService.ComputeUnitPrice(300000));

            //add instruction if receiver doesnt have associated account
            if (ToAssociatedTokenAccount == null)
                transaction.AddInstruction(instructionService.AssociatedTokenAccount(ownerAccount, to));

            //add transfer instruction
            transaction.AddInstruction(instructionService.Transfer(
                 FromAssociatedTokenAccount,
                 ToAssociatedTokenAccount,
                 LamPorts,
                 ownerAccount));

            //add burn instruction
            transaction.AddInstruction(instructionService.Burn(ownerAccount,
                        FromAssociatedTokenAccount,
                        LamPortsBurn));

            if (memo.Length > 0)
                foreach (var content in memo)
                    transaction.AddInstruction(instructionService.Memo(ownerAccount, content));

            //build and return
            return transaction.Build(new List<Account> { ownerAccount });
        }
    }
}
