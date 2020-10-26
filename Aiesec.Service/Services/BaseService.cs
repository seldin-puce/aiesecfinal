using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aiesec.Database.Context;
using Aiesec.Service.IServices;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Aiesec.Service.Services
{
    public class BaseService<TEntity, TRequest, TSearch, TResponse, TKey> : IBaseService<TRequest, TSearch, TResponse, TKey> where TEntity : class
    {
        private readonly AuthContext _context;
        private readonly IMapper _mapper;

        protected BaseService(AuthContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }


        public virtual async ValueTask<List<TResponse>> GetAll()
        {
            return _mapper.Map<List<TResponse>>(await _context.Set<TEntity>().ToListAsync().ConfigureAwait(false));
        }

        public virtual async ValueTask<Tuple<int, List<TResponse>>> GetPaged(TSearch search, int start, int take, string searchColumn, string searchOrder)
        {
            return new Tuple<int, List<TResponse>>(await _context.Set<TEntity>().CountAsync().ConfigureAwait(false), _mapper.Map<List<TResponse>>(await _context.Set<TEntity>().Skip(start).Take(take).ToListAsync().ConfigureAwait(false)));
        }

        public virtual async ValueTask<TResponse> GetById(TKey id)
        {
            return _mapper.Map<TResponse>(await _context.Set<TEntity>().FindAsync(id));
        }

        public virtual async ValueTask<TResponse> Add(TRequest entity)
        {
            TEntity dbEntity = _mapper.Map<TEntity>(entity);
            await _context.Set<TEntity>().AddAsync(dbEntity);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return _mapper.Map<TResponse>(dbEntity);
        }

        public virtual async ValueTask<TResponse> Edit(TKey id, TRequest entity)
        {
            TEntity dbEntity = await _context.Set<TEntity>().FindAsync(id);
            _context.Set<TEntity>().Attach(dbEntity);
            _mapper.Map(entity, dbEntity);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return _mapper.Map<TResponse>(dbEntity);
        }

        public virtual async ValueTask Delete(TKey id)
        {
            TEntity dbEntity = await _context.Set<TEntity>().FindAsync(id);
            _context.Set<TEntity>().Remove(dbEntity);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public virtual async ValueTask Delete(TRequest entity)
        {
            TEntity dbEntity = _mapper.Map<TEntity>(entity);
            _context.Set<TEntity>().Remove(dbEntity);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public virtual Task<int> NumberOfRecords()
        {
            return _context.Set<TEntity>().CountAsync();
        }
    }
}