using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class QuestionManager : IQuestionService
    {
        private readonly IQuestionDal _questionDal;

        public QuestionManager(IQuestionDal questionDal)
        {
            _questionDal = questionDal;
        }

        public IResult Add(Question entity)
        {
            entity.OperationDate=DateTime.Now;
            _questionDal.Add(entity);
            return new SuccessResult(Messages.Added);   
        }

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
            entity.OperationDate = DateTime.Now;
            _questionDal.Update(entity);
            return new SuccessResult(Messages.Updated);
        }

        public IDataResult<Question> AddQuestion(Question question)
        {
            question.OperationDate = DateTime.Now;
            return new SuccessDataResult<Question>(_questionDal.AddEntity(question));
        }

        public IDataResult<List<Question>> GetByQuizId(int quizId)
        {
            return new SuccessDataResult<List<Question>>(_questionDal.GetAll(c => c.QuizId == quizId), Messages.Listed);
        }

        public IDataResult<List<QuestionDto>> GetQuestionsDetailByQuizId(int quizId)
        {
            return new SuccessDataResult<List<QuestionDto>>(_questionDal.GetAllQuestionsDetail(x=>x.QuizId==quizId), Messages.Listed);
        }

        public IDataResult<QuestionDto> GetQuestionDetail(int id)
        {
            return new SuccessDataResult<QuestionDto>(_questionDal.GetQuestionDetail(id), Messages.Listed);
        }
    }
}
