using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Core.Utilities.Results;
using Entities.DTOs;

namespace Business.Concrete
{
    public class QuizManager : IQuizService
    {
        public IResult Add(QuizDto entity)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(QuizDto entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<QuizDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<QuizDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(QuizDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
