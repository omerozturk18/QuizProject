using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICustomerAnswerService : IBaseService<CustomerAnswer>
    {
       IDataResult<CustomerAnswerDto> GetAnswerDetail( int id);
       IDataResult<List<CustomerAnswerDto>> GetCustomerAnswersDetail( int userId);
       IDataResult<List<CustomerAnswerDto>> GetQuestionAnswersDetail( int questionId);
       IDataResult<List<CustomerAnswerDto>> GetQuizAnswersDetail( int quizId );
    }
}
