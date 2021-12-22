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
    public class QuestionOptionsController : ControllerBase
    {
        private readonly IQuestionOptionService _questionOptionService;

        public QuestionOptionsController(IQuestionOptionService questionOptionService)
        {
            _questionOptionService = questionOptionService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _questionOptionService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getById")]
        public IActionResult GetById(int answerId)
        {
            var result = _questionOptionService.GetById(answerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(QuestionOptionDto answer)
        {
            var result = _questionOptionService.Add(answer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(QuestionOptionDto answer)
        {
            var result = _questionOptionService.Update(answer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(QuestionOptionDto answer)
        {
            var result = _questionOptionService.Delete(answer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
