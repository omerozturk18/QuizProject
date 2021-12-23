using System;
using System.Collections.Generic;
using Business.Abstract;
using Core.Utilities.Results;
using Entities.DTOs;

namespace Business.Concrete
{
    public class QuestionOptionManager : IQuestionOptionService
    {
        IQuestionOptionDal _questionOptionDal;

        public QuestionOptionManager(IQuestionOptionDal questionOptionDal)
        {
            _questionOptionDal = questionOptionDal;
        }

        [SecuredOperation("admin")]
        public IDataResult<List<QuestionOption>> GetAll()
        {
            return new SuccessDataResult<List<QuestionOption>>(_questionOptionDal.GetAll(), Messages.Listed);
        }

        [SecuredOperation("admin")]
        public IDataResult<QuestionOption> GetById(int id)
        {
            return new SuccessDataResult<QuestionOption>(_questionOptionDal.Get(c => c.Id == id), Messages.Listed);
        }

        public IResult Add(QuestionOption entity)
        {
            _questionOptionDal.Add(entity);
            return new SuccessResult(Messages.Added);
        }

        public IResult Update(QuestionOption entity)
        {
            _questionOptionDal.Update(entity);
            return new SuccessResult(Messages.Updated);
        }

        public IResult Delete(QuestionOption entity)
        {
            _questionOptionDal.Delete(entity);
            return new SuccessResult(Messages.Deleted);
        }
    }
}
