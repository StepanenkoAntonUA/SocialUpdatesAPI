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
            // понятие Configuration, и особенно appsettings - обязательно должно встречаться только на уровне конфигурации - program.cs и старт приложения. Вынести туда.
            // и передавать Connection String в конструктор в виде некого ConnectionStringDescriptor class, через IoC
            // никогда не стоит лезть в конфигурацию инстанса, на уровне далее чем старт и запуск приложение, если это конфигурация не в БД (через Configuration Store)
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            
            IConfiguration configuration = builder.Build();
            
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<PlannedPost> SaveAsync(PlannedPost data)
        {
            // метод async, а Execute используется не async. Надо async
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var insertQuery = "INSERT INTO PlannedPost (Id, Post, PublishTime, RetryCount) VALUES (@Id, @Post, @PublishTime, @RetryCount)";
                db.Execute(insertQuery, data);

                db.Close(); // не обязательно если есть using (SqlConnection.Dispose закрывает сам, потому IDisposable)
                return data;
            }
        }
    }
}
