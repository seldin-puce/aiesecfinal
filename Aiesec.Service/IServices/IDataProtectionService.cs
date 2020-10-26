using System.Collections;

namespace Aiesec.Service.IServices
{
    public interface IDataProtectionService<TModel, TEncryptedKey, TKey>
    {
        void EncryptId(TModel item);
        TKey DecryptId(TEncryptedKey id);
        void EncryptList(IEnumerable enumerable);
    }
}
