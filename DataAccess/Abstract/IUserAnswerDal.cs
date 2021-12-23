using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserAnswerDal : IEntityRepository<UserAnswer>
    {
       UserAnswerDto GetAnswerDetail(Expression<Func<CarDetailDto, bool>> filter = null);
       List<UserAnswerDto> GetUserAnswersDetail(Expression<Func<CarDetailDto, bool>> filter = null);
       List<UserAnswerDto> GetQuestionAnswersDetail(Expression<Func<CarDetailDto, bool>> filter = null);
       List<UserAnswerDto> GetQuizAnswersDetail(Expression<Func<CarDetailDto, bool>> filter = null);
    }
}
