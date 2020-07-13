using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tiburon.Models;

namespace Tiburon.Repositories.Interfaces
{
    public interface IQuestionExtra: IRepository<Question>
    {
        Task<Guid> GetNextId(Guid id);
    }
}
