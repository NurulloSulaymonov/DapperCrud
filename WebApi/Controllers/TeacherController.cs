using Microsoft.AspNetCore.Mvc;
using Domain.Dtos;

namespace WebApi.Controllers;


[ApiController]
[Route("[controller]")]
public class TeacherController : ControllerBase
{
    private TeacherService _teacherService;
    public TeacherController()
    {
        _teacherService = new TeacherService();
    }

    [HttpGet("Teachers")]
    public List<TeacherDto> GetTeachers()
    {
        return _teacherService.GetTeachers(null);
    }


    [HttpPost("AddTeacher")] // httppost - add
    public TeacherDto AddTeachers(TeacherDto teacher)
    {
        return _teacherService.AddTeacher(teacher);
    }



}
