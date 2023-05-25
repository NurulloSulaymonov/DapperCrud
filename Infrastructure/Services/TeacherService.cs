using Npgsql;
using Dapper;
using Domain.Dtos;

public class TeacherService
{
    //private List<TeacherDto> _teacher;
    string connectionString = "Server =localhost;Port=5432;Database=demo;User Id=postgres;Password=12345;";
    public TeacherService() { }

    //Get all teachers
    public List<TeacherDto> GetTeachers(string? name)
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            var sql = "select teacher_id as Id, first_name FirstName, last_name LastName, email_address as Email from teachers";
            if (name != null)
                sql += $" where lower(first_name) like '%@Name%'";
            var result = conn.Query<TeacherDto>(sql, new { Name = name });
            return result.ToList();
        }
    }

    //Get enrollements
    public List<EnrollementDto> GetEnrollement(int id)
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            var sql = "select e.enrollment_id as enrollementId, concat(s.first_name,' ',s.last_name) as fullname, c.class_name as classname from enrollment  e" +
                            "join classes c on e.class_id = c.class_id" +
                            "join students s on e.student_id = s.student_id;";
            var result = conn.Query<EnrollementDto>(sql).ToList();
            return result;
        }
    }
    //Get by Id
    public TeacherDto GetTeacherById(int id)
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            var sql = $"select teacher_id as Id, first_name FirstName, last_name LastName, email_address as Email from teachers where teacher_id = @Id";
            var result = conn.QuerySingleOrDefault<TeacherDto>(sql, new { Id = id });
            if (result == null)
                Console.WriteLine("No teacher was found");
            return result;
        }
    }

    //Get by Id
    public int CountTeachers()
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            var sql = "select count(*) from students;";
            var result = conn.ExecuteScalar<int>(sql);
            return result;
        }
    }


    //insert 
    public TeacherDto AddTeacher(TeacherDto teacher)
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            var sql = $"insert into teachers (first_name, last_name, email_address) VALUES (@FirstName,@LastName,@Email) returning teacher_id;";
            var result = conn.ExecuteScalar<int>(sql, teacher);
            teacher.Id = result;
            return teacher;

            //Execute<int> // run the command and return the effected rows
            //ExecuteScalar<int> // one colum
        }
    }


}