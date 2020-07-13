using Tiburon.Models;

namespace Tiburon.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Survey> Surveys { get;  }
        IRepository<Answer> Answers { get; }
        IRepository<Result> Results { get; }
        IQuestionExtra Questions { get; }
        IRepository<Interview> Interviews { get; }
    }
}
