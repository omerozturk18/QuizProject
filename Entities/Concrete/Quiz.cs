using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Enums;

namespace Entities.Concrete
{
    public class Quiz:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string QuizName { get; set; }
        public string QuizNumber { get; set; }
        public DateTime OperationDate { get; set; }
        public Status Status { get; set; }

    }
}
