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

        public static int GetStudentCount()
        {
            using var conn = OpenConnection();
            using var cmd = new MySqlCommand("SELECT COUNT(*) FROM students", conn);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public static DataTable GetStudents()
        {
            using var conn = OpenConnection();
            using var cmd = new MySqlCommand(
                "SELECT id, studentCode, firstName, middleName, lastName, phone FROM students ORDER BY id DESC",
                conn
            );
            using var adapter = new MySqlDataAdapter(cmd);
            var table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public static int AddStudent(int studentCode, string firstName, string? middleName, string lastName, string? phone)
        {
            using var conn = OpenConnection();
            using var cmd = new MySqlCommand(
                "INSERT INTO students (studentCode, firstName, middleName, lastName, phone) VALUES (@code, @first, @middle, @last, @phone)",
                conn
            );
            cmd.Parameters.AddWithValue("@code", studentCode);
            cmd.Parameters.AddWithValue("@first", firstName);
            cmd.Parameters.AddWithValue("@middle", string.IsNullOrWhiteSpace(middleName) ? (object)DBNull.Value : middleName);
            cmd.Parameters.AddWithValue("@last", lastName);
            cmd.Parameters.AddWithValue("@phone", string.IsNullOrWhiteSpace(phone) ? (object)DBNull.Value : phone);
            return cmd.ExecuteNonQuery();
        }

        public static int UpdateStudent(int id, int studentCode, string firstName, string? middleName, string lastName, string? phone)
        {
            using var conn = OpenConnection();
            using var cmd = new MySqlCommand(
                "UPDATE students SET studentCode = @code, firstName = @first, middleName = @middle, lastName = @last, phone = @phone WHERE id = @id",
                conn
            );
            cmd.Parameters.AddWithValue("@code", studentCode);
            cmd.Parameters.AddWithValue("@first", firstName);
            cmd.Parameters.AddWithValue("@middle", string.IsNullOrWhiteSpace(middleName) ? (object)DBNull.Value : middleName);
            cmd.Parameters.AddWithValue("@last", lastName);
            cmd.Parameters.AddWithValue("@phone", string.IsNullOrWhiteSpace(phone) ? (object)DBNull.Value : phone);
            cmd.Parameters.AddWithValue("@id", id);
            return cmd.ExecuteNonQuery();
        }

        public static int DeleteStudent(int id)
        {
            using var conn = OpenConnection();
            using var cmd = new MySqlCommand("DELETE FROM students WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            return cmd.ExecuteNonQuery();
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

