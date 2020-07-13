using System;

namespace Tiburon.Requests
{
    public class AddResultModel
    {
        public Guid QuestionId { get; set; } 
        public Guid AnswerId { get; set; } 
        public Guid InterviewId { get; set; }
    }
}
