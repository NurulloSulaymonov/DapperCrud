namespace Infrastructure.Context;
using Npgsql;
using System.Data;
public class DapperContext
{
    string connString = "Server = localhost; Port=5432; Database = home_25.05.2023; User id = postgres; password = koma;";
    public DapperContext()
    {

    }
    public IDbConnection CreateConnection()
    {
        return new NpgsqlConnection(connString);
    }
}
