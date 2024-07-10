using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Solnet.Rpc;
using Solnet.Rpc.Models;
using Solnet.Wallet;
using System.Collections;
using worken_api.Interfaces;
using worken_api.Models;

namespace worken_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : Controller
    {
        private readonly IRpcService rpcService;
        private readonly ITransactionsService transactionsService;

        public TransactionsController(IRpcService rpcService, ITransactionsService transactionsService )
        {
            this.rpcService = rpcService;
            this.transactionsService = transactionsService;
        }

        #region Transaction
        [HttpPost("CreateTransactionToAssociatedAccount")]
        public async Task<IActionResult> CreateTransaction([FromBody] CreateTransactionRequest transactionRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var client = rpcService.GetClientMainNet();
            var blockHash = await rpcService.GetRecentBlockHash(client);

            Account fromAccount = new(transactionRequest.FromAccountPrivateKey, transactionRequest.FromAccountPublicKey);
            PublicKey toAccount = new PublicKey(transactionRequest.AssociatedAccountPublicKey);

            var transactionData = await transactionsService.CreateTransaction(fromAccount, toAccount, blockHash, transactionRequest.LamPorts, transactionRequest.Memo, transactionRequest.SolAmount);

            var transactionHash = await rpcService.SendTransaction(client, transactionData);

            if (transactionHash.Exception != null) return BadRequest(transactionHash.Exception);

            return Json(transactionHash.Result);
        }

        [HttpPost("SimulateTransactionToAssociatedAccount")]
        public async Task<IActionResult> SimulateTransaction([FromBody] CreateTransactionRequest transactionRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var client = rpcService.GetClientMainNet();
            var blockHash = await rpcService.GetRecentBlockHash(client);

            Account fromAccount = new(transactionRequest.FromAccountPrivateKey, transactionRequest.FromAccountPublicKey);
            PublicKey toAccount = new PublicKey(transactionRequest.AssociatedAccountPublicKey);

            var transactionData = await transactionsService.CreateTransaction(fromAccount, toAccount, blockHash, transactionRequest.LamPorts, transactionRequest.Memo, transactionRequest.SolAmount);

            var transactionHash = await rpcService.SimulateTransaction(client, transactionData);

            if (transactionHash.Exception != null) return BadRequest(transactionHash.Exception);

            return Json(transactionHash.Result);
        }
        #endregion

        #region Transaction With Burn
        [HttpPost("CreateTransactionWithBurnToAssociatedAccount")]
        public async Task<IActionResult> CreateTransactionWithBurn([FromBody] CreateTransactionBurnRequest transactionRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var client = rpcService.GetClientMainNet();
            var blockHash = await rpcService.GetRecentBlockHash(client);

            Account fromAccount = new(transactionRequest.FromAccountPrivateKey, transactionRequest.FromAccountPublicKey);
            PublicKey toAccount = new PublicKey(transactionRequest.AssociatedAccountPublicKey);

            var transactionData = await transactionsService.CreateTransactionAndBurn(fromAccount, toAccount, blockHash, transactionRequest.LamPorts, transactionRequest.LamPortsBurn, transactionRequest.Memo, transactionRequest.SolAmount);

            var transactionHash = await rpcService.SendTransaction(client, transactionData);

            if (transactionHash.Exception != null) return BadRequest(transactionHash.Exception);

            return Json(transactionHash.Result);
        }

        [HttpPost("SimulateTransactionWithBurnToAssociatedAccount")]
        public async Task<IActionResult> SimulateTransactionWithBurn([FromBody] CreateTransactionBurnRequest transactionRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var client = rpcService.GetClientMainNet();
            var blockHash = await rpcService.GetRecentBlockHash(client);

            Account fromAccount = new(transactionRequest.FromAccountPrivateKey, transactionRequest.FromAccountPublicKey);
            PublicKey toAccount = new PublicKey(transactionRequest.AssociatedAccountPublicKey);

            var transactionData = await transactionsService.CreateTransactionAndBurn(fromAccount, toAccount, blockHash, transactionRequest.LamPorts, transactionRequest.LamPortsBurn, transactionRequest.Memo, transactionRequest.SolAmount);

            var transactionHash = await rpcService.SimulateTransaction(client, transactionData);

            if (transactionHash.Exception != null) return BadRequest(transactionHash.Exception);

            return Json(transactionHash.Result);
        } 
        #endregion

        [HttpPost("Burn")]
        public async Task<IActionResult> CreateBurn([FromBody] CreateBurnRequest burnRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var client = rpcService.GetClientMainNet();
            var blockHash = await rpcService.GetRecentBlockHash(client);

            Account fromAccount = new(burnRequest.FromAccountPrivateKey, burnRequest.FromAccountPublicKey);

            var transactionData = await transactionsService.CreateBurn(fromAccount,blockHash, burnRequest.Amount, burnRequest.Memo);
            var transactionHash = await rpcService.SendTransaction(client, transactionData);

            if (transactionHash.Exception != null) return BadRequest(transactionHash.Exception);

            return Content(transactionHash.Result);
        }

        [HttpPost("SimulateBurn")]
        public async Task<IActionResult> SimulateBurn([FromBody] CreateBurnRequest burnRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var client = rpcService.GetClientMainNet();
            var blockHash = await rpcService.GetRecentBlockHash(client);

            Account fromAccount = new(burnRequest.FromAccountPrivateKey, burnRequest.FromAccountPublicKey);

            var transactionData = await transactionsService.CreateBurn(fromAccount, blockHash, burnRequest.Amount, burnRequest.Memo);
            var transactionHash = await rpcService.SimulateTransaction(client, transactionData);

            if (transactionHash.Exception != null) return BadRequest(transactionHash.Exception);

            return Json(transactionHash.Result);
        }
    }
}
