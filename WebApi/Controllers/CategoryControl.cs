using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using Domain.Dtos;
namespace WebApi.Controllers;


[ApiController]
[Route("[controller]")]
public class CategoryControl
{
    CategoryService _categoryService;
    public CategoryControl()
    {
        _categoryService = new CategoryService();
    }
    [HttpGet("GetNumberQuoteswithcategory")]
    public List<CategoryDto> GetNumberQuoteswithcategory()
    {
        return _categoryService.GetNumberQuoteswithcategory();
    }
}
