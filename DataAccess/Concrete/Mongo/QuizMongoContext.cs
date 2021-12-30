using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace DataAccess.Concrete.EntityFramework
{
    public class QuizMongoContext: DbContext
    {
        private readonly IMongoDatabase _database = null;

        public QuizMongoContext()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            if (client != null)
                _database = client.GetDatabase("QuizDB");
        }

        public IMongoCollection<Quiz> Quizzes
        {
            get { return _database.GetCollection<Quiz>("Quizzes"); }
        }

        public IMongoCollection<QuizTaker> QuizTakers
        {
            get { return _database.GetCollection<QuizTaker>("QuizTakers"); }

        }

    }
}