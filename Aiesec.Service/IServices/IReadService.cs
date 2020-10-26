using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aiesec.Service.IServices
{
    public interface IReadService<TModel, TResult, TSearch, TEncryptedKey, TDecryptedKey> 
    {
        Task<List<TResult>> GetAllAsync();
        Task<TResult> GetByIdAsync(TEncryptedKey id);
        Task<List<TResult>> GetByParametersAsync(TSearch search);
        Task<Tuple<List<TResult>, int>> GetByParametersAsync(TSearch search, string order, string nameOfColumnOrder, int start, int length);
        Task<int> GetNumberOfRecordsAsync();
        Task<List<TResult>> TakeRecordsByNumberAsync(int take = 10);
        Task<List<TResult>> GetAllActiveAsync();
    }
}
