namespace Infrastructure.Services;

public class ScopedService
{
    public string Id;
    public ScopedService()
    {
        Id = Guid.NewGuid().ToString();
    }
}