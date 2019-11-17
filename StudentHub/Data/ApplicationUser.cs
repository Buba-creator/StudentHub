using Microsoft.AspNetCore.Identity;
using StudentHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHub.Data
{
    public class ApplicationUser:IdentityUser
    {
        public IEnumerable<Question> Questions { get; set; }
        public IEnumerable<Solution> Solutions { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public IEnumerable<Reply> Replies { get; set; }

        public ApplicationUser()
        {
            this.Questions = new List<Question>();
            this.Solutions = new List<Solution>();
            this.Comments = new List<Comment>();
            this.Replies = new List<Reply>();
        }
    }
}
