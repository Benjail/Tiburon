using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tiburon.Models
{
    public class Survey
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Question> Questions { get; set; }
           
    }
}
