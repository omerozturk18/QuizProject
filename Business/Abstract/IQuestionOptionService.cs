using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IQuestionOptionService : IBaseService<QuestionOption>
    {
        IDataResult<List<QuestionOption>> MultiAdd(List<QuestionOption> questionOptions);
        IDataResult<List<QuestionOption>> MultiUpdate(List<QuestionOption> questionOptions);
        IDataResult<List<QuestionOption>> GetQuestionOptionsByQuestionId(int questionId);

    }
}
