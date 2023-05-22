using Npgsql;
using Dapper;
public class TeacherService
{
    //private List<TeacherDto> _teacher;
    string connectionString = "Server =localhost;Port=5432;Database=demo;User Id=postgres;Password=12345;";
    public TeacherService()
    {

    }
    
    //Get all teachers
    public List<TeacherDto> GetTeachers(string? name, string? surname)
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            var sql = "select teacher_id as Id, first_name FirstName, last_name LastName, email_address as Email from teachers";
            if (name != null)
                sql += $" where lower(first_name) like '%@Name%'";
            var result = conn.Query<TeacherDto>(sql,new {Name = name});
            return result.ToList();
        }
    }
    
    //Get by Id
    public TeacherDto GetTeacherById(int id)
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            var sql = $"select teacher_id as Id, first_name FirstName, last_name LastName, email_address as Email from teachers where teacher_id = @Id";
            var result = conn.QuerySingle<TeacherDto>(sql, new {Id = id});
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
        }
    }
    
    
}