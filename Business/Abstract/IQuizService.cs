using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Entities.Enums;

namespace Business.Abstract
{
    public interface IQuizService:IBaseService<Quiz>
    {
       IDataResult<Quiz> IsThereQuiz(string quizNumber);
       IDataResult<Quiz> GetQuizByQuizNumber(string quizNumber, Status status);
       IDataResult<List<Quiz>> GetByUserQuizzes(int id);
       IResult ActivatedQuiz(string id);
       IResult StartedQuiz(string id);
       IResult CompletedQuiz(string id);
    }
}
