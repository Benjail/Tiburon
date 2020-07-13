using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tiburon.Repositories
{
    public interface IRepository<T> where T: class
    {
        Task<List<T>> Getall();
        Task<T>Get (Guid id);
        Task Delete (Guid id);
        Task Update (T Item);
        Task Create (T Item);

    }
}
