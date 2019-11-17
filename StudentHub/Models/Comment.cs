using StudentHub.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHub.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int? SolutionId { get; set; }
        public int? QuestionId { get; set; }
        public string Text { get; set; }
        public Solution Solution { get; set; }
        public Question Question { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime DateAnswered { get; set; }
        public IEnumerable<Reply> Replies { get; set; }

        public Comment()
        {
            this.Replies = new List<Reply>();
        }
    }
}
