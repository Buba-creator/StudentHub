using StudentHub.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHub.Models
{
    public class Solution
    {
        public int SolutionId { get; set; }
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
        public Question Question { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime DateAnswered { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public IEnumerable<Image> Images { get; set; }

        public Solution()
        {
            this.Comments = new List<Comment>();
            this.Images = new List<Image>();
        }
    }
}
