using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Entities.DTOs;
using Entities.Enums;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfQuizDal : EfEntityRepositoryBase<Quiz, QuizContext>, IQuizDal
    {
        /* public QuizDto GetQuizDetail(int id){
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
      //   public List<QuizDto> GetAllQuizzesDetail(Expression<Func<QuizDto, bool>> filter = null){
      //      using (QuizContext context= new QuizContext())
      //      {
      //          var result = from quiz in context.Quizzes
      //                let question = context.Questions.Where(i => i.QuizId==quiz.Id)
      //                where quiz.Status!=Status.DELETED
      //                select new QuizDto
      //                {
      //                    Id = quiz.Id,
      //                    UserId = quiz.UserId,
      //                    QuizName = quiz.QuizName,
      //                    QuizNumber = quiz.QuizNumber,
      //                    Questions = question.Select(x=>new QuestionDto
      //                    {
      //                        Id = x.Id,
      //                        IsTimeOver = x.IsTimeOver,
      //                        OperationDate = x.OperationDate,
      //                        QuestionContent = x.QuestionContent,
      //                        QuestionDuration = x.QuestionDuration,
      //                        QuestionImage = x.QuestionImage,
      //                        QuestionOptions =  context.QuestionOptions.Where(i => i.QuestionId == x.Id).ToList(),
      //                        QuestionScore = x.QuestionScore,
      //                        QuestionType = x.QuestionType
      //                    }).ToList(),
      //                    OperationDate = quiz.OperationDate,
      //                    Status = quiz.Status
      //                };
                  
      //            return filter==null
      //             ?result.ToList()
      //            :result.Where(filter).ToList();
      //        }
      //   }
      //}*/
        public QuizDto GetQuizDetail(int id)
        {
            throw new NotImplementedException();
        }

        public List<QuizDto> GetAllQuizzesDetail(Expression<Func<QuizDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
