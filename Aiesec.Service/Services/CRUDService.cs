using System;
using System.Threading.Tasks;
using Aiesec.Database.Context;
using Aiesec.Database.Models;
using Aiesec.Service.IServices;
using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Logging;

#pragma warning disable CA2200

namespace Aiesec.Service.Services
{
    public class CRUDService<TModel, TRequest, TUpdate, TResponse, TSearch, TEncryptedKey, TDecryptedKey> : ReadService<TModel, TResponse, TSearch, TEncryptedKey, TDecryptedKey>,
        ICRUDService<TModel, TRequest, TUpdate, TResponse, TSearch, TEncryptedKey, TDecryptedKey> where TModel : BaseEntity<TDecryptedKey>
    {
        private readonly DBContext _dbContext;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        public CRUDService(DBContext dbContext, ILogger<CRUDService<TModel, TRequest, TUpdate, TResponse, TSearch, TEncryptedKey, TDecryptedKey>> logger,
            IMapper mapper, IDataProtectionProvider protectionProvider) : base(dbContext, mapper, protectionProvider)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public virtual async Task<TResponse> ChangeActiveStatusAsync(TEncryptedKey id)
        {
            TModel model = await _dbContext.Set<TModel>().FindAsync(DecryptId(id));
            model.Active = !model.Active;
            try
            {
                _dbContext.Set<TModel>().Update(model);
                await _dbContext.SaveChangesAsync().ConfigureAwait(false);
                // TODO: Dodati log operaciju

            }
            catch
            {
                //TODO: Dodati log operaciju
                throw;
            }

            return _mapper.Map<TResponse>(model);
        }

        public virtual async Task<TResponse> DeleteAsync(TEncryptedKey id)
        {
            TModel model = await _dbContext.Set<TModel>().FindAsync(DecryptId(id));
            try
            {
                _dbContext.Set<TModel>().Remove(model);
                await _dbContext.SaveChangesAsync().ConfigureAwait(false);
                // TODO: Dodati log u bazu
            }
            catch
            {
                //  TODO: Dodati log u bazu
                throw;

            }

            return _mapper.Map<TResponse>(model);
        }

        public virtual async Task<TResponse> InsertAsync(TRequest entity)
        {
            TModel model = _mapper.Map<TModel>(entity);
            try
            {
                _dbContext.Set<TModel>().Add(model);
                await _dbContext.SaveChangesAsync().ConfigureAwait(false);
                // TODO: Dodati log u bazu
            }
            catch (Exception e)
            {
                // TODO: Dodati log u bazu
                throw e;
            }
            EncryptId(model);

            return _mapper.Map<TResponse>(model);
        }


        public virtual async Task<TResponse> UpdateAsync(TEncryptedKey id, TUpdate entity)
        {
            TModel model = await _dbContext.Set<TModel>().FindAsync(DecryptId(id));
            _mapper.Map(entity, model);
            _dbContext.Set<TModel>().Attach(model);
            _dbContext.Set<TModel>().Update(model);
            try
            {
                await _dbContext.SaveChangesAsync().ConfigureAwait(false);
                // TODO: Dodati log operaciju
            }
            catch
            {
                //TODO: Dodati log operaciju
                throw;
            }
            EncryptId(model);
            return _mapper.Map<TResponse>(model);
        }
    }
}