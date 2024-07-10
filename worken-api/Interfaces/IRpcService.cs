using Solnet.Rpc;
using Solnet.Rpc.Models;
using worken_api.Models;

namespace worken_api.Interfaces
{
    public interface IRpcService
    {
        Task<AccountInfo> GetAccountInfo(IRpcClient client, string publicKey);
        IRpcClient GetClient(Cluster client);
        IRpcClient GetClientMainNet();
        IRpcClient GetClientDevNet();
        IRpcClient GetClientTestNet();
        Task<IEnumerable<TokenAccount>> GetTokenAccountsByOwner(IRpcClient client, string ownerPublicKey);
        Task<TransactionResult> SendTransaction(IRpcClient client, string transaction);
        Task<TransactionResult> SendTransaction(IRpcClient client, byte[] transaction);
        Task<SimulationResult> SimulateTransaction(IRpcClient client, byte[] transaction);
        Task<LatestBlockHash> GetRecentBlockHash(IRpcClient client);
        Task<ulong> GetMinimumBalanceForRentExemption(IRpcClient client);
    }
}