using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aiesec.Service.IServices
{
    public interface IAuthService<TModel, TRequest, TUpdate, TResponse, TSearch, TEncryptedKey, TDecryptedKey> : IDataProtectionService<TModel, TEncryptedKey, TDecryptedKey>
    {
        Task<int> GetNumberOfRecordsAsync();
        Task<List<TResponse>> TakeRecordsByNumberAsync(int take = 10);
        Task<Tuple<List<TResponse>, int>> GetByParametersAsync(TSearch search, string order, string nameOfColumn, int start, int length);
        Task<TResponse> GetByIdAsync(TEncryptedKey id);
        Task<TModel> GetModelByIdAsync(TEncryptedKey id);
    }   
}