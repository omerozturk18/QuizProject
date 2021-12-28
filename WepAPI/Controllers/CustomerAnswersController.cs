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
    public class CustomerAnswersController : ControllerBase
    {
        private readonly ICustomerAnswerService _customerAnswerService;

        public CustomerAnswersController(ICustomerAnswerService customerAnswerService)
        {
            _customerAnswerService = customerAnswerService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _customerAnswerService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getById")]
        public IActionResult GetById(int customerAnswerId)
        {
            var result = _customerAnswerService.GetById(customerAnswerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(CustomerAnswer customerAnswer)
        {
            var result = _customerAnswerService.Add(customerAnswer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(CustomerAnswer customerAnswer)
        {
            var result = _customerAnswerService.Update(customerAnswer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CustomerAnswer customerAnswer)
        {
            var result = _customerAnswerService.Delete(customerAnswer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
