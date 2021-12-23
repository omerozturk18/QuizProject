using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Core.Utilities.Results;
using Entities.DTOs;

namespace Business.Concrete
{
    public class QuestionManager : IQuestionService
    {
        IQuestionDal _questionDal;

        public QuestionManager(IQuestionDal questionDal)
        {
            _questionDal = questionDal;
        }

        public IResult Add(Question entity)
        {
            _questionDal.Add(entity);
            return new SuccessResult(Messages.Added);        }

        [SecuredOperation("admin")]
        public IResult Delete(Question entity)
        {
            _questionDal.Delete(entity);
            return new SuccessResult(Messages.Deleted);
        }

        [SecuredOperation("admin")]
        public IDataResult<List<Question>> GetAll()
        {
            return new SuccessDataResult<List<Question>>(_questionDal.GetAll(), Messages.Listed);
        }

        public IDataResult<Question> GetById(int id)
        {
            return new SuccessDataResult<Question>(_questionDal.Get(c => c.Id == id), Messages.Listed);
        }

        public IResult Update(Question entity)
        {
            _questionDal.Update(entity);
            return new SuccessResult(Messages.Updated);
        }

        public IDataResult<List<Question>> GetByQuizId(int quizId)
        {
            return new SuccessDataResult<List<Question>>(_questionDal.GetAll(c => c.QuizId == quizId), Messages.Listed);
        }

        public IDataResult<QuestionDto> GetQuestionDetail(int id)
        {
            return new SuccessDataResult<QuestionDto>(_quizDal.GetQuestionDetail(c => c.Id == id), Messages.Listed);
        }
    }
}
