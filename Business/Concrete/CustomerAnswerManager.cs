using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CustomerAnswerManager : ICustomerAnswerService
    {
        private readonly ICustomerAnswerDal _customerAnswerDal;
        public CustomerAnswerManager(ICustomerAnswerDal customerAnswerDal)
        {
            _customerAnswerDal = customerAnswerDal;
        }

        public IResult Add(CustomerAnswer entity)
        {
            entity.OperationDate = DateTime.Now;
            _customerAnswerDal.Add(entity);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(CustomerAnswer entity)
        {
            _customerAnswerDal.Delete(entity);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<CustomerAnswer>> GetAll()
        {
            return new SuccessDataResult<List<CustomerAnswer>>(_customerAnswerDal.GetAll(), Messages.Listed);
        }

        public IDataResult<CustomerAnswer> GetById(int id)
        {
            return new SuccessDataResult<CustomerAnswer>(_customerAnswerDal.Get(c => c.Id == id), Messages.Listed);
        }

        public IResult Update(CustomerAnswer entity)
        {
            entity.OperationDate = DateTime.Now;
            _customerAnswerDal.Update(entity);
            return new SuccessResult(Messages.Updated);
        }

        public IDataResult<CustomerAnswerDto> GetAnswerDetail( int id)
        {
            return new SuccessDataResult<CustomerAnswerDto>(_customerAnswerDal.GetAnswerDetail(id), Messages.Listed);
        }

        public IDataResult<List<CustomerAnswerDto>> GetCustomerAnswersDetail( int userId)
        {
            return new SuccessDataResult<List<CustomerAnswerDto>>(_customerAnswerDal.GetAllAnswersDetail(c => c.User.Id == userId), Messages.Listed);
        }

        public IDataResult<List<CustomerAnswerDto>> GetQuestionAnswersDetail( int questionId)
        {
            return new SuccessDataResult<List<CustomerAnswerDto>>(_customerAnswerDal.GetAllAnswersDetail(c => c.Question.Id == questionId), Messages.Listed);
        }
        
        public IDataResult<List<CustomerAnswerDto>> GetQuizAnswersDetail( int quizId )
        {
            return new SuccessDataResult<List<CustomerAnswerDto>>(_customerAnswerDal.GetAllAnswersDetail(c => c.Quiz.Id == quizId), Messages.Listed);
        }
    }
}
