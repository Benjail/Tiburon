using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tiburon.Models;
using Tiburon.Repositories.Interfaces;

namespace Tiburon.Repositories
{
    public class QuestionRepository : IQuestionExtra
    {
        AppDBContext dbContext;
        public QuestionRepository(AppDBContext appdBContext)
        {
            dbContext = appdBContext;
        }
        public Task<List<Question>> Getall()
        {
            return dbContext.Questions.ToListAsync();
        }

        public async Task<Question> Get(Guid id)
        {
            return await dbContext.Questions
                .Include(a=>a.Answers)
                .Where(q=>q.Id==id)
                .FirstOrDefaultAsync(); ;
        }

        public async Task Delete(Guid id)
        {
            var answer = await dbContext.Questions.FindAsync(id);
            if (answer != null)
            {
                dbContext.Questions.Remove(answer);
                await dbContext.SaveChangesAsync();
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public async Task Update(Question item)
        {
            dbContext.Entry(item).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }

        public async Task Create(Question Item)
        {
            await dbContext.Questions.AddAsync(Item);
        }

        public async Task<Guid> GetNextId(Guid id)
        {
            var nextid = id;
            var question = await dbContext.Questions.FindAsync(id);
            var list = question.Survey.Questions;
           
            for (int i=0; i<list.Count;i++)
            {
                if (list[i] == question)
                {
                    if(i==list.Count-1)            
                    {
                    }
                    else
                    {
                        nextid = list[i + 1].Id;
                    }
                }               
            }
            return nextid; //если вопрос в списке последний, возвращает Id последнего вопроса
        }
    }
}