using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aiesec.Database.Context;
using Aiesec.Service.IServices;
using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Aiesec.Service.Services
{
    public class AuthService<TModel, TRequest, TUpdate, TResponse, TSearch, TEncryptedKey, TDecryptedKey>
        : DataProtectionService<TModel, TEncryptedKey, TDecryptedKey>, IAuthService<TModel, TRequest, TUpdate, TResponse, TSearch, TEncryptedKey, TDecryptedKey> where TModel : class
    {
        private readonly AuthContext _authContext;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public AuthService(AuthContext authContext, ILogger<AuthService<TModel, TRequest, TUpdate, TResponse, TSearch, TEncryptedKey, TDecryptedKey>> logger,
            IMapper mapper, IDataProtectionProvider protectionProvider) : base(protectionProvider)
        {
            _authContext = authContext;
            _logger = logger;
            _mapper = mapper;
        }

        public virtual async Task<List<TResponse>> GetAllAsync()
        {
            List<TModel> result = await _authContext.Set<TModel>().ToListAsync().ConfigureAwait(false);
            EncryptList(result);
            return _mapper.Map<List<TResponse>>(result);
        }

        public virtual async Task<TResponse> GetByIdAsync(TEncryptedKey encryptedKey)
        {
            try
            {
                TModel model = await _authContext.Set<TModel>().FindAsync(DecryptId(encryptedKey));
                EncryptId(model);
                return _mapper.Map<TResponse>(model);
            }
            catch
            {

                throw;
            }
        }

        public virtual async Task<TModel> GetModelByIdAsync(TEncryptedKey encryptedKey)
        {
            try
            {
                TModel model = await _authContext.Set<TModel>().FindAsync(DecryptId(encryptedKey));
                EncryptId(model);
                return model;
            }
            catch
            {
                throw;
            }
        }

        public virtual async Task<List<TResponse>> GetByParametersAsync(TSearch search)
        {
            return _mapper.Map<List<TResponse>>(await _authContext.Set<TModel>().ToListAsync().ConfigureAwait(false));
        }

        public virtual async Task<int> GetNumberOfRecordsAsync()
        {
            return await _authContext.Set<TModel>().CountAsync().ConfigureAwait(false);
        }

        public virtual async Task<List<TResponse>> TakeRecordsByNumberAsync(int take = 10)
        {
            List<TModel> result = await _authContext.Set<TModel>().Take(take).ToListAsync().ConfigureAwait(false);
            EncryptList(result);
            return _mapper.Map<List<TResponse>>(result);
        }

        public virtual async Task<Tuple<List<TResponse>, int>> GetByParametersAsync(TSearch search, string order, string nameOfColumnOrder, int start, int length)
        {
            List<TModel> result = await _authContext.Set<TModel>().Skip(start).Take(length).ToListAsync().ConfigureAwait(false);
            EncryptList(result);
            return new Tuple<List<TResponse>, int>(_mapper.Map<List<TModel>, List<TResponse>>(result), length);
        }
    }
}