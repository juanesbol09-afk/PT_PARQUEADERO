import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';

import { Vehiculo } from '../models/vehiculo.model';

import { ResultadoSalida } from '../models/resultado-salida.model';

@Injectable({
  providedIn: 'root'
})
export class VehiculoService {

  private apiUrl = 'http://localhost:5188/api/Vehiculo';

  constructor(private http: HttpClient) {}

  obtenerActivos(): Observable<Vehiculo[]> {

    return this.http.get<Vehiculo[]>(
      `${this.apiUrl}/activos`
    );

  }

  registrarIngreso(body: any) {

    return this.http.post(
      `${this.apiUrl}/ingreso`,
      body
    );

  }

  registrarSalida(placa: string): Observable<ResultadoSalida> {

    return this.http.post<ResultadoSalida>(
      `${this.apiUrl}/salida/${placa}`,
      {}
    );

  }
}