using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : ControllerBase
    {
        private readonly IAnswerService _answerService;

        public AnswersController(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _answerService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getById")]
        public IActionResult GetById(int answerId)
        {
            var result = _answerService.GetById(answerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Answer answer)
        {
            var result = _answerService.Add(answer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Answer answer)
        {
            var result = _answerService.Update(answer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Answer answer)
        {
            var result = _answerService.Delete(answer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
