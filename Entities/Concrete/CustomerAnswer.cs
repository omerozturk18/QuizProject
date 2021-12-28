using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class CustomerAnswer:IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int QuizId { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
        public int Score { get; set; }
        public DateTime OperationDate { get; set; }
    }
}
