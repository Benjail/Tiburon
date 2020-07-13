using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tiburon.Models;
using Tiburon.Repositories.Interfaces;

namespace Tiburon.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        AppDBContext appDBContext;
        AnswerRepository answerRepository;
        QuestionRepository questionRepository;
        SurveyRepository surveyRepository;
        InterviewRepository interviewRepository;
        ResultRepository resultRepository;
        public UnitOfWork(AppDBContext DBContext)
        {
            appDBContext = DBContext;
        }
        public IRepository<Survey> Surveys
        {
            get
            {
                if (surveyRepository == null)
                     surveyRepository= new SurveyRepository(appDBContext);
                return surveyRepository;
            }
        }
        public IRepository<Answer> Answers
        {
            get
            {
                if (answerRepository == null)
                    answerRepository = new AnswerRepository(appDBContext);
                return answerRepository;
            }
        }
        public IQuestionExtra Questions
        {
            get
            {
                if (questionRepository == null)
                    questionRepository = new QuestionRepository(appDBContext);
                return questionRepository;
            }
        }
        public IRepository<Result> Results
        {
            get
            {
                if (resultRepository == null)
                    resultRepository = new ResultRepository(appDBContext);
                return resultRepository;
            }
        }
        public IRepository<Interview> Interviews
        {
            get
            {
                if (interviewRepository == null)
                    interviewRepository = new InterviewRepository(appDBContext);
                return interviewRepository;
            }
        }

        
    }
}
