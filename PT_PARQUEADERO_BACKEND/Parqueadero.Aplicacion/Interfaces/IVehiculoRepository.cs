using Parqueadero.Dominio.Entidades;

namespace Parqueadero.Aplicacion.Interfaces
{
    public interface IVehiculoRepository
    {
        Task<List<Vehiculo>> GetAllAsync();
        Task<Vehiculo?> GetByIdAsync(int id);
        Task<Vehiculo> AddAsync(Vehiculo vehiculo);
        Task<bool> UpdateAsync(Vehiculo vehiculo);
        Task<bool> DeleteAsync(int id);
        Task<Vehiculo?> GetByPlacaActivaAsync(string placa);
        Task<List<Vehiculo>> GetVehiculosActivosAsync();    
    }
}