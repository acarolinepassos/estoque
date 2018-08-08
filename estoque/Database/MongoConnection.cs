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

        private class MongoClient
        {
            private object connectionString;

            public MongoClient(object connectionString)
            {
                this.connectionString = connectionString;
            }
        }
    }
}