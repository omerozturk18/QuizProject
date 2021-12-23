using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserAnswerService : IBaseService<UserAnswer>
    {
       IDataResult<UserAnswerDto> GetAnswerDetail( int id);
       IDataResult<List<UserAnswerDto>> GetUserAnswersDetail( int userId);
       IDataResult<List<UserAnswerDto>> GetQuestionAnswersDetail( int questionId);
       IDataResult<List<UserAnswerDto>> GetQuizAnswersDetail( int quizId );
    }
}
