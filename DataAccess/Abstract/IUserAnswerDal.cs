using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserAnswerDal : IEntityRepository<UserAnswer>
    {
       UserAnswerDto GetAnswerDetail(int id);
       List<UserAnswerDto> GetAnswersDetail(Expression<Func<UserAnswerDto, bool>> filter = null);
    }
}
