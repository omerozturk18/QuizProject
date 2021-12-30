using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Entities.Concrete
{
    public class QuizTaker : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string QuestionId { get; set; }
        public string QuizNumber { get; set; }
        public string UserName { get; set; }
        public int Score { get; set; }
    }
}