using System;
using System.Collections.Generic;
using Core.Entities;
using Entities.Concrete;
using Entities.Enums;


public class Question : IEntity
{

    public string Id { get; set; }
    public string QuestionContent { get; set; }
    public string QuestionImage { get; set; }
    public int QuestionDuration { get; set; }
    public int QuestionScore { get; set; }
    public QuestionOption QuestionOptions { get; set; }
    public QuestionType QuestionType { get; set; }
    public AnswerType CorrectAnswer { get; set; }
}