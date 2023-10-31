#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace CocinerosYPlatos.Models;

public class MyContext : DbContext{
    public DbSet<Chef> Chefs {get;set;}
    public DbSet<Plato> Platos {get;set;}

    public MyContext(DbContextOptions options) : base(options){}
}