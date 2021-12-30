using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IBaseService<TEntity>
    {
        IDataResult<List<TEntity>> GetAll();
        IDataResult<TEntity> GetById(string id);
        IResult Add(TEntity entity);
        IResult Update(TEntity entity);
        IResult Delete(TEntity entity);
    }
}
