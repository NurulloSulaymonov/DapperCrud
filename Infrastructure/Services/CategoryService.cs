using Domain.Dtos;
using Npgsql;
using Dapper;

namespace Infrastructure.Services;

public class CategoryService : ICategoryService
{
    private readonly ScopedService _scopedService;
    private readonly TransientService _transientService;
    private string connectionString ="server= localhost;port=5432; database=quotedb; User Id= postgres; password= 12345";
    
    
    public CategoryService(
        ScopedService scopedService, 
        TransientService transientService)
    {
        _scopedService = scopedService;
        _transientService = transientService;
    }

    public string GetScopedId()
    {
        return _scopedService.Id;
    }
    public string GetTransientId()
    {
        return _transientService.Id;
    }

    
    public CategoryDto AddCategory(CategoryDto category)
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            var sql = $"insert into Categories (categoryname) values (@CategoryName) returning id ";
            var id =conn.ExecuteScalar<int>(sql, category);
            category.Id = id;
            return category;
        }
    }

    

   
    public CategoryDto UpdateCategory(CategoryDto _categoryDto)
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            var sql = $"update categories set categoryname = @CategoryName where id = @Id";
            conn.Execute(sql, _categoryDto);
            return _categoryDto;
        }
    }
}