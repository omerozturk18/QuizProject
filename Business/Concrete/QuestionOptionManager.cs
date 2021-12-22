using System;
using System.Collections.Generic;
using Business.Abstract;
using Core.Utilities.Results;
using Entities.DTOs;

namespace Business.Concrete
{
    public class QuestionOptionManager : IQuestionOptionService
    {
        public IDataResult<List<QuestionOptionDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<QuestionOptionDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Add(QuestionOptionDto entity)
        {
            throw new NotImplementedException();
        }

        public IResult Update(QuestionOptionDto entity)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(QuestionOptionDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
