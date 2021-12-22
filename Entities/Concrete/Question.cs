using Core.Entities;
using Entities.Enums;
using System;

namespace Entities.Concrete
{
    public class Question : IEntity
    {
        public int Id { get; set; }
        public string QuizQuestion { get; set; }
        public string QuestionImage { get; set; }
        public TimeSpan QuestionDuration { get; set; }
        public int QuizId { get; set; }
        public DateTime OperationDate { get; set; }
        public QuestionType QuestionType { get; set; }
    }
}
