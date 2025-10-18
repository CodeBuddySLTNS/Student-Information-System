namespace Student_Information_System
{
    using MySql.Data.MySqlClient;
    using System.Data;
    using System.Security.Cryptography;
    using System.Text;

    public static class Database
    {
        private static readonly string _connectionString =
            "server=localhost;port=3306;database=infosys;user id=root;password=;SslMode=none;";

        public static MySqlConnection OpenConnection()
        {
            var connection = new MySqlConnection(_connectionString);
            connection.Open();
            return connection;
        }

        public static DataTable ExecuteQuery(string sql, MySqlParameter[] parameters)
        {
          
                using var conn = OpenConnection();
                using var cmd = new MySqlCommand(sql, conn);

                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                using var adapter = new MySqlDataAdapter(cmd);
                var table = new DataTable();
                adapter.Fill(table);
                return table;
        }

        public static int ExecuteNonQuery(string sql, MySqlParameter[] parameters)
        {
            using var conn = OpenConnection();
            using var cmd = new MySqlCommand(sql, conn);

            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }

            return cmd.ExecuteNonQuery();
        }

        //
        // User CRUD operations
        //

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
            return ExecuteQuery("SELECT s.id, s.studentCode, s.firstName, s.middleName, s.lastName, d.id AS departmentId, d.departmentName, s.phone " +
                "FROM students s INNER JOIN departments d ON s.departmentId = d.id ORDER BY s.id DESC", []);
        }

        public static int AddStudent(int departmentId, int studentCode, string firstName, string? middleName, string lastName, string? phone)
        {
            return ExecuteNonQuery(
                "INSERT INTO students (departmentId, studentCode, firstName, middleName, lastName, phone) VALUES (@departmentId, @code, @first, @middle, @last, @phone)",
                new MySqlParameter[]
                {
                    new MySqlParameter("@departmentId", departmentId),
                    new MySqlParameter("@code", studentCode),
                    new MySqlParameter("@first", firstName),
                    new MySqlParameter("@middle", string.IsNullOrWhiteSpace(middleName) ? (object)DBNull.Value : middleName),
                    new MySqlParameter("@last", lastName),
                    new MySqlParameter("@phone", string.IsNullOrWhiteSpace(phone) ? (object)DBNull.Value : phone)
                }
            );
        }

        public static int UpdateStudent(int id, int departmentId, int studentCode, string firstName, string? middleName, string lastName, string? phone)
        {
           return ExecuteNonQuery(
                "UPDATE students SET departmentId = @departmentId, studentCode = @code, firstName = @first, middleName = @middle, lastName = @last, phone = @phone WHERE id = @id",
                new MySqlParameter[]
                {
                    new MySqlParameter("@id", id),
                    new MySqlParameter("@departmentId", departmentId),
                    new MySqlParameter("@code", studentCode),
                    new MySqlParameter("@first", firstName),
                    new MySqlParameter("@middle", string.IsNullOrWhiteSpace(middleName) ? (object)DBNull.Value : middleName),
                    new MySqlParameter("@last", lastName),
                    new MySqlParameter("@phone", string.IsNullOrWhiteSpace(phone) ? (object)DBNull.Value : phone)
                }
            );
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


        //
        // Departments CRUD operations
        //

        public static DataTable GetDepartments()
        {
            return ExecuteQuery("SELECT * FROM departments", []);
        }


        //
        // Courses CRUD operations
        //

        public static DataTable GetCourses()
        {
            return ExecuteQuery("SELECT * from courses ORDER BY id DESC", []);
        }

        public static int AddCourse(string courseCode, string courseName, int units)
        {
            return ExecuteNonQuery(
                "INSERT INTO courses (courseCode, courseName, units) VALUES (@courseCode, @courseName, @units)", new MySqlParameter[]
                {
                    new MySqlParameter("@courseCode", courseCode),
                    new MySqlParameter("@courseName", courseName),
                    new MySqlParameter("@units", units)
                });
        }

        public static int UpdateCourse(int id, string courseCode, string courseName, int units)
        {
            return ExecuteNonQuery(
                "UPDATE courses SET courseCode = @courseCode, courseName = @courseName, units = @units WHERE id = @id", new MySqlParameter[]
                {
                    new MySqlParameter("@courseCode", courseCode),
                    new MySqlParameter("@courseName", courseName),
                    new MySqlParameter("@units", units),
                    new MySqlParameter("@id", id)
                });
        }

        public static int DeleteCourse(int id)
        {
            return ExecuteNonQuery(
                "DELETE FROM courses WHERE id = @id", new MySqlParameter[]
                {
                    new MySqlParameter("@id", id)
                });
        }


        //
        // SchoolYear CRUD operations
        //

        public static DataTable GetSchoolYears()
        {
            return ExecuteQuery("SELECT * FROM schoolYears", []);
        }

        public static int AddSchoolYear(string name)
        {
            return ExecuteNonQuery("INSERT INTO schoolYears (name) VALUES (@name)", new MySqlParameter[]
            {
                new MySqlParameter("@name", name)
            });
        }

        public static int UpdateSchoolYear(int id, string name)
        {
            return ExecuteNonQuery("UPDATE schoolYears SET name = @name WHERE id = @id", new MySqlParameter[]
            {
                new MySqlParameter("@name", name),
                new MySqlParameter("@id", id)
            });
        }

        public static int DeleteSchoolYear(int id)
        {
            return ExecuteNonQuery("DELETE FROM schoolYears WHERE id = @id", new MySqlParameter[]
            {
                new MySqlParameter("@id", id)
            });
        }

        //
        // Faculty CRUD operations
        //

        public static DataTable GetFaculties()
        {
            return ExecuteQuery("SELECT * from faculty ORDER BY id DESC", []);
        }

        public static int AddFaculty(string firstName, string? middleName, string lastName)
        {
            return ExecuteNonQuery(
                "INSERT INTO faculty (firstName, middleName, lastName) VALUES (@firstName, @middleName, @lastName)", new MySqlParameter[]
                {
                    new MySqlParameter("@firstName", firstName),
                    new MySqlParameter("@middleName", middleName),
                    new MySqlParameter("@lastName", lastName)
                });
        }

        public static int UpdateFaculty(int id, string firstName, string? middleName, string lastName)
        {
            return ExecuteNonQuery(
                "UPDATE faculty SET firstName = @firstName, middleName = @middleName, lastName = @lastName WHERE id = @id", new MySqlParameter[]
                {
                    new MySqlParameter("@firstName", firstName),
                    new MySqlParameter("@middleName", middleName),
                    new MySqlParameter("@lastName", lastName),
                    new MySqlParameter("@id", id)
                });
        }

        public static int DeleteFaculty(int id)
        {
            return ExecuteNonQuery(
                "DELETE FROM faculty WHERE id = @id", new MySqlParameter[]
                {
                    new MySqlParameter("@id", id)
                });
        }


        //
        // Classes CRUD operations
        //

        public static DataTable GetClasses()
        {
            return ExecuteQuery("SELECT * from classes ORDER BY id DESC", []);
        }

        public static int AddClass(int facultyId, string name)
        {
            return ExecuteNonQuery(
                "INSERT INTO classes (facultyId, name) VALUES (@facultyId, @name)", new MySqlParameter[]
                {
                    new MySqlParameter("@facultyId", facultyId),
                    new MySqlParameter("@name", name)
                });
        }

        public static int UpdateClass(int id, int facultyId, string name)
        {
            return ExecuteNonQuery(
                "UPDATE classes SET facultyId = @facultyId name = @name WHERE id = @id", new MySqlParameter[]
                {
                    new MySqlParameter("@facultyId", facultyId),
                    new MySqlParameter("@name", name),
                    new MySqlParameter("@id", id)
                });
        }

        public static int DeleteClass(int id)
        {
            return ExecuteNonQuery(
                "DELETE FROM classes WHERE id = @id", new MySqlParameter[]
                {
                    new MySqlParameter("@id", id)
                });
        }




        //
        // Enrollment CRUD operations
        //

        public static DataTable GetEnrollments()
        {
            return ExecuteQuery("SELECT CONCAT(s.firstName, ' ', s.lastName) AS FullName," +
                " c.courseName AS Course, d.departmentName AS Department, sm.semester AS Semester," +
                " yl.year AS YearLevel, sy.name AS SchoolYear FROM enrollment AS e JOIN students AS s ON e.studentId = s.id" +
                " JOIN courses AS c ON e.courseId = c.id JOIN semesters AS sm ON e.semesterId = sm.id" +
                " JOIN yearLevels AS yl ON e.yearLevelId = yl.id JOIN schoolYears AS sy ON e.schoolYearId = sy.id" +
                " JOIN departments AS d ON s.departmentId = d.id;", []);
        }

        public static int EnrollStudent(int studentId, int courseId, int semesterId, int yearLevelId, int schoolYearId)
        {
            return ExecuteNonQuery(
                "INSERT INTO enrollments (studentId, courseId, semesterId, yearLevelId, schoolYearId) " +
                "VALUES (@studentId, @courseId, @semesterId, yearLevelId, schoolYearId)", new MySqlParameter[]
                {
                    new MySqlParameter("@studentId", studentId),
                    new MySqlParameter("@courseId", courseId),
                    new MySqlParameter("@semesterId", semesterId),
                    new MySqlParameter("@yearLevelId", yearLevelId),
                    new MySqlParameter("@schoolYearId", schoolYearId)
                });
        }

        public static int EnrollDetails(int enrollmentId, int classId)
        {
            return ExecuteNonQuery(
                "INSERT INTO enrollments (enrollmentId, classId) " +
                "VALUES (@enrollmentId, @classId)", new MySqlParameter[]
                {
                    new MySqlParameter("@enrollmentId", enrollmentId),
                    new MySqlParameter("@classId", classId)
                });
        }

        //public static int UpdateFaculty(int id, string firstName, string? middleName, string lastName)
        //{
        //    return ExecuteNonQuery(
        //        "UPDATE faculty SET firstName = @firstName, middleName = @middleName, lastName = @lastName WHERE id = @id", new MySqlParameter[]
        //        {
        //            new MySqlParameter("@firstName", firstName),
        //            new MySqlParameter("@middleName", middleName),
        //            new MySqlParameter("@lastName", lastName),
        //            new MySqlParameter("@id", id)
        //        });
        //}

        public static int DeleteEnrollment(int id)
        {
            return ExecuteNonQuery(
                "DELETE FROM faculty WHERE id = @id", new MySqlParameter[]
                {
                    new MySqlParameter("@id", id)
                });
        }

    }
}

