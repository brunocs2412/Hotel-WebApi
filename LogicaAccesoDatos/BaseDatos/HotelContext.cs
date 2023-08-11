using System;
using System.Threading;
using LogicaNegocio.EntidadesNegocio;
using Microsoft.EntityFrameworkCore;

namespace LogicaAccesoDatos.BaseDatos;

public class HotelContext : DbContext
{

    public DbSet<Cabania> Cabanias { get; set; }
    public DbSet<Mantenimiento> Mantenimientos { get; set; }
    public DbSet<Tipo> Tipos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Foto> Fotos { get; set; }

    public HotelContext(DbContextOptions<HotelContext> options) : base(options) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Usuario>(usuario =>
        {
            usuario.ToTable("Usuarios");
            usuario.HasKey(p => p.Id);
            usuario.HasIndex(p => p.Email).IsUnique();
            usuario.Property(p => p.Password).IsRequired();

        });

        modelBuilder.Entity<Tipo>(t =>
        {
            t.HasKey(p => p.Id);

        });

 



        modelBuilder.Entity<Cabania>(c =>
        {
            c.HasKey(c => c.Id);
            c.HasIndex(c => c.NumHabitacion).IsUnique();
            //Para que cuando elimine un tipo no me elimne la cabania 
            c.HasOne(e=>e.Tipo).WithMany().OnDelete(DeleteBehavior.ClientCascade);

        });


        base.OnModelCreating(modelBuilder);
    }


}

