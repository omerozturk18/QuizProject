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
    public class UserAnswersController : ControllerBase
    {
        private readonly IUserAnswerService _userAnswerService;

        public UserAnswersController(IUserAnswerService userAnswerService)
        {
            _userAnswerService = userAnswerService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _userAnswerService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getById")]
        public IActionResult GetById(int userAnswerId)
        {
            var result = _userAnswerService.GetById(userAnswerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(UserAnswer userAnswer)
        {
            var result = _userAnswerService.Add(userAnswer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(UserAnswer userAnswer)
        {
            var result = _userAnswerService.Update(userAnswer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(UserAnswer userAnswer)
        {
            var result = _userAnswerService.Delete(userAnswer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
