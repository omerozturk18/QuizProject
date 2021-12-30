using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Entities.DTOs;
using Entities.Enums;
using Microsoft.AspNetCore.SignalR;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizzesController : ControllerBase
    {
        private readonly IQuizService _quizService;
        private readonly IHubContext<BroadcastHub> _hubContext;

        public QuizzesController(IQuizService quizService, IHubContext<BroadcastHub> hubContext)
        {
            _quizService = quizService;
            _hubContext = hubContext;
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
        public IActionResult GetById(string quizId)
        {
            var result = _quizService.GetById(quizId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public async Task<ActionResult> Add([FromBody] Quiz quiz)
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
        [HttpGet("getQuizByQuizNumber")]
        public IActionResult GetQuizByQuizNumber(string quizNumber, Status status)
        {

            var result = _quizService.GetQuizByQuizNumber(quizNumber, status);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        
        [HttpPost("activatedQuiz")]
        public IActionResult ActivatedQuiz(Quiz quiz)
        {
            var result = _quizService.ActivatedQuiz(quiz.Id);
            if (result.Success)
            {
                _hubContext.Clients.All.SendAsync("ActivatedQuiz", quiz);
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        [HttpPost("startedQuiz")]
        public IActionResult StartedQuiz(Quiz quiz)
        {

            var result = _quizService.StartedQuiz(quiz.Id);
            if (result.Success)
            {
                _hubContext.Clients.All.SendAsync("StartedQuiz"+quiz.QuizNumber, quiz);
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("completedQuiz")]

        public IActionResult CompletedQuiz(Quiz quiz)
        {
            var result = _quizService.CompletedQuiz(quiz.Id);
            if (result.Success)
            {
                _hubContext.Clients.All.SendAsync("CompletedQuiz" + quiz.QuizNumber);
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("nextQuestion")]
        public IActionResult NextQuestion(int questionLocalation, Quiz quiz)
        {
            
            _hubContext.Clients.All.SendAsync("ChangeQuestion" + quiz.QuizNumber);
            return Ok(questionLocalation+1);
        }
    }
}
