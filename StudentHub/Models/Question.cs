using StudentHub.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHub.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public int Views { get; set; }
        public string TItle { get; set; }
        public string  Description { get; set; }
        public DateTime DateAdded { get; set; }
        public ApplicationUser User { get; set; }
        public List<Image> ImageIds { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public IEnumerable<Solution> Solutions { get; set; }

        public Question()
        {
            this.Comments = new List<Comment>();
            this.Solutions = new List<Solution>();
        }
    }
}
