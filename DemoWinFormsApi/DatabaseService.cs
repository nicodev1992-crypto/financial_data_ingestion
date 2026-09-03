using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace DemoWinFormsApi
{
    public class DatabaseService
    {
        private readonly string connectionString = "Data Source=DemoDatabase.db";

        public DatabaseService()
        {
            InitializeSqlDatabase();
        }

        private void InitializeSqlDatabase()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                string createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Posts (
                        Id INTEGER PRIMARY KEY,
                        Title TEXT NOT NULL,
                        Body TEXT NOT NULL
                    );";

                using (var command = new SqliteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public async Task SaveDataToSqlAsync(List<PostDto> posts)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                await connection.OpenAsync();

                using (var transaction = connection.BeginTransaction())
                {
                    string insertQuery = "INSERT OR REPLACE INTO Posts (Id, Title, Body) VALUES (@Id, @Title, @Body);";

                    foreach (var post in posts)
                    {
                        using (var command = new SqliteCommand(insertQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Id", post.Id);
                            command.Parameters.AddWithValue("@Title", post.Title);
                            command.Parameters.AddWithValue("@Body", post.Body);
                            await command.ExecuteNonQueryAsync();
                        }
                    }
                    transaction.Commit();
                }
            }
        }

        public async Task<List<PostDto>> ReadDataFromSqlAsync()
        {
            var list = new List<PostDto>();

            using (var connection = new SqliteConnection(connectionString))
            {
                await connection.OpenAsync();
                string selectQuery = "SELECT Id, Title, Body FROM Posts;";

                using (var command = new SqliteCommand(selectQuery, connection))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        list.Add(new PostDto
                        {
                            Id = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            Body = reader.GetString(2)
                        });
                    }
                }
            }
            return list;
        }
    }
}