using Dapper;
using Domain.Dtos;
using Npgsql;

namespace Infrastructure.Services;

public class QuoteService
{
    private DapperContext _context;
    private readonly IfileService _fileService;

    public QuoteService(DapperContext context, IfileService fileService)
    {
        _context = context;
        _fileService = fileService;
    }
    public async Task<QuoteDto> AddQuote(AddQuoteDto quote)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"insert into quotes (author, quotetext, categoryid) values (@Autor, @Quotetext, @Categoryid) returning id";
            var id = conn.ExecuteScalar<int>(sql, quote);
            quote.Id = id;

            // add images
            foreach (var file in quote.Files)
            {
                var filename = await _fileService.AddFile(file, "images");
                if (filename == null)
                    continue;
                sql = "insert into quote_images (quote_id,image_name) values (@QuoteId,@ImageName)";
                var response = await conn.ExecuteAsync(sql, new { QuoteId = id, ImageName = filename });
                
            }
            return new QuoteDto()
            {
                Id = id,
                Autor = quote.Autor,
                CategoryId = quote.CategoryId
            };
        }
    }

    public QuoteDto UpdateQuote(QuoteDto quote)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"Update Quotes set author=@Author,QuoteText=@QuoteText,CategoruId=@Categoryid where id=@id";
            conn.Execute(sql, quote);
            return quote;
        }
    }

    public int Delete(int id)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"Delete from Quotes where id = @id";
            var result = conn.Execute(sql);
            return result;
        }
    }

    public List<GetFilterQuoteDto> GetQuote(string? text)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"select author as Author, quotetext as QuoteText from Quotes ";
            if (text != null) sql += "where quotetext like '%@QuoteText%'";
            var result = conn.Query<GetFilterQuoteDto>(sql, new {QuoteText = text} ).ToList();
            return result;
        }
    }


}