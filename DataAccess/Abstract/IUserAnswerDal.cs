using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserAnswerDal : IEntityRepository<UserAnswer>
    {
       UserAnswerDto GetAnswerDetail(Expression<Func<UserAnswerDto, bool>> filter = null);
       List<UserAnswerDto> GetAnswersDetail(Expression<Func<UserAnswerDto, bool>> filter = null);
    }
}
