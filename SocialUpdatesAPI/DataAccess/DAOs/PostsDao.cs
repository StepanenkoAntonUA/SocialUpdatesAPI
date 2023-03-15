﻿using Common.Configuration;
using Dapper;
using Microsoft.Data.SqlClient;
using Models;
using System.Data;

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
                var insertQuery = "INSERT INTO  PlannedPost (Id, Post, PublishTime, RetryCount) VALUES (@Id, @Post, @PublishTime, @RetryCount)";
                await db.ExecuteAsync(insertQuery, data);

                return data;
            }
        }

        public async Task<IEnumerable<PlannedPost>> GetPostsAsync(int delay)
        {
            var minData = DateTime.UtcNow.Subtract(TimeSpan.FromSeconds(delay));
            var maxData = DateTime.UtcNow.AddSeconds(delay);
            var result = new List<PlannedPost>();
            var parameters = new DynamicParameters();
            parameters.Add("@minData", minData);
            parameters.Add("@maxData", maxData);

            var selectQuery = "SELECT [Id], [Post], [PublishTime], [RetryCount] FROM PlannedPost " +
                   "WHERE IsPosted IS NULL AND (PublishTime BETWEEN @minData AND @maxData)";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return await db.QueryAsync<PlannedPost>(selectQuery, parameters);
            }
        }

        public async Task SetIsPostedAsync(Guid id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var updateQuery = "UPDATE PlannedPost set IsPosted = 1 where Id = @id";
                await db.ExecuteAsync(updateQuery, parameters);
            }
        }
    }
}
