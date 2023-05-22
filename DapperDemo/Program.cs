var teacherService = new TeacherService();

var teacher = new TeacherDto()
{
    FirstName = "Abdullah",
    LastName = "Abdullah",
    Email = "Abdullah@test",
};
Add(teacher);
// Show(null);
void Show(string name)
{
    var teachers = teacherService.GetTeachers(name,null);
    Console.WriteLine("Id-----------FirstName------------LastName-------------Email");
    foreach (var teacher in teachers)
    {
        Console.WriteLine($"{teacher.Id}-----------{teacher.FirstName}------------{teacher.LastName}-------------{teacher.Email}");
    }
}

void GetById(int id)
{
    var teacher = teacherService.GetTeacherById(id);
    Console.WriteLine($"{teacher.Id}");
    Console.WriteLine($"{teacher.FirstName}");
}

void Add(TeacherDto teacher)
{
    var result = teacherService.AddTeacher(teacher);
    Console.WriteLine(result.Id);
}