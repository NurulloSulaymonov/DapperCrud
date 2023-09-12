namespace Domain.Entities;


public class BaseEntity
{
    public int Id { get; set; }
}

public class Quote : BaseEntity
{
    public string Text { get; set; }
    public string Author { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    
}

public class Category : BaseEntity
{
    public string Name { get; set; }
    public List<Quote> Quotes { get; set; }
}