using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Core.Utilities.Results;
using Entities.DTOs;
using DataAccess.Abstract;

namespace Business.Concrete
{

    public class QuizManager : IQuizService
    {
        IQuizDal _quizDal;

        public QuizManager(IQuizDal quizDal)
        {
            _quizDal = quizDal;
        }

        public IResult Add(Quiz entity)
        {
            _quizDal.Add(entity);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Quiz entity)
        {
            _quizDal.Delete(entity);
            return new SuccessResult(Messages.Added);
        }

        public IDataResult<List<Quiz>> GetAll()
        {
            return new SuccessDataResult<List<Quiz>>(_quizDal.GetAll(), Messages.Listed);
        }

        public IDataResult<Quiz> GetById(int id)
        {
            return new SuccessDataResult<Quiz>(_quizDal.Get(c => c.Id == id), Messages.Listed);
        }

        public IResult Update(Quiz entity)
        {
            _quizDal.Update(entity);
            return new SuccessResult(Messages.Added);
        }
    }
}
