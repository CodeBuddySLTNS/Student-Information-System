namespace Student_Information_System
{
    using MySql.Data.MySqlClient;
    using System.Security.Cryptography;
    using System.Text;

    public static class Database
    {
        private static readonly string _connectionString =
            "server=localhost;port=3306;database=student_information_system;user id=root;password=;SslMode=none;";

        public static MySqlConnection OpenConnection()
        {
            var connection = new MySqlConnection(_connectionString);
            connection.Open();
            return connection;
        }

        public static bool ValidateUserCredentials(string username, string password)
        {
            using var connection = OpenConnection();
            string passwordHash = ComputeMd5(password);
            const string sql = "SELECT 1 FROM users WHERE username = @username AND password_hash = @password_hash LIMIT 1";
            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password_hash", passwordHash);
            using var reader = command.ExecuteReader();
            return reader.Read();
        }

        private static string ComputeMd5(string input)
        {
            using var md5 = MD5.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            byte[] hash = md5.ComputeHash(bytes);
            var builder = new StringBuilder(hash.Length * 2);
            for (int i = 0; i < hash.Length; i++)
            {
                builder.Append(hash[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}

