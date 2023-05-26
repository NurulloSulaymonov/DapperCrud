using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;


[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private CategoryService _categoryService;
    public CategoryController()
    {
        _categoryService = new CategoryService();
    }


    [HttpPost("GetQuotesByCategory")]
    public CategoryDto GetQuotesByCategory(CategoryDto category)
    {
        return _categoryService.GetQuotesByCategory(category);
    }
}