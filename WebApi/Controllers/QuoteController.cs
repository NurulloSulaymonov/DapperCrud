using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class QuoteController : ControllerBase
{
    private QuoteService _quoteService;
    public QuoteController()
    {
        _quoteService = new QuoteService();
    }

    [HttpGet("LikeQuote")]
    public List<GetFilterQuoteDto> LikeQuote(string quote_text)
    {
        return _quoteService.ListQuote(quote_text);
   }
}