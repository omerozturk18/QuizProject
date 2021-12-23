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
    public class EfUserAnswerDal : EfEntityRepositoryBase<UserAnswer, QuizContext>, IUserAnswerDal
    {
       public UserAnswerDto GetAnswerDetail(int id){
          using (QuizContext context= new QuizContext())
            {
                var result = from car in context.UserAnswers
                            /* join b in context.Brands on car.BrandId equals b.BrandId
                             join c in context.Colors on car.ColorId equals c.ColorId
                             join cI in context.CarImages on car.CarId equals cI.CarId into gr
                             from cI in gr.DefaultIfEmpty()*/
                             select new UserAnswerDto
                             {
                             };


                return result.First() != null ? result.First() : null;
            }
       }
       public List<UserAnswerDto> GetAllAnswersDetail(Expression<Func<UserAnswerDto, bool>> filter = null){
          using (QuizContext context= new QuizContext())
            {
                var result = from car in context.UserAnswers
                            /* join b in context.Brands on car.BrandId equals b.BrandId
                             join c in context.Colors on car.ColorId equals c.ColorId
                             join cI in context.CarImages on car.CarId equals cI.CarId into gr
                             from cI in gr.DefaultIfEmpty()*/
                             select new UserAnswerDto
                             {
                             };


                return filter==null
                ?result.ToList()
                :result.Where(filter).ToList();
            }
       }
    }
}
