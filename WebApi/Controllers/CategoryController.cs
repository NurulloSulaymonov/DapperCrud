using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("[controller]")]
public class CategoryController :ControllerBase
{
    private ICategoryService _categoryService;
    public CategoryController(InfoDto info)
    {
       
    }
    
    
    

   
}