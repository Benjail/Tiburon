using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tiburon.Models
{
    public class Question
    {
        public Guid Id { get; set; }
        public string Name { get; set;}
        public List<Question> Answers { get; set; }
        public Survey Survey { get; set; }

    }
}
