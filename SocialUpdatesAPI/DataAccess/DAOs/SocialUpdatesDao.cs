using Common.Configuration;
using Dapper;
using Microsoft.Data.SqlClient;
using Models;
using System.Data;

namespace DataAccess.DAOs
{
    public class SocialUpdatesDao : ISocialUpdatesDao
    {
        private readonly string _connectionString;

        public SocialUpdatesDao(ConnectionStringDescriptor descriptor)
        {
            _connectionString = descriptor.ConnectionString;
        }

        public async Task<PlannedPostCreatedItem> SaveAsync(PlannedPostCreatedItem data)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var insertQuery = "INSERT INTO  SocialUpdates (Id, EventTime, Payload) VALUES (@Id, @EventTime, @Payload)";
                await db.ExecuteAsync(insertQuery, data);

                return data;
            }
        }
    }
}
