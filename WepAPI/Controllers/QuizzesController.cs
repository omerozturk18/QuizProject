using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.DTOs;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizzesController : ControllerBase
    {
        private readonly IQuizService _quizService;

        public QuizzesController(IQuizService quizService)
        {
            _quizService = quizService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _quizService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getById")]
        public IActionResult GetById(int quizId)
        {
            var result = _quizService.GetById(quizId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Quiz quiz)
        {
            var result = _quizService.Add(quiz);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Quiz quiz)
        {
            var result = _quizService.Update(quiz);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Quiz quiz)
        {
            var result = _quizService.Delete(quiz);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpGet("isThereQuiz")]
        public IActionResult IsThereQuiz(string quizNumber)
        {
            var result = _quizService.IsThereQuiz(quizNumber);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpGet("getQuizDetail")]
        public IActionResult GetQuizDetail(int id)
        {
            var result = _quizService.GetQuizDetail(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getByUserQuizzes")]
        public IActionResult GetByUserQuizzes(int userId)
        {
            var result = _quizService.GetByUserQuizzes(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

         [HttpGet("getQuizzesDetailByUserId")]
        public IActionResult GetQuizzesDetailByUserId(int userId)
        {
            var result = _quizService.GetQuizzesDetailByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpPost("activatedQuiz")]
        public IActionResult ActivatedQuiz(int id)
        {
            var result = _quizService.ActivatedQuiz(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpPost("startedQuiz")]
        public IActionResult StartedQuiz(int id)
        {
            var result = _quizService.StartedQuiz(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("completedQuiz")]
        public IActionResult CompletedQuiz(int id)
        {
            var result = _quizService.CompletedQuiz(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
