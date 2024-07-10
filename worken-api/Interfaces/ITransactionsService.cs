using Solnet.Rpc.Models;
using Solnet.Wallet;

namespace worken_api.Interfaces
{
    public interface ITransactionsService
    {
        Task<byte[]> CreateTransaction(Account from, PublicKey to, LatestBlockHash blockHash, ulong LamPorts, string[] memo, ulong solAmount);
        Task<byte[]> CreateTransactionAndBurn(Account from, PublicKey to, LatestBlockHash blockHash, ulong LamPorts, ulong LamPortsBurn, string[] memo, ulong solAmount);
        Task<byte[]> CreateBurn(Account authority, LatestBlockHash blockHash, ulong amount, string[] memo);
    }
}