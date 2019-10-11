using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IslbTransfers.CustomAttributes;
using Microsoft.AspNetCore.Mvc;
using Model.Models;
using Service.Services;

namespace IslbTransfers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(SessionAuthorizeAttribute))]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly IAccountService _accountService;

        public TransactionController(ITransactionService transactionService, IAccountService accountService)
        {
            _transactionService = transactionService;
            _accountService = accountService;
        }

        // METHOD USED FOR REGISTERING THE PAYPAL EXCHANGE TRANSACTION
        [HttpPost]
        [Route("paypal_create_exchange")]
        public async Task<IActionResult> CreatePayPalExchangeTransaction(ExchangeTransaction transaction)
        {
            if (transaction == null) return BadRequest(new ResponseMessage()
            { Duration = 10000, Message = "Something went wrong with your transaction", Type = ResponseMessage.ResponseTypes.error });
            return await CreateTransaction(transaction, "AUTHORIZED BY PAYPAL");
        }

        // METHOD USED FOR CONFIRMING THE PAYPAL EXCHANGE TRANSACTION
        [HttpPost]
        [Route("paypal_confirm_exchange")]
        public async Task<IActionResult> ConfirmPayPalExchangeTransaction([FromBody]string paymentId)
        {
            if (await _accountService.GetByEmailAsync(User.Identity.Name) == null) return BadRequest(new ResponseMessage() { Duration = 10000, Message = "You are not authorized", Type = ResponseMessage.ResponseTypes.error });
            var transaction = await _transactionService.GetExchangeAsync(x => x.ExternalServiceId == paymentId);
            if (transaction == null) return BadRequest(new ResponseMessage() { Duration = 10000, Message = "Transaction wasn't found", Type = ResponseMessage.ResponseTypes.error });
            transaction.Status = "CONFIRMED";
            await _transactionService.UpdateExchangeAsync(transaction);
            return Ok(new ResponseMessage()
            {
                Duration = 7000,
                Message = "Payment successfully confirmed. The exchange transaction has been submitted.",
                Type = ResponseMessage.ResponseTypes.success
            });
        }

        // METHOD USED FOR REGISTERING CRYPTO IN EXCHANGE TRANSACTION
        [HttpPost]
        [Route("crypto_create_exchange")]
        public async Task<IActionResult> CreateCryptoExchangeTransaction(ExchangeTransaction transaction)
        {
            if (transaction == null) return BadRequest(new ResponseMessage()
            { Duration = 10000, Message = "Something went wrong with your transaction", Type = ResponseMessage.ResponseTypes.error });
            return await CreateTransaction(transaction, "CONFIRMED");
        }

        // LOCAL TEMPLATE FOR GENERATING EXCHANGE TRANSACTION
        private async Task<IActionResult> CreateTransaction(dynamic transaction, string status)
        {
            var user = await _accountService.GetByEmailAsync(User.Identity.Name);
            if (user == null)  return BadRequest(new ResponseMessage() { Duration = 10000, Message = "You are not authorized", Type = ResponseMessage.ResponseTypes.error });

            Random rand = new Random();
            transaction.UniqueId = DateTime.Now.Ticks.ToString("X") + rand.Next(1, 1000);
            transaction.UserId = user.Id;
            transaction.Status = status;
            transaction.Created = DateTime.Now.ToString("dd/MM/yyyy hh:mm");

            switch (transaction)
            {
                case ExchangeTransaction exchangeTransaction:
                    await _transactionService.AddExchangeAsync(exchangeTransaction);
                    return Ok();
                case TransferTransaction transferTransaction:
                    await _transactionService.AddTransferAsync(transferTransaction);
                    return Ok();
                default:
                    return BadRequest((new ResponseMessage()
                    {
                        Duration = 60000,
                        Message =
                            "Transaction storing has been failed. Please, contact our support center to find out the details.",
                        Type = ResponseMessage.ResponseTypes.error
                    }));
            }
        }

        // METHOD USED FOR YIELDING USER'S EXCHANGE TRANSACTIONS
        [HttpPost]
        [Route("get_exchanges")]
        public async Task<IActionResult> GetUserExchangesList()
        {
            var user = await _accountService.GetByEmailAsync(User.Identity.Name);
                if (user == null) return BadRequest();
            var list = await _transactionService.GetExchangesListAsync(user.Id);
            return Ok(list);

        }
    }
}
