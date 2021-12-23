using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IQuestionDal : IEntityRepository<Question>
    {
       QuestionDto GetQuestionDetail(int id);
       List<QuestionDto> GetAllQuestionsDetail(Expression<Func<QuestionDto, bool>> filter = null);
    }
}
