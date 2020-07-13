using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tiburon.Models;

namespace Tiburon.Repositories.Implementations
{
    public class InterviewRepository:IRepository<Interview>
    {
        AppDBContext dbContext;
        public InterviewRepository(AppDBContext appdBContext)
        {
            dbContext = appdBContext;
        }
        public async Task<List<Interview>> Getall()
        {
            return await dbContext.Interviews.ToListAsync();
        }

        public async Task<Interview> Get(Guid id)
        {
            return await dbContext.Interviews.FindAsync(id);
        }

        public async Task Delete(Guid id)
        {
            var answer = await dbContext.Interviews.FindAsync(id);
            if (answer != null)
            {
                dbContext.Interviews.Remove(answer);
                await dbContext.SaveChangesAsync();
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public async Task Update(Interview item)
        {
            dbContext.Entry(item).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }

        public async Task Create(Interview Item)
        {
            await dbContext.Interviews.AddAsync(Item);
        }
    }
}

