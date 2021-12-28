using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Entities.Enums;

namespace Entities.DTOs
{
    public class QuizDto : IDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string QuizName { get; set; }
        public string QuizNumber { get; set; }
        public List<QuestionDto> Questions { get; set; }
        public DateTime OperationDate { get; set; }
        public Status Status { get; set; }
    }
}
