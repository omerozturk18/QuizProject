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
        public IActionResult GetById(int questionOptionId)
        {
            var result = _questionOptionService.GetById(questionOptionId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getQuestionOptionsByQuestionId")]
        public IActionResult GetQuestionOptionsByQuestionId(int questionId)
        {
            var result = _questionOptionService.GetQuestionOptionsByQuestionId(questionId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(QuestionOption questionOption)
        {
            var result = _questionOptionService.Add(questionOption);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("multiAdd")]
        public IActionResult MultiAdd(List<QuestionOption> questionOptions)
        {
            var result = _questionOptionService.MultiAdd(questionOptions);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }[HttpPost("multiUpdate")]
        public IActionResult MultiUpdate(List<QuestionOption> questionOptions)
        {
            var result = _questionOptionService.MultiUpdate(questionOptions);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(QuestionOption questionOption)
        {
            var result = _questionOptionService.Update(questionOption);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(QuestionOption questionOption)
        {
            var result = _questionOptionService.Delete(questionOption);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
