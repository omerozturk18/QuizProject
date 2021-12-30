using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Operations;

namespace DataAccess.Concrete.Mongo
{
   public class MongoQuizDal:IMongoQuizDal
    {
        private readonly QuizMongoContext _context = null;

        public MongoQuizDal()
        {
            _context = new QuizMongoContext();
        }
        public List<Quiz> GetAll(Expression<Func<Quiz, bool>> filter = null)
        {
            try
            {
                return filter == null
                    ? _context.Quizzes.Find(_=>true).ToList()
                    : _context.Quizzes.AsQueryable<Quiz>().Where(filter).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Quiz Get(Expression<Func<Quiz, bool>> filter)
        {
            try
            {
                return _context.Quizzes
                    .Find(filter)
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Quiz Add(Quiz item)
        {
            try
            {
                 _context.Quizzes.InsertOne(item);
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
                DeleteResult actionResult =  _context.Quizzes.DeleteOne(
                        Builders<Quiz>.Filter.Eq("Id", id));

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public bool Update(Quiz item)
        {
            try
            {
                ReplaceOneResult actionResult =  _context.Quizzes.ReplaceOne(b => b.Id == item.Id, item);

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