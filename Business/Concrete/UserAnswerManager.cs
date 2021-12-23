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

        public IResult Add(UserAnswer entity)
        {
            _userAnswerDal.Add(entity);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(UserAnswer entity)
        {
            _userAnswerDal.Delete(entity);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<UserAnswer>> GetAll()
        {
            return new SuccessDataResult<List<UserAnswer>>(_userAnswerDal.GetAll(), Messages.Listed);
        }

        public IDataResult<UserAnswer> GetById(int id)
        {
            return new SuccessDataResult<UserAnswer>(_userAnswerDal.Get(c => c.Id == id), Messages.Listed);
        }

        public IResult Update(UserAnswer entity)
        {
            _userAnswerDal.Update(entity);
            return new SuccessResult(Messages.Updated);
        }

        public IDataResult<UserAnswerDto> GetAnswerDetail( int id)
        {
            return new SuccessDataResult<UserAnswerDto>(_userAnswerDal.GetAnswerDetail(id), Messages.Listed);
        }

        public IDataResult<List<UserAnswerDto>> GetUserAnswersDetail( int userId)
        {
            return new SuccessDataResult<List<UserAnswerDto>>(_userAnswerDal.GetAllAnswersDetail(c => c.User.Id == id), Messages.Listed);
        }

        public IDataResult<List<UserAnswerDto>> GetQuestionAnswersDetail( int questionId)
        {
            return new SuccessDataResult<List<UserAnswerDto>>(_userAnswerDal.GetAllAnswersDetail(c => c.Question.Id == id), Messages.Listed);
        }
        
        public IDataResult<List<UserAnswerDto>> GetQuizAnswersDetail( int quizId )
        {
            return new SuccessDataResult<List<UserAnswerDto>>(_userAnswerDal.GetAllAnswersDetail(c => c.Quiz.Id == id), Messages.Listed);
        }
    }
}
