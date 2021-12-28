using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class QuestionOptionManager : IQuestionOptionService
    {
        private readonly IQuestionOptionDal _questionOptionDal;

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
            entity.OperationDate = DateTime.Now;
            _questionOptionDal.Add(entity);
            return new SuccessResult(Messages.Added);
        }

        public IResult Update(QuestionOption entity)
        {
            entity.OperationDate = DateTime.Now;
            _questionOptionDal.Update(entity);
            return new SuccessResult(Messages.Updated);
        }

        public IResult Delete(QuestionOption entity)
        {
            _questionOptionDal.Delete(entity);
            return new SuccessResult(Messages.Deleted);
        }
        
        public IDataResult<List<QuestionOption>> MultiAdd(List<QuestionOption> questionOptions)
        {
            foreach (var questionOption in questionOptions)
            {
                questionOption.OperationDate = DateTime.Now;
                _questionOptionDal.Add(questionOption);
            }
            return new SuccessDataResult<List<QuestionOption>>(_questionOptionDal.GetAll(x=>x.QuestionId==questionOptions[0].QuestionId), Messages.Added);
        }

        public IDataResult<List<QuestionOption>> MultiUpdate(List<QuestionOption> questionOptions)
        {
            foreach (var questionOption in questionOptions)
            {
                questionOption.OperationDate = DateTime.Now;
                _questionOptionDal.Update(questionOption);
            }
            return new SuccessDataResult<List<QuestionOption>>(_questionOptionDal.GetAll(x => x.QuestionId == questionOptions[0].QuestionId), Messages.Added);
        }

        public IDataResult<List<QuestionOption>> GetQuestionOptionsByQuestionId(int questionId)
        {
            return new SuccessDataResult<List<QuestionOption>>(_questionOptionDal.GetAll(x => x.QuestionId == questionId), Messages.Added);
        }
    }
}
