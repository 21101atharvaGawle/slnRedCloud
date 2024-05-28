using MvcApiCallingService.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcApiCallingService.Helpers.ApiHelper
{
    public interface IApiClient<T>
    {
        Task<Response<IEnumerable<T>>> GetAllAsync(string apiUrl);
        Task<PagedResponse<IEnumerable<T>>> GetPagedAsync(string apiUrl);
        Task<Response<T>> GetByIdAsync(string apiUrl);
        Task<Response<int>> PostAsync<TEntity>(string apiUrl, TEntity entity);
        // for Account
        Task<T> PostAuthAsync<TEntity>(string apiUrl, TEntity entity);
        Task PutAsync<TEntity>(string apiUrl, TEntity entity);
        Task<string> DeleteAsync(string apiUrl);
    }
}
