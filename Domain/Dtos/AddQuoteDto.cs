using Microsoft.AspNetCore.Http;

namespace Domain.Dtos;

public class AddQuoteDto : QuoteDto
{
    public List<IFormFile> Files { get; set; }
}

