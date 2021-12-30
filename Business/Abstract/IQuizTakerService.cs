using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IQuizTakerService : IBaseService<QuizTaker>
    {
       IDataResult<QuizTaker> IsThereUserInQuiz(QuizTaker quizTaker);
       IDataResult<List<QuizTaker>> IsThereUserInQuizList(QuizTaker quizTaker);
       IDataResult<List<QuizTaker>> GetAllQuizTakerByQuizNumber(string quizNumber);

       /* IDataResult<CustomerAnswerDto> GetAnswerDetail( int id);
        IDataResult<List<CustomerAnswerDto>> GetQuestionAnswersDetail( int questionId);
        IDataResult<List<CustomerAnswerDto>> GetQuizAnswersDetail( int quizId );*/
    }
}
