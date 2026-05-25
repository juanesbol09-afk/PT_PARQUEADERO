namespace Parqueadero.Aplicacion.DTOs
{
    public class ResultadoSalidaDTO
    {
        public string Placa { get; set; } = string.Empty;

        public string Tipo { get; set; } = string.Empty;

        public DateTime FechaIngreso { get; set; }

        public DateTime FechaSalida { get; set; }

        public int TotalMinutos { get; set; }

        public decimal ValorPagado { get; set; }
    }
}