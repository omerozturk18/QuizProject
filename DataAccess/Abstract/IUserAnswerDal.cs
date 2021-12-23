using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IUserAnswerDal : IEntityRepository<UserAnswer>
    {
       UserAnswerDto GetAnswerDetail(int id);
       List<UserAnswerDto> GetAllAnswersDetail(Expression<Func<UserAnswerDto, bool>> filter = null);
    }
}
