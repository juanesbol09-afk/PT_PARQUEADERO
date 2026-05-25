import { Component, OnInit } from '@angular/core';

import { CommonModule } from '@angular/common';

import { FormsModule } from '@angular/forms';

import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App implements OnInit {

  apiUrl = 'http://localhost:5188/api/Vehiculo';

  placa = '';

  tipo = 'Carro';

  vehiculos: any[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.obtenerVehiculos();
  }

  obtenerVehiculos() {

    this.http.get<any[]>(`${this.apiUrl}/activos`)
      .subscribe({
        next: (data) => {
          this.vehiculos = data;
        },

        error: (error) => {
          console.error(error);
        }
      });

  }

  registrarIngreso() {

    const body = {
      placa: this.placa,
      tipo: this.tipo
    };

    this.http.post(`${this.apiUrl}/ingreso`, body)
      .subscribe({
        next: () => {

          alert('Vehículo registrado correctamente');

          this.placa = '';

          this.tipo = 'Carro';

          this.obtenerVehiculos();
        },

        error: (error) => {

          console.error(error);

          alert('Error registrando vehículo');
        }
      });

  }

  registrarSalida(placa: string) {

    this.http.post(`${this.apiUrl}/salida/${placa}`, {})
      .subscribe({
        next: (response: any) => {

          alert(`
Placa: ${response.placa}
Tiempo: ${response.totalMinutos} minutos
Valor: $${response.valorPagado}
          `);

          this.obtenerVehiculos();
        },

        error: (error) => {

          console.error(error);

          alert('Error registrando salida');
        }
      });

  }
}