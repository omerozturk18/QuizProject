using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Entities.Concrete
{

  
    public class Quiz:IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int UserId { get; set; }
        public string QuizName { get; set; }
        public string QuizNumber { get; set; }
        public List<Question> Questions{ get; set; }
        public DateTime OperationDate { get; set; }
        public Status Status { get; set; }

    }

}
