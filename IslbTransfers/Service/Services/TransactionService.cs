using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.DbRepository;
using Microsoft.AspNetCore.Mvc;
using Model.Models;

namespace Service.Services
{
    public interface ITransactionService
    {
        Task AddExchangeAsync(ExchangeTransaction transaction);
        Task<ExchangeTransaction> GetExchangeAsync(Expression<Func<ExchangeTransaction, bool>> where);
        Task UpdateExchangeAsync(ExchangeTransaction transaction);

        Task AddTransferAsync(TransferTransaction transaction);
        Task<List<ExchangeTransaction>> GetExchangesListAsync(int userId);
    }
     public class TransactionService : ITransactionService
    {
        private readonly IDbRepository<ExchangeTransaction> _exchangeRepository;
        private readonly IDbRepository<TransferTransaction> _transferRepository;

        public TransactionService(IDbRepository<ExchangeTransaction> exchangeRepository, IDbRepository<TransferTransaction> transferRepository)
        {
            _exchangeRepository = exchangeRepository;
            _transferRepository = transferRepository;
        }

        public async Task AddExchangeAsync(ExchangeTransaction transaction)
        {
           await _exchangeRepository.AddAsync(transaction);

        }
        public async Task UpdateExchangeAsync(ExchangeTransaction transaction)
        {
            _exchangeRepository.Update(transaction);
        }

        public async Task<ExchangeTransaction> GetExchangeAsync(Expression<Func<ExchangeTransaction, bool>> where)
        {
            return await _exchangeRepository.GetAsync(where);

        }

        public async Task<List<ExchangeTransaction>> GetExchangesListAsync(int userId)
        {
            return await _exchangeRepository.GetManyAsync(x => x.UserId == userId);
        }

        public async Task AddTransferAsync(TransferTransaction transaction)
        {
            await _transferRepository.AddAsync(transaction);
        }
    }
}
