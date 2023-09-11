using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("[controller]")]
public class DiController :ControllerBase
{
    private readonly ScopedService _scopedService;
    private readonly TransientService _transientService;
    private readonly SingletonService _singletonService;
    private readonly ICategoryService _categoryService;

    public DiController(
        ScopedService scopedService,
        TransientService transientService, 
        SingletonService singletonService, 
        ICategoryService categoryService)
    {
        _scopedService = scopedService;
        _transientService = transientService;
        _singletonService = singletonService;
        _categoryService = categoryService;
    }

    [HttpGet("singleton")]
    public string GetSingleton()
    {
        return _singletonService.Id;
    }
    
    [HttpGet("scoped")]
    public List<string> GetScoped()
    {
        var list = new List<string>()
        {
            _scopedService.Id,
            _categoryService.GetScopedId()
        };

        return list;
    }
    
    [HttpGet("transient")]
    public List<string> GetTransient()
    {
        
        
        var list = new List<string>()
        {
            _transientService.Id,
            _categoryService.GetTransientId()
        };

        return list;
    }
    
    
    
    

   
}