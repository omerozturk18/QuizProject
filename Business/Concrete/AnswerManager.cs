using System;
using System.Collections.Generic;
using Business.Abstract;
using Core.Utilities.Results;
using Entities.DTOs;

namespace Business.Concrete
{
    public class AnswerManager : IAnswerService
    {
        public IDataResult<List<AnswerDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<AnswerDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Add(AnswerDto entity)
        {
            throw new NotImplementedException();
        }

        public IResult Update(AnswerDto entity)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(AnswerDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
