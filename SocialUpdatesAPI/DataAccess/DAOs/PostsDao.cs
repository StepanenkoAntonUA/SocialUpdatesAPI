using Microsoft.Extensions.Configuration;
using System.IO;
using Models;
using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;
using System;

namespace DataAccess.DAOs
{
    public class PostsDao : IPostsDao
    {
        private readonly string _connectionString;
        public PostsDao() 
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            
            IConfiguration configuration = builder.Build();
            
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task<PlannedPost> SaveAsync(PlannedPost data)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var insertQuery = "INSERT INTO PlannedPost (Id, Post, PublishTime, RetryCount) VALUES (@Id, @Post, @PublishTime, @RetryCount)";
                int rowsAffected = db.Execute(insertQuery, data);

                db.Close();
                return data;
            }
        }
    }
}
