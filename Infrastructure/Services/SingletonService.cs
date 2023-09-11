namespace Infrastructure.Services;

public class SingletonService
{
    public string Id;
    public SingletonService()
    {
        Id = Guid.NewGuid().ToString(); 
    } 
}