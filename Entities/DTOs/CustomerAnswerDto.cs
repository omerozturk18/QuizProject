using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Core.Entities.Concrete;
using Entities.Concrete;

namespace Entities.DTOs
{
    public class CustomerAnswerDto : IDto
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Quiz Quiz { get; set; }
        public Question Question { get; set; }
        public QuestionOption Answer { get; set; }
        public int Score { get; set; }
    }
}
