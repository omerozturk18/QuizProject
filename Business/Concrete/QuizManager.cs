using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Core.Utilities.Results;
using Entities.DTOs;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Enums;

namespace Business.Concrete
{

    public class QuizManager : IQuizService
    {
        private readonly IMongoQuizDal _mongoQuizDal;

        public QuizManager( IMongoQuizDal mongoQuizDal)
        {
            _mongoQuizDal = mongoQuizDal;
        }

        public IResult Add(Quiz entity)
        {
            entity.QuizNumber = new Random(Guid.NewGuid().GetHashCode()).Next(10000000, 99999999).ToString();
            entity.OperationDate =DateTime.Now;
            entity.Status=Status.PASSIVE;
            _mongoQuizDal.Add(entity);
            return new SuccessResult(Messages.Added);
        }

        [SecuredOperation("admin")]
        public IResult Delete(Quiz entity)
        {
            entity.OperationDate = DateTime.Now;
            entity.Status=Status.DELETED;
            _mongoQuizDal.Update(entity);
            return new SuccessResult(Messages.Deleted);
           /* _quizDal.Delete(entity);
            return new SuccessResult(Messages.Deleted);*/
        }

        [SecuredOperation("admin")]
        public IDataResult<List<Quiz>> GetAll()
        {
            return new SuccessDataResult<List<Quiz>>(_mongoQuizDal.GetAll(), Messages.Listed);
        }

        [SecuredOperation("admin,user")]
        public IDataResult<Quiz> GetById(string id)
        {
            return new SuccessDataResult<Quiz>(_mongoQuizDal.Get(c => c.Id == id), Messages.Listed);
        }

        [SecuredOperation("admin,user")]

        public IResult Update(Quiz entity)
        {
            entity.OperationDate = DateTime.Now;
            _mongoQuizDal.Update(entity);
            return new SuccessResult(Messages.Updated);
        }

        public IDataResult<Quiz> IsThereQuiz(string quizNumber)
        {
            var quiz = _mongoQuizDal.Get(c => c.QuizNumber == quizNumber && c.Status == Status.ACTIVE);
            if (quiz==null)
            {
                return new ErrorDataResult<Quiz>(Messages.QuizNotFound);
            }
            return new SuccessDataResult<Quiz>(quiz);
        }

        public IDataResult<Quiz> GetQuizByQuizNumber(string quizNumber,Status status)
        {
            var quiz = _mongoQuizDal.Get(c => c.QuizNumber == quizNumber && c.Status == status);
            if (quiz == null)
            {
                return new ErrorDataResult<Quiz>(Messages.QuizNotFound);
            }
            return new SuccessDataResult<Quiz>(quiz);
        }


        public IResult ActivatedQuiz(string id)
        {
            var quiz = _mongoQuizDal.Get(c => c.Id == id && c.Status == Status.PASSIVE);
            if(quiz == null)
            {
                return new ErrorResult(Messages.QuizNotFound);
            }
            quiz.Status=Status.ACTIVE;
            _mongoQuizDal.Update(quiz);
            return new SuccessResult(Messages.ActivatedQuiz);
        }

         public IResult StartedQuiz(string id)
        {
            var quiz = _mongoQuizDal.Get(c => c.Id == id && c.Status == Status.ACTIVE);
            if(quiz == null)
            {
                return new ErrorResult(Messages.QuizNotFound);
            }
            quiz.Status=Status.STARTED;
            _mongoQuizDal.Update(quiz);
            return new SuccessResult(Messages.StartedQuiz);
        }

         public IResult CompletedQuiz(string id)
        {
            var quiz = _mongoQuizDal.Get(c => c.Id == id && c.Status == Status.STARTED);
            if(quiz == null)
            {
                return new ErrorResult(Messages.QuizNotFound);
            }
            quiz.Status=Status.COMPLETED;
            _mongoQuizDal.Update(quiz);
            return new SuccessResult(Messages.CompletedQuiz);
        }

         public IDataResult<List<Quiz>> GetByUserQuizzes(int id)
        {
            return new SuccessDataResult<List<Quiz>>(_mongoQuizDal.GetAll(x=>x.UserId== id && x.Status != Status.DELETED), Messages.Listed);
        }
    }
}
