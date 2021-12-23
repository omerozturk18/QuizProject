using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfQuizDal : EfEntityRepositoryBase<Quiz, QuizContext>, IQuizDal
    {
       public QuizDto GetQuizDetail(int id){
          using (QuizContext context= new QuizContext())
            {
                var result = from car in context.Quizzes
                    where car.Id == id
                             select new QuizDto
                             {
                             };


                return result.First() != null ? result.First() : null;
            }
       }
       public List<QuizDto> GetAllQuizzesDetail(Expression<Func<QuizDto, bool>> filter = null){
          using (QuizContext context= new QuizContext())
            {
                var result = from car in context.Quizzes
                            /* join b in context.Brands on car.BrandId equals b.BrandId
                             join c in context.Colors on car.ColorId equals c.ColorId
                             join cI in context.CarImages on car.CarId equals cI.CarId into gr
                             from cI in gr.DefaultIfEmpty()*/
                             select new QuizDto
                             {
                             };


                return filter==null
                ?result.ToList()
                :result.Where(filter).ToList();
            }
       }
    }
}
