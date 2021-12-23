using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IQuestionService : IBaseService<Question>
    {
       IDataResult<List<Question>> GetByQuizId(int quizId);
       IDataResult<QuestionDto> GetQuestionDetail(int id);
    }
}
