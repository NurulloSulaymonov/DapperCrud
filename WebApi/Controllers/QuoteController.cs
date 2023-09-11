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

    [HttpGet("GetQuote")]
    public List<GetFilterQuoteDto> GetQuote(string? quote_text)
    {
        return _quoteService.GetQuote(quote_text);
    }  
    
    [HttpPost("Add")]
    public QuoteDto AddQuote(QuoteDto quote)
    {
        return _quoteService.AddQuote(quote);
    } 
}