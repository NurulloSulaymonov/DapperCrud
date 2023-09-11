using Dapper;
using Domain.Dtos;
using Npgsql;

namespace Infrastructure.Services;

public class QuoteService
{
    private DapperContext _context;
    public QuoteService()
    {
        _context = new DapperContext();
    }
    public QuoteDto AddQuote(QuoteDto quote)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"insert into quotes (author, quotetext, categoryid) values (@Autor, @Quotetext, @Categoryid) returning id";
            var id = conn.ExecuteScalar<int>(sql, quote);
            quote.Id = id;
            return quote;
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

    public List<GetFilterQuoteDto> GetQuote(string quote_text)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"select author as Author, quotetext as QuoteText from Quotes where quotetext like '%{quote_text}%'";
            var result = conn.Query<GetFilterQuoteDto>(sql).ToList();
            return result;
        }
    }


}