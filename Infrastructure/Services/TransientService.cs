namespace Infrastructure.Services;

public class TransientService
{
    public string Id;
    public TransientService()
    {
        Id = Guid.NewGuid().ToString();
    }
}