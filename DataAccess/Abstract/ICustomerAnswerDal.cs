using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ICustomerAnswerDal : IEntityRepository<CustomerAnswer>
    {
       CustomerAnswerDto GetAnswerDetail(int id);
       List<CustomerAnswerDto> GetAllAnswersDetail(Expression<Func<CustomerAnswerDto, bool>> filter = null);
    }
}
