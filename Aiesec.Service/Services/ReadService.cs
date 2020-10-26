using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aiesec.Database.Context;
using Aiesec.Database.Models;
using Aiesec.Service.IServices;
using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;

namespace Aiesec.Service.Services
{
    public class ReadService<TModel, TResult, TSearch, TEncryptedKey, TDecryptedKey>
        : DataProtectionService<TModel, TEncryptedKey, TDecryptedKey>, IReadService<TModel, TResult, TSearch, TEncryptedKey, TDecryptedKey>, IDataProtectionService<TModel, TEncryptedKey, TDecryptedKey>
        where TModel : BaseEntity<TDecryptedKey>
    {
        private readonly DBContext _dbContext;
        private readonly IMapper _mapper;

        public ReadService(DBContext dbContext, IMapper mapper, IDataProtectionProvider protectionProvider) : base(protectionProvider)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public virtual async Task<List<TResult>> GetAllActiveAsync()
        {
            List<TModel> result = await _dbContext.Set<TModel>().Where(x => x.Active).ToListAsync().ConfigureAwait(false);
            EncryptList(result);
            return _mapper.Map<List<TResult>>(result);
        }

        public virtual async Task<List<TResult>> GetAllAsync()
        {
            List<TModel> result = await _dbContext.Set<TModel>().ToListAsync().ConfigureAwait(false);
            EncryptList(result);
            return _mapper.Map<List<TResult>>(result);
        }

        public virtual async Task<TResult> GetByIdAsync(TEncryptedKey id)
        {
            try
            {
                TModel result = await _dbContext.Set<TModel>().FindAsync(DecryptId(id));
                EncryptId(result);
                return _mapper.Map<TResult>(result);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public virtual async Task<List<TResult>> GetByParametersAsync(TSearch search)
        {
            List<TModel> result = await _dbContext.Set<TModel>().ToListAsync().ConfigureAwait(false);
            EncryptList(result);
            return _mapper.Map<List<TResult>>(result);
        }

        public virtual async Task<Tuple<List<TResult>, int>> GetByParametersAsync(TSearch search, string order, string orderColumn, int start, int length)
        {
            List<TModel> result = await _dbContext.Set<TModel>().Skip(start).Take(length).ToListAsync().ConfigureAwait(false);
            EncryptList(result);
            return new Tuple<List<TResult>, int>(_mapper.Map<List<TResult>>(result), length);
        }

        public virtual async Task<int> GetNumberOfRecordsAsync()
        {
            return await _dbContext.Set<TModel>().CountAsync().ConfigureAwait(false);
        }

        public virtual async Task<List<TResult>> TakeRecordsByNumberAsync(int take = 10)
        {
            List<TModel> result = await _dbContext.Set<TModel>().Take(take).ToListAsync().ConfigureAwait(false);
            EncryptList(result);
            return _mapper.Map<List<TResult>>(result);
        }

    }
}
