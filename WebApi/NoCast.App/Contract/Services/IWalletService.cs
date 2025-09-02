
using System.Collections.Generic;
using System.Threading.Tasks;
using NoCast.App.Contract.Services;
using NoCast.App.Dtos;
using NoCast.App.Models;

namespace NoCast.App.Services.Interfaces
{
    public interface IWalletService : IGenericService<Wallet, WalletDto>
    {
        Task<WalletDto> CreateBalanceUser(Guid userId, decimal amount);
        Task<WalletDto> GetWalletUser(Guid userId);
    }
}