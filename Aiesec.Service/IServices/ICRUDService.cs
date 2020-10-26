using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aiesec.Service.IServices
{
    public interface ICRUDService <TModel, TRequest, TUpdate, TResponse, TSearch, TEncryptedKey, TDecryptedKey> : IReadService<TModel, TResponse, TSearch, TEncryptedKey, TDecryptedKey>, IDataProtectionService<TModel, TEncryptedKey, TDecryptedKey>
    {
        Task<TResponse> InsertAsync(TRequest entity);
        Task<TResponse> UpdateAsync(TEncryptedKey id, TUpdate entity);
        Task<TResponse> DeleteAsync(TEncryptedKey id);
        Task<TResponse> ChangeActiveStatusAsync(TEncryptedKey id);
    }
}
