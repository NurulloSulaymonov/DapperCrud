using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;

public class DapperContext
{

    public IDbConnection CreateConnection()
    {
        return new NpgsqlConnection("Server=Localhost; port= 5432; database=quotedb; User Id= postgres; password= 12345");
    }
}