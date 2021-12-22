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
        public IResult Add(QuestionDto entity)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(QuestionDto entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<QuestionDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<QuestionDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(QuestionDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
