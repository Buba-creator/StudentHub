using StudentHub.Data;
using StudentHub.Models;
using StudentHub.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHub.Repository.Implementation
{
    public class QuestionRepository:Repository<Question>,IQuestionRepository 
    {
        public ApplicationDbContext DbContext;
        public QuestionRepository(ApplicationDbContext _DbContext): base(_DbContext)
        {
            this.DbContext = _DbContext;
        }

        public Comment AddComment(Comment comment, Question Question)
        {
            if (comment!= null && Question!=null)
            {
                try { 
                Question.Comments.Append(comment);
                DbContext.Update(Question);
                return comment;
                }
                catch {
                return null;
                }
            }
            return null;
        }

        public Solution AddSolution(Solution solution, Question Question)
        {
            if (solution != null && Question != null)
            {
                try
                {   Question.Solutions.Append(solution);
                    DbContext.Update(Question);
                    return solution;
                }
                catch
                {
                    return null;
                }
                
            }
            return null;
        }
    }
}
