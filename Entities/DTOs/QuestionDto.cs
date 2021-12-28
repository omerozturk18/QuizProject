using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Entities.Concrete;
using Entities.Enums;

namespace Entities.DTOs
{
    public class QuestionDto : IDto
    {
        
        public int Id { get; set; }
        public int QuizId { get; set; }
        public string QuestionContent { get; set; }
        public string QuestionImage { get; set; }
        public int QuestionDuration { get; set; }
        public int QuestionScore { get; set; }
        public bool IsTimeOver { get; set; }
        public List<QuestionOption> QuestionOptions { get; set; }
        public DateTime OperationDate { get; set; }
        public QuestionType QuestionType { get; set; }
    }
}
