using Parqueadero.Aplicacion.DTOs;
using Parqueadero.Aplicacion.Interfaces;
using Parqueadero.Dominio.Entidades;

namespace Parqueadero.Aplicacion.Servicios
{
    public class VehiculoService : IVehiculoService
    {
        private readonly IVehiculoRepository _repo;
        private readonly IEmailService _emailService;

        private const decimal TARIFA_POR_MINUTO = 50;

        public VehiculoService(
            IVehiculoRepository repo,
            IEmailService emailService)
        {
            _repo = repo;
            _emailService = emailService;
        }

        public async Task<List<Vehiculo>> GetVehiculosActivosAsync()
        {
            return await _repo.GetVehiculosActivosAsync();
        }

        public async Task<Vehiculo> RegistrarIngresoAsync(EntradaVehiculoDTO dto)
        {
            // Validar si ya existe activo
            var vehiculoActivo = await _repo.GetByPlacaActivaAsync(dto.Placa);

            if (vehiculoActivo != null)
            {
                throw new Exception("El vehículo ya se encuentra dentro del parqueadero");
            }

            var vehiculo = new Vehiculo
            {
                Placa = dto.Placa,
                Tipo = dto.Tipo,
                FechaIngreso = DateTime.Now
            };

            return await _repo.AddAsync(vehiculo);
        }

        public async Task<ResultadoSalidaDTO?> RegistrarSalidaAsync(string placa)
        {
            var vehiculo = await _repo.GetByPlacaActivaAsync(placa);

            if (vehiculo == null)
            {
                throw new Exception("Vehículo no encontrado o ya salió");
            }

            vehiculo.FechaSalida = DateTime.Now;

            var totalMinutos = (int)(
                vehiculo.FechaSalida.Value - vehiculo.FechaIngreso
            ).TotalMinutes;

            if (totalMinutos <= 0)
            {
                totalMinutos = 1;
            }

            var valor = totalMinutos * TARIFA_POR_MINUTO;

            vehiculo.TotalMinutos = totalMinutos;
            vehiculo.ValorPagado = valor;

            await _repo.UpdateAsync(vehiculo);

           var resultado = new ResultadoSalidaDTO
           {
                Placa = vehiculo.Placa,
                Tipo = vehiculo.Tipo,
                FechaIngreso = vehiculo.FechaIngreso,
                FechaSalida = vehiculo.FechaSalida.Value,
                TotalMinutos = totalMinutos,
                ValorPagado = valor
            };

            // Enviar correo
            await _emailService.EnviarCorreoSalidaAsync(resultado);

            return resultado;
        }
    }
}