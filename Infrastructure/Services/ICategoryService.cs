using Domain.Dtos;

namespace Infrastructure.Services;

public interface ICategoryService
{
    CategoryDto AddCategory(CategoryDto category);
    CategoryDto UpdateCategory(CategoryDto _categoryDto);
}