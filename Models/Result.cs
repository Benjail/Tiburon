using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tiburon.Models
{
    public class Result
    {
        public Guid Id { get; set; }
        public string QuestionName { get; set; }
        public string AnswerName { get; set; }
        public Interview Interview { get; set; }
        public Guid InerviewId { get; set; }


    }
}
