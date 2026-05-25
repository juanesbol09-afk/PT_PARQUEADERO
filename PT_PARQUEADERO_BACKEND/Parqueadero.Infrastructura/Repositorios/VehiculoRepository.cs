using Microsoft.EntityFrameworkCore;
using Parqueadero.Aplicacion.Interfaces;
using Parqueadero.Dominio.Entidades;
using Parqueadero.Infrastructura.Data;

namespace Parqueadero.Infrastructura.Repositorios
{
    public class VehiculoRepository : IVehiculoRepository
    {
        private readonly ParqueaderoDbContext _context;

        public VehiculoRepository(ParqueaderoDbContext context)
        {
            _context = context;
        }

        public async Task<List<Vehiculo>> GetAllAsync()
        {
            return await _context.Vehiculos.ToListAsync();
        }

        public async Task<Vehiculo?> GetByIdAsync(int id)
        {
            return await _context.Vehiculos.FindAsync(id);
        }

        public async Task<Vehiculo> AddAsync(Vehiculo vehiculo)
        {
            _context.Vehiculos.Add(vehiculo);
            await _context.SaveChangesAsync();
            return vehiculo;
        }

        public async Task<bool> UpdateAsync(Vehiculo vehiculo)
        {
            _context.Vehiculos.Update(vehiculo);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Vehiculos.FindAsync(id);

            if (entity == null)
                return false;

            _context.Vehiculos.Remove(entity);

            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<Vehiculo?> GetByPlacaActivaAsync(string placa)
        {
            return await _context.Vehiculos
                .FirstOrDefaultAsync(v =>
                    v.Placa == placa &&
                    v.FechaSalida == null);
        }

        public async Task<List<Vehiculo>> GetVehiculosActivosAsync()
        {
            return await _context.Vehiculos
                .Where(v => v.FechaSalida == null)
                .ToListAsync();
        }
    }
}