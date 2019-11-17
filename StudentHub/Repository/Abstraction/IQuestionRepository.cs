using StudentHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHub.Repository.Abstraction
{
    public interface IQuestionRepository:IRepository<Question>
    {
        Comment AddComment(Comment comment,Question Question);
        Solution AddSolution(Solution solution, Question Question);        
    }
}
