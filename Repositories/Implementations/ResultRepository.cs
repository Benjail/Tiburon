using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tiburon.Models;

namespace Tiburon.Repositories.Implementations
{
    public class ResultRepository :IRepository<Result>
    {
        AppDBContext dbContext;
        public ResultRepository(AppDBContext appdBContext)
        {
            dbContext = appdBContext;
        }
        public Task<List<Result>> Getall()
        {
            return dbContext.Results.ToListAsync();
        }

        public async Task<Result> Get(Guid id)
        {
            return await dbContext.Results.FindAsync(id);
        }

        public async Task Delete(Guid id)
        {
            var answer = await dbContext.Results.FindAsync(id);
            if (answer != null)
            {
                dbContext.Results.Remove(answer);
                await dbContext.SaveChangesAsync();
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public async Task Update(Result item)
        {
            dbContext.Entry(item).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }

        public async Task Create(Result Item)
        {
            await dbContext.Results.AddAsync(Item);
        }
    }
}
