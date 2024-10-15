using Microsoft.EntityFrameworkCore;
using Albums.Data.Models;

namespace Albums.Api.DAL;

public class Context : DbContext
{
    public DbSet<Genre> genre { get; set; }
    public DbSet<Album> album { get; set; }
    public Context(DbContextOptions<Context> options) : base(options) { }
}
