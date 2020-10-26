using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aiesec.Service.IServices
{
    public interface IBaseService<TRequest, TSearch, TResponse, TKey>
    {
        ValueTask<List<TResponse>> GetAll();
        ValueTask<Tuple<int, List<TResponse>>> GetPaged(TSearch search, int start, int take, string searchColumn, string searchOrder);
        ValueTask<TResponse> GetById(TKey id);
        ValueTask<TResponse> Add(TRequest entity);
        ValueTask<TResponse> Edit(TKey id, TRequest entity);
        ValueTask Delete(TKey id);
        ValueTask Delete(TRequest entity);
        Task<int> NumberOfRecords();
    }
}