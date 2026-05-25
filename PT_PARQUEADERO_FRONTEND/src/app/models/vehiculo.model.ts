export interface Vehiculo {

  id: number;

  placa: string;

  tipo: string;

  fechaIngreso: string;

  fechaSalida?: string;

  totalMinutos?: number;

  valorPagado?: number;

}