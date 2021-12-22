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
    public class UserAnswerManager : IUserAnswerService
    {
        private readonly IUserAnswerDal _userAnswerDal;
        public UserAnswerManager(IUserAnswerDal userAnswerDal)
        {
            _userAnswerDal = userAnswerDal;
        }

        public IResult Add(UserAnswerDto entity)
        {
            UserAnswer userAnswer = new UserAnswer();
            _userAnswerDal.Add(userAnswer);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(UserAnswerDto entity)
        {
            UserAnswer userAnswer = new UserAnswer();
            _userAnswerDal.Delete(userAnswer);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<UserAnswerDto>> GetAll()
        {
            return new SuccessDataResult<List<UserAnswerDto>>(new List<UserAnswerDto>(), Messages.Listed);
        }

        public IDataResult<UserAnswerDto> GetById(int id)
        {
            _userAnswerDal.Get(c => c.Id == id);
            return new SuccessDataResult<UserAnswerDto>(new UserAnswerDto(), Messages.Listed);
        }

        public IResult Update(UserAnswerDto entity)
        {
            UserAnswer userAnswer = new UserAnswer();
            _userAnswerDal.Update(userAnswer);
            return new SuccessResult(Messages.Updated);
        }
    }
}
