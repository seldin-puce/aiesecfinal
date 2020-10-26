using Aiesec.Service.IServices;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections;

namespace Aiesec.Service.Services
{
    public class DataProtectionService<TModel, TEncryptedKey, TKey> : IDataProtectionService<TModel, TEncryptedKey, TKey>
    {
        private IDataProtector _dataProtector;

        public DataProtectionService(IDataProtectionProvider protectionProvider)
        {
            _dataProtector = protectionProvider.CreateProtector("Aiesec+<=|=>+DataProtection");
        }

        public void EncryptId(TModel item)
        {
            var objectInfo = item.GetType();
            var plainId = objectInfo.GetProperty(nameof(Settings.Settings.Encription.Id)).GetValue(item).ToString();
            objectInfo.GetProperty(nameof(Settings.Settings.Encription.EncryptedId)).SetValue(item, _dataProtector.Protect(plainId));
        }
        public TKey DecryptId(TEncryptedKey id)
        {
            object value = _dataProtector.Unprotect(id.ToString());
            return (TKey)Convert.ChangeType(value, typeof(TKey));
        }

        public void EncryptList(IEnumerable enumerable)
        {
            if (enumerable is null)
                throw new ArgumentNullException(nameof(enumerable));
            foreach (TModel item in enumerable)
            {
                EncryptId(item);
            }
        }
    }
}