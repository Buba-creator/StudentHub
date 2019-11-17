using StudentHub.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHub.Models
{
    public class Reply
    {
        public int ReplyId { get; set; }
        public int CommentId { get; set; }
        public string Text { get; set; }
        public Comment Comment { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime DateAnswered { get; set; }
    }
}
