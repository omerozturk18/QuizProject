using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IQuizDal : IEntityRepository<Quiz>
    {
        QuizDto GetQuizDetail(int id);
        List<QuizDto> GetAllQuizzesDetail(Expression<Func<QuizDto, bool>> filter = null);
    }
}
