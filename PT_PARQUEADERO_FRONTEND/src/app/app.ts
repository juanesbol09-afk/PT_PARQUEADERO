import Swal from 'sweetalert2';

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

  loading = false;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.obtenerVehiculos();
  }

  obtenerVehiculos() {

    this.loading = true;
    this.http.get<any[]>(`${this.apiUrl}/activos`)
      .subscribe({
        next: (data) => {
          this.vehiculos = data;
          this.loading = false;
        },

        error: (error) => {
          console.error(error);
          this.loading = false;
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

          Swal.fire({
            icon: 'success',
            title: 'Éxito',
            text: 'Vehículo registrado correctamente',
            confirmButtonColor: '#198754'
          });

          this.placa = '';

          this.tipo = 'Carro';

          this.obtenerVehiculos();
        },

        error: (error) => {

          console.error(error);

          Swal.fire({
            icon: 'error',
            title: 'Error',
            text: error.error?.mensaje || 'Error registrando vehículo',
            confirmButtonColor: '#dc3545'
          });
        }
      });

  }

  registrarSalida(placa: string) {

    this.http.post(`${this.apiUrl}/salida/${placa}`, {})
      .subscribe({
        next: (response: any) => {

          Swal.fire({
            icon: 'success',
            title: 'Salida registrada',
            html: `
              <b>Placa:</b> ${response.placa}<br>
              <b>Tiempo:</b> ${response.totalMinutos} minutos<br>
              <b>Valor:</b> ${response.valorPagado.toLocaleString('es-CO', {
                style: 'currency',
                currency: 'COP'
              })}
            `,
            confirmButtonColor: '#198754'
          });
          setTimeout(() => {
            this.obtenerVehiculos();
          }, 300);

        },
        error: (error) => {

          console.error(error);

          Swal.fire({
            icon: 'error',
            title: 'Error',
            text: error.error?.mensaje || 'Error registrando salida',
            confirmButtonColor: '#dc3545'
          });
        }
      });

  }
}