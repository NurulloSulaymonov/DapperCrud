using Domain.Dtos;
using Npgsql;
using Dapper;
using Infrastructure.Context;

namespace Infrastructure.Services;

public class CategoryService
{
    DapperContext _dapperContext;
    public CategoryService()
    {
        _dapperContext= new DapperContext();
    }
    public CategoryDto AddCategory(CategoryDto category)
    {
        using (var conn = _dapperContext.CreateConnection())
        {
            var sql = $"insert into Categories (categoryname) values (@CategoryName) returning id ";
            var id =conn.ExecuteScalar<int>(sql, category);
            category.Id = id;
            return category;
        }
    }

    public CategoryDto UpdateCategory(CategoryDto _categoryDto)
    {
        using (var conn =  _dapperContext.CreateConnection())
        {
            var sql = $"update categories set categoryname = @CategoryName where id = @Id";
            conn.Execute(sql, _categoryDto);
            return _categoryDto;
        }
    }
    
    public List<CategoryDto> GetNumberQuoteswithcategory()
    {
        using (var conn =  _dapperContext.CreateConnection())
        {
            var sql = $"select ch.categoryname as CategoryName, count(ch.id) as Count from categories as ch join quotes as q ON q.category_id = ch.id GROUP by ch.categoryname;";
            var results = conn.Query<CategoryDto>(sql);
            return results.ToList();
        }
    }
}