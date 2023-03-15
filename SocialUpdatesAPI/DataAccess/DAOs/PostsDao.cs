using Common.Configuration;
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

        public async Task<List<PlannedPost>> GetPostsAsync(int delay)
        {
            var minTime = DateTime.UtcNow.Subtract(TimeSpan.FromSeconds(delay));
            var maxTime = DateTime.UtcNow.AddSeconds(delay);

            var result = new List<PlannedPost>();
            var parameters = new DynamicParameters();
            parameters.Add("@minTime", minTime);
            parameters.Add("@maxTime", maxTime);

            var selectQuery = @"SELECT [Id], [Post], [PublishTime], [RetryCount] FROM [dto].[PlannedPost]
 WHERE [PublishTime] BETWEEN @minTime AND @maxTime"; // меньше конкатенаций строки

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                result.AddRange(await db.QueryAsync<PlannedPost>(selectQuery, parameters));
                return result;
            }
        }
    }
}
