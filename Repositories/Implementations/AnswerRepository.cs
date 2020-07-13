using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tiburon.Models;

namespace Tiburon.Repositories
{
    public class AnswerRepository : IRepository<Answer>
    {
        AppDBContext dbContext;
        public AnswerRepository(AppDBContext appdBContext)
        {
            dbContext = appdBContext;
        }
        public Task<List<Answer>> Getall()
        {
            return dbContext.Answers.ToListAsync();
        }

        public async Task<Answer> Get(Guid id)
        {
            return await dbContext.Answers.FindAsync(id);
        }
     
        public async Task Delete(Guid id)
        {
            var answer = await dbContext.Answers.FindAsync(id);
            if (answer != null)
            {
                dbContext.Answers.Remove(answer);
                await dbContext.SaveChangesAsync();
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public async Task Update(Answer item)
        {
            dbContext.Entry(item).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }

        public async Task Create(Answer Item)
        {
            await dbContext.Answers.AddAsync(Item);
        }
    }
}
