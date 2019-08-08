using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IslbTransfers.CustomAttributes;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace IslbTransfers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(SessionAuthorizeAttribute))]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
    }
}
