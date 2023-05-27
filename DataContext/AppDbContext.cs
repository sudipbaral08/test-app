using Microsoft.EntityFrameworkCore;
using FirstApp.Src.Entity;

namespace FirstApp.DataContext;


public class AppDbContext : DbContext{
  private readonly IConfiguration _configuration;
  public AppDbContext (IConfiguration configuration){
    _configuration = configuration;

  }
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
    var connectionString = _configuration.GetConnectionString("DefaultConnection");
    base.OnConfiguring(optionsBuilder);
    optionsBuilder.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();

  }
  protected override void OnModelCreating(ModelBuilder modelBuilder){

  }

  public DbSet<ClassInfo> ClassInfos {get; set;}

}