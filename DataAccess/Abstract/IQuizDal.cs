using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IQuizDal:IEntityRepository<Quiz>
    {
     QuizDto GetQuizDetail(int id);
     List<QuizDto> GetAllQuizesDetail(Expression<Func<QuizDto, bool>> filter = null);
    }
}
