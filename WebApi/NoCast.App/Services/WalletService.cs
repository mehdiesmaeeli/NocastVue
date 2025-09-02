using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using NoCast.App.Data;
using NoCast.App.Dtos;
using NoCast.App.Models;
using NoCast.App.Services.Interfaces;

namespace NoCast.App.Services
{
    public class WalletService : GenericService<Wallet, WalletDto>, IWalletService
    {
        private readonly IMemoryCache _cache;

        public WalletService(ApplicationDbContext context, IMapper mapper,IMemoryCache cache) : base(context, mapper)
        {
            _cache = cache;
        }

        public async Task<WalletDto> CreateBalanceUser(Guid userId, decimal amount)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            var cacheKey = $"walletinfo_{userId}";
            try
            {
                var wallet = await _context.Wallets.FirstOrDefaultAsync(w => w.Id == userId);
                if (wallet == null)
                {
                    wallet = new Wallet() { Id = userId, TotalBalance = amount };
                    _context.Wallets.Add(wallet);
                }
                wallet.TotalBalance += amount;

                // ثبت تراکنش
                var transactionEntry = new WalletTransaction
                {
                    Id = Guid.NewGuid(),
                    WalletId = wallet.Id,
                    Date = DateTime.UtcNow,
                    Amount = amount,
                    Description = "شارژ حساب",
                    Type = WalletTransactionType.Recharge,
                    Status = WalletTransactionStatus.Completed
                };

                _context.WalletTransactions.Add(transactionEntry);

                // ذخیره
                await _context.SaveChangesAsync();

                // commit تراکنش
                await transaction.CommitAsync();
                var Dto = _mapper.Map<WalletDto>(wallet);
                _cache.Set(cacheKey, Dto);
                return Dto;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }


        public async Task<WalletDto> GetWalletUser(Guid userId)
        {
            var cacheKey = $"walletinfo_{userId}";
            var cached = _cache.Get<WalletDto>(cacheKey);
            if (cached != null)
                return cached;



            var wallet = await _context.Wallets.FirstOrDefaultAsync(w => w.Id == userId);
            var Dto = _mapper.Map<WalletDto>(wallet);
            _cache.Set(cacheKey, Dto);
            return Dto;
        }
    }
}