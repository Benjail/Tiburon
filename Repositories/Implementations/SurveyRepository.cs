using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tiburon.Models;

namespace Tiburon.Repositories
{
    public class SurveyRepository:IRepository<Survey>
    {
        AppDBContext dbContext;
        public SurveyRepository(AppDBContext appdBContext)
        {
            dbContext = appdBContext;
        }
        public async Task<List<Survey>> Getall()
        {
            return await dbContext.Surveys.ToListAsync();
        }

        public async Task<Survey> Get(Guid id)
        {
            return await dbContext.Surveys.FindAsync(id);
        }

        public async Task Delete(Guid id)
        {
            var answer = await dbContext.Surveys.FindAsync(id);
            if (answer != null)
            {
                dbContext.Surveys.Remove(answer);
                await dbContext.SaveChangesAsync();
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public async Task Update(Survey item)
        {
            dbContext.Entry(item).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }

        public async Task Create(Survey Item)
        {
            await dbContext.Surveys.AddAsync(Item);
        }
    }
}

