﻿using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserAnswerDal : IEntityRepository<UserAnswer>
    {
       UserAnswerDto GetAnswerDetail(Expression<Func<UserAnswerDto, bool>> filter = null);
       List<UserAnswerDto> GetUserAnswersDetail(Expression<Func<UserAnswerDto, bool>> filter = null);
       List<UserAnswerDto> GetQuestionAnswersDetail(Expression<Func<UserAnswerDto, bool>> filter = null);
       List<UserAnswerDto> GetQuizAnswersDetail(Expression<Func<UserAnswerDto, bool>> filter = null);
    }
}
