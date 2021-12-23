using System;
using System.Collections.Generic;
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
        private readonly IQuizDal _quizDal;

        public QuizManager(IQuizDal quizDal)
        {
            _quizDal = quizDal;
        }

        public IResult Add(Quiz entity)
        {
            entity.QuizNumber =new Random(Guid.NewGuid().GetHashCode()).Next(0, 10).ToString();
            entity.OperationDate =DateTime.Now;
            entity.Status=Status.PASSIVE;
            _quizDal.Add(entity);
            return new SuccessResult(Messages.Added);
        }

        [SecuredOperation("admin")]
        public IResult Delete(Quiz entity)
        {
            entity.OperationDate = DateTime.Now;
            entity.Status=Status.DELETED;
            _quizDal.Update(entity);
            return new SuccessResult(Messages.Deleted);
           /* _quizDal.Delete(entity);
            return new SuccessResult(Messages.Deleted);*/
        }

        [SecuredOperation("admin")]
        public IDataResult<List<Quiz>> GetAll()
        {
            return new SuccessDataResult<List<Quiz>>(_quizDal.GetAll(), Messages.Listed);
        }
        
        [SecuredOperation("admin")]
        public IDataResult<Quiz> GetById(int id)
        {
            return new SuccessDataResult<Quiz>(_quizDal.Get(c => c.Id == id), Messages.Listed);
        }

        public IResult Update(Quiz entity)
        {
            _quizDal.Update(entity);
            return new SuccessResult(Messages.Updated);
        }

        public IDataResult<Quiz> IsThereQuiz(string quizNumber)
        {
            return new SuccessDataResult<Quiz>(_quizDal.Get(c => c.QuizNumber == quizNumber && c.Status == Status.ACTIVE), Messages.Listed);
        }

        public IDataResult<QuizDto> GetQuizDetail(int id)
        {
            return new SuccessDataResult<QuizDto>(_quizDal.GetQuizDetail(id), Messages.Listed);
        }
        
        public IResult ActivatedQuiz(int id)
        {
            var quiz = _quizDal.Get(c => c.Id == id && c.Status == Status.PASSIVE);
            if(quiz == null) return new ErrorResult(Messages.NotQuiz);
            quiz.Status=Status.ACTIVE;
            _quizDal.Update(quiz);
            return new SuccessResult(Messages.ActivatedQuiz);
        }

         public IResult StartedQuiz(int id)
        {
            var quiz = _quizDal.Get(c => c.Id == id && c.Status == Status.ACTIVE);
            if(quiz == null) return new ErrorResult(Messages.NotQuiz);
            quiz.Status=Status.STARTED;
            _quizDal.Update(quiz);
            return new SuccessResult(Messages.StartedQuiz);
        }

         public IResult CompletedQuiz(int id)
        {
            var quiz = _quizDal.Get(c => c.Id == id && c.Status == Status.STARTED);
            if(quiz == null) return new ErrorResult(Messages.NotQuiz);
            quiz.Status=Status.COMPLETED;
            _quizDal.Update(quiz);
            return new SuccessResult(Messages.CompletedQuiz);
        }
    }
}
