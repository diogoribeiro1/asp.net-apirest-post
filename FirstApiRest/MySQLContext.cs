using FirstApiRest.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstApiRest;

public class MySQLContext : DbContext
{
    public MySQLContext(DbContextOptions<MySQLContext> options) : base(options)
    {

    }

    public DbSet<Post> Posts { get; set; }
   
}