using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("[controller]")]
public class QuoteController : ControllerBase
{
    private QuoteService _quoteService;
    public QuoteController(QuoteService quoteService)
    {
        _quoteService = quoteService;
    }

    [HttpGet("GetQuote")]
    public List<GetFilterQuoteDto> GetQuote(string? quote_text)
    {
        IFormFile file;
        return _quoteService.GetQuote(quote_text);
    }  
    
    [HttpPost("Add")]
    public async Task<QuoteDto> AddQuote([FromQuery]AddQuoteDto quote)
    {
        if (ModelState.IsValid)
        {
            return await _quoteService.AddQuote(quote);
        }
        else return new QuoteDto();

    } 
}