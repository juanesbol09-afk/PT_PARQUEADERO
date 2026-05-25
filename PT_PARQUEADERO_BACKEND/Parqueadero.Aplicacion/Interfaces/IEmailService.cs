using Parqueadero.Aplicacion.DTOs;

namespace Parqueadero.Aplicacion.Interfaces
{
    public interface IEmailService
    {
        Task EnviarCorreoSalidaAsync(ResultadoSalidaDTO dto);
    }
}