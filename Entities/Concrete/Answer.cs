using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class Answer:IEntity
    {
        public int Id { get; set; } 
        public string QuestionAnswer { get; set; } 
        // public string AnswerImage { get; set;
        public bool IsCorrect { get; set; } 
        public int QuestionId { get; set; }
        public DateTime OperationDate { get; set; }
    }
}
