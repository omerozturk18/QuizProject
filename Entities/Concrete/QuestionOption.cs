using System;
using Core.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class QuestionOption : IEntity
{
    public string QuestionOptionA { get; set; }
    public string QuestionOptionB { get; set; }
    public string QuestionOptionC { get; set; }
    public string QuestionOptionD { get; set; }
}