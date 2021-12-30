using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class QuizTakerManager : IQuizTakerService
    {
        private readonly IMongoQuizTakerDal _quizTakerDal;
        public QuizTakerManager(IMongoQuizTakerDal quizTakerDal)
        {
            _quizTakerDal = quizTakerDal;
        }

        public IResult Add(QuizTaker entity)
        {
            _quizTakerDal.Add(entity);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(QuizTaker entity)
        {
            _quizTakerDal.Delete(entity.Id);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<QuizTaker> IsThereUserInQuiz(QuizTaker quizTaker)
        {
            var result = _quizTakerDal.Get(x => x.UserName == quizTaker.UserName && x.QuizNumber == quizTaker.QuizNumber);
            if (result!=null)
            {
                return new ErrorDataResult<QuizTaker>("Bu İsim Kullanılmaktadır");
            }
            else
            {
                 quizTaker = _quizTakerDal.Add(quizTaker);
                return new SuccessDataResult<QuizTaker>(quizTaker,"Sınava Giriş Başarılı, Lütfen Bekleyiniz");
            }
            
        }

        public IDataResult<List<QuizTaker>> IsThereUserInQuizList(QuizTaker quizTaker)
        {
            var result = _quizTakerDal.Get(x => x.UserName == quizTaker.UserName && x.QuizNumber == quizTaker.QuizNumber);
            if (result != null)
            {
                return new ErrorDataResult<List<QuizTaker>>("Bu İsim Kullanılmaktadır");
            }
            else
            {
                quizTaker = _quizTakerDal.Add(quizTaker);
                return new SuccessDataResult<List<QuizTaker>>(_quizTakerDal.GetAll(x => x.QuizNumber == quizTaker.QuizNumber), "Sınava Giriş Başarılı, Lütfen Bekleyiniz");
            }
        }

        public IDataResult<List<QuizTaker>> GetAllQuizTakerByQuizNumber(string quizNumber)
        {
            return new SuccessDataResult<List<QuizTaker>>(_quizTakerDal.GetAll(x=>x.QuizNumber==quizNumber), Messages.Listed);
        }

        public IDataResult<List<QuizTaker>> GetAll()
        {
            return new SuccessDataResult<List<QuizTaker>>(_quizTakerDal.GetAll(), Messages.Listed);
        }

        public IDataResult<QuizTaker> GetById(string id)
        {
            return new SuccessDataResult<QuizTaker>(_quizTakerDal.Get(c => c.Id == id), Messages.Listed);
        }

        public IResult Update(QuizTaker entity)
        {
            _quizTakerDal.Update(entity);
            return new SuccessResult(Messages.Updated);
        }
    }
}
