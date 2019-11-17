using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentHub.Data;
using StudentHub.Models;
using StudentHub.Repository.Abstraction;

namespace StudentHub.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IQuestionRepository _questionRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public QuestionsController(ApplicationDbContext context,IQuestionRepository questionRepository,UserManager<ApplicationUser> userManager)
        {
            _questionRepository = questionRepository;
            _context = context;
            _userManager = userManager;
        }

        // GET: Questions
        public async Task<IActionResult> Index()
        {
            return View(_questionRepository.GetAll());
        }

        // GET: Questions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var question =await _questionRepository.Get(id);
            if (question == null)
            {
                return NotFound();
            }
            question.Views = +1;
            await _questionRepository.Put(question);
            return View(question);
        }

        // GET: Questions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Questions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QuestionId,TItle,Description")] Question question)
        {
            if (ModelState.IsValid)
            {
                //question.User =await _userManager.GetUserAsync(User);
                question.DateAdded = DateTime.Now.Date;
                await _questionRepository.Post(question);
                return RedirectToAction(nameof(Index));
            }
            return View(question);
        }

        // GET: Questions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            { return NotFound();  }

            var question = await _questionRepository.Get(id);
            if (question == null)
            { return NotFound();  }

            return View(question);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("QuestionId,TItle,Description")] Question question)
        {
            if (id != question.QuestionId)
            {  return NotFound(); }

            if (ModelState.IsValid)
            {
                try
                {
                    await _questionRepository.Put(question);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionExists(question.QuestionId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(question);
        }

        // GET: Questions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            { return NotFound();  }
            var question = await _questionRepository.Get(id);
            if (question == null)
            {   return NotFound(); }

            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var question = await _questionRepository.Get(id);
            await _questionRepository.Delete(question);
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionExists(int id)
        {
            return _context.Questions.Any(e => e.QuestionId == id);
        }
    }
}
