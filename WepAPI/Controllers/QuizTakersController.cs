using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.DTOs;
using Microsoft.AspNetCore.SignalR;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizTakersController : ControllerBase
    {
        private readonly IQuizTakerService _quizTakerService;
        private readonly IHubContext<BroadcastHub> _hubContext;
        public QuizTakersController(IQuizTakerService quizTakerService, IHubContext<BroadcastHub> hubContext)
        {
            _quizTakerService = quizTakerService;
            _hubContext = hubContext;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _quizTakerService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getById")]
        public IActionResult GetById(string quizTakerId)
        {
            var result = _quizTakerService.GetById(quizTakerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getAllQuizTakerByQuizNumber")]
        public IActionResult GetAllQuizTakerByQuizNumber(string quizNumber)
        {
            var result = _quizTakerService.GetAllQuizTakerByQuizNumber(quizNumber);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("isThereUserInQuiz")]
        public async Task<IActionResult> IsThereUserInQuiz(QuizTaker quizTaker)
        {
            var result = _quizTakerService.IsThereUserInQuiz(quizTaker);
            if (result.Success)
            {
               await _hubContext.Clients.All.SendAsync("AddQuizTaker"+quizTaker.QuizNumber, quizTaker);
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("add")]
        public IActionResult Add(QuizTaker quizTaker)
        {
            var result = _quizTakerService.Add(quizTaker);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(QuizTaker quizTaker)
        {
            var result = _quizTakerService.Update(quizTaker);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(QuizTaker quizTaker)
        {
            var result = _quizTakerService.Delete(quizTaker);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
