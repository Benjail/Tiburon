using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using Tiburon.Models;
using Tiburon.Repositories.Interfaces;
using Tiburon.Requests;

namespace Tiburon.Controllers
{
    [ApiController]
    [Route("Home")]
    public class HomeController
    {   
        IUnitOfWork unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("question")]
        public async Task<string> GetQuestion(Guid id)
        {
            Question question = await unitOfWork.Questions.Get(id);
            return JsonSerializer.Serialize<Question>(question);
        }

        [HttpPost("sendresult")]
        public async Task<string> SendAnswer(AddResultModel model)
        {
                var interview = await unitOfWork.Interviews.Get(model.InterviewId);
                var question = await unitOfWork.Questions.Get(model.QuestionId);
                var answer = await unitOfWork.Answers.Get(model.AnswerId);
            if (interview != null && question != null && answer != null)
            {
                Result result = new Result
                {
                    AnswerName = answer.Name,
                    InerviewId = interview.Id,
                    Interview = interview,
                    QuestionName = question.Name
                };
                await unitOfWork.Results.Create(result);
                Guid newid = await unitOfWork.Questions.GetNextId(question.Id);
                return JsonSerializer.Serialize<Guid>(newid);
            }
            else
                return JsonSerializer.Serialize("Interview,question or answer is Not Found!");
            }
        }
    }