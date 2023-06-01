#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace Rendennon.Models;
public class MyContext : DbContext 
{
    public MyContext(DbContextOptions options) : base(options) { }
    // We need to create a new DbSet<Model> for every model in our project that is making a table
    // The name of our table in our database will be based on the name we provide here
    // This is where we provide a plural version of our model to fit table naming standards
    public DbSet<User> Users { get; set; }
    public DbSet<Character> Characters { get; set; }
}