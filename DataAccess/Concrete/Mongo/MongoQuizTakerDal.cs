using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Operations;

namespace DataAccess.Concrete.Mongo
{
   public class MongoQuizTakerDal:IMongoQuizTakerDal
    {
        private readonly QuizMongoContext _context = null;

        public MongoQuizTakerDal()
        {
            _context = new QuizMongoContext();
        }
         public List<QuizTaker> GetAll(Expression<Func<QuizTaker, bool>> filter = null)
        {
            try
            {
                return filter == null
                    ? _context.QuizTakers.Find(_=>true).ToList()
                    : _context.QuizTakers.AsQueryable<QuizTaker>().Where(filter).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public QuizTaker Get(Expression<Func<QuizTaker, bool>> filter)
        {
            try
            {
                return _context.QuizTakers
                    .Find(filter)
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public QuizTaker Add(QuizTaker item)
        {
            try
            {
                 _context.QuizTakers.InsertOne(item);
                 return item;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public bool Delete(string id)
        {
            try
            {
                DeleteResult actionResult =  _context.QuizTakers.DeleteOne(
                        Builders<QuizTaker>.Filter.Eq("Id", id));

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public bool Update(QuizTaker item)
        {
            try
            {
                ReplaceOneResult actionResult =  _context.QuizTakers.ReplaceOne(b => b.Id == item.Id, item);

                return actionResult.IsAcknowledged
                       && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }
    }
}