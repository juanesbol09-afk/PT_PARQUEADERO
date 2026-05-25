using Parqueadero.Aplicacion.DTOs;
using Parqueadero.Dominio.Entidades;

namespace Parqueadero.Aplicacion.Servicios
{
    public interface IVehiculoService
    {
        Task<List<Vehiculo>> GetVehiculosActivosAsync();

        Task<Vehiculo> RegistrarIngresoAsync(EntradaVehiculoDTO dto);

        Task<ResultadoSalidaDTO?> RegistrarSalidaAsync(string placa);
    }
}