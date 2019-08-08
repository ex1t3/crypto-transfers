using System;
using System.Collections.Generic;
using System.Text;
using DAL.DbRepository;
using Model.Models;

namespace Service.Services
{
    public interface ITransactionService
    {
        void AddExchange(ExchangeTransaction transaction);
        void AddTransfer(TransferTransaction transaction);
    }
     public class TransactionService : ITransactionService
    {
        private readonly IDbRepository<ExchangeTransaction> _exchangeRepository;
        private readonly IDbRepository<TransferTransaction> _transferRepository;

        public TransactionService( IDbRepository<ExchangeTransaction> exchangeRepository, IDbRepository<TransferTransaction> transferRepository)
        {
            _exchangeRepository = exchangeRepository;
            _transferRepository = transferRepository;
        }

        public void AddExchange(ExchangeTransaction transaction)
        {
            _exchangeRepository.Add(transaction);
        }

        public void AddTransfer(TransferTransaction transaction)
        {
            _transferRepository.Add(transaction);
        }
    }
}
