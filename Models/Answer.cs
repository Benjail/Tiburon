using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tiburon.Models
{
    public class Answer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Question Question { get; set; }
        public Guid QuestionId { get; set; }


    }
}
