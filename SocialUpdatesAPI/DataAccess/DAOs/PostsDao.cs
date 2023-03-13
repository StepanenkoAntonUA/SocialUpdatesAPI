using Microsoft.Extensions.Configuration;
using System.IO;
using Models;
using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;
using System;
using Common.Configuration;

namespace DataAccess.DAOs
{
    public class PostsDao : IPostsDao
    {
        private readonly string _connectionString;

        public PostsDao(ConnectionStringDescriptor descriptor) 
        {
            _connectionString = descriptor.ConnectionString;
        }

        public async Task<PlannedPost> SaveAsync(PlannedPost data)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var insertQuery = "INSERT INTO PlannedPost (Id, Post, PublishTime, RetryCount) VALUES (@Id, @Post, @PublishTime, @RetryCount)";
                await db.ExecuteAsync(insertQuery, data);

                return data;
            }
        }
    }
}
