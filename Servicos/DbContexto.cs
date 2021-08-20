using Webapi.Models;
using Microsoft.EntityFrameworkCore;

namespace Webapi.Servicos{

  public class DbContexto : DbContext
  {
    public DbContexto(DbContextOptions<DbContexto> options) : base(options){}
    
    public DbSet<Carro> Carros { get; set; }

    public DbSet<Marca> Marcas { get; set; }
    
  }
}