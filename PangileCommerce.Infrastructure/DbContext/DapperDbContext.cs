
using AutoMapper;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace PangileCommerce.Infrastructure.DbContext;

public class DapperDbContext
{
    private readonly IConfiguration _configuration;
    private readonly IDbConnection _connection;
    public DapperDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
        string? connectionString = _configuration.GetConnectionString("PostgresConnection");
        _connection = new Npgsql.NpgsqlConnection(connectionString);
    }

    public IDbConnection DbConnection => _connection;
}
