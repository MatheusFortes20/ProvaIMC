using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class AppDataContext : DbContext
{
    public  AppDataContext(DbContextOptions<AppDataContext> options) :
     base(options)
    { 

        
    }
    public DbSet<Imc> Imcs { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>().HasData(
           new Usuario { UsuarioId = 1, Nome = "Matheus", DataNascimento = "06/06/2002" }
           
        );

        modelBuilder.Entity<Imc>().HasData(
           new Imc { ImcId = 1, Altura = "1.74", Peso ="62kg"}
          
        );
    }
}
