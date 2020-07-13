using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tiburon.Models
{
    public class Interview
    {        
        public Guid Id { get; set; }
        public Guid SurveyId { get; set; }
        public string Name { get; set; }
        public List<Result> Results { get; set; } 

    }
}
