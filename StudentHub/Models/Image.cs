using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHub.Models
{
    public class Image
    {
        public int ImageId { get; set; }
        public int? SolutionId { get; set; }
        public int? QuestionId { get; set; }
        public string ImageLatex { get; set; }
        public Solution Solution { get; set; }
        public Question Question { get; set; }
    }
}
