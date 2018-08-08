using Database.Properties;
using DCouple.Mongo;
using Model;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;


namespace Database
{
    public class MongoConnection
    {
        protected static IMongoDatabase GetConnection()
        {
            return new MongoClient(Settings.Default.connectionString).GetDatabase(Settings.Default.name);
        }


        public static bool InsertOne<BsonDocument>(string name, BsonDocument document)
        {
            try
            {
                IMongoDatabase _database = GetConnection();

                var collection = _database.GetCollection<BsonDocument>(name);
                collection.InsertOne(document);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<BsonDocument> QueryCollection<BsonDocument>(string name, FilterDefinition<BsonDocument> filter, int? limit)
        {
            try
            {
                IMongoDatabase _database = GetConnection();

                return _database.GetCollection<BsonDocument>(name).Find(filter).Limit(limit).ToListAsync().Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

<<<<<<< HEAD
        private class MongoClient
        {
            private object connectionString;
=======
        public static bool DeleteOne<BsonDocument>(string name, FilterDefinition<BsonDocument> filter)
        {
            try
            {
                IMongoDatabase _database = GetConnection();

                var collection = _database.GetCollection<BsonDocument>(name);
                collection.DeleteOne(filter);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ReplaceOne<BsonDocument>(string name, FilterDefinition<BsonDocument> filter, BsonDocument document)
        {
            try
            {
                IMongoDatabase _database = GetConnection();

                var collection = _database.GetCollection<BsonDocument>(name);
                collection.ReplaceOne(filter, document);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

>>>>>>> 33590592705d603b83602c50adc4c26214cb35f9

            public MongoClient(object connectionString)
            {
                this.connectionString = connectionString;
            }
        }
    }
}
