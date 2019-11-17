using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentHub.Models;
using StudentHub.Repository.Abstraction;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentHub.Controllers.Api
{
    [Route("api/[controller]")]
    [Authorize]
    public class ReactionController : Controller
    {
        private IQuestionRepository _questionRepository;
        public ReactionController(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;  
        }
        // POST api/<controller>
        [HttpPost]
        public async void AddComment([FromBody]Comment comment,int QuestionId)
        {
            var Question = await _questionRepository.Get(QuestionId);
            if (comment != null && Question!=null)
            {
                _questionRepository.AddComment(comment, Question);
            }
        }
             
        [HttpPost]
        public async void AddSolution([FromBody]Solution solution,int QuestionId)
        {
            var Question = await _questionRepository.Get(QuestionId);
            if (solution != null && Question != null)
            {
                _questionRepository.AddSolution(solution, Question);
            }
        }
    }
}
