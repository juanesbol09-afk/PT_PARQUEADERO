using Microsoft.EntityFrameworkCore;
using Parqueadero.Dominio.Entidades;

namespace Parqueadero.Infrastructura.Data;

public class ParqueaderoDbContext : DbContext
{
    public ParqueaderoDbContext(DbContextOptions<ParqueaderoDbContext> options)
        : base(options)
    {
    }

    public DbSet<Vehiculo> Vehiculos => Set<Vehiculo>();
}