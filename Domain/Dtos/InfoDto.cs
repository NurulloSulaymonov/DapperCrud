namespace Domain.Dtos;

public class InfoDto
{
    public string Name { get; set; }
    public string Surname { get; set; }

    public InfoDto()
    {
        this.Name = "test";
        this.Surname = "test";
    }
}