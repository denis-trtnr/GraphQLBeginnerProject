using GraphQLAPITest.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLAPITest.Data
{
    public class GraphQLDbContext : DbContext
    {
        public GraphQLDbContext(DbContextOptions<GraphQLDbContext> options) : base(options)
        { 
        }

        public DbSet<Product> Products { get; set; }
    }
}
