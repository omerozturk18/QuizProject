using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IQuizService:IBaseService<Quiz>
    {
       IDataResult<Quiz> IsThereQuiz(string quizNumber);
       IDataResult<QuizDto> GetQuizDetail(int id);
       IDataResult<List<Quiz>> GetByUserQuizzes(int id);
       IDataResult<List<QuizDto>> GetQuizzesDetailByUserId(int id);
       IResult ActivatedQuiz(int id);
       IResult StartedQuiz(int id);
       IResult CompletedQuiz(int id);
    }
}
