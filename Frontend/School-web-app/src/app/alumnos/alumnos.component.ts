import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-alumnos',
  templateUrl: './alumnos.component.html',
  styleUrls: ['./alumnos.component.css'],
})
export class AlumnosComponent implements OnInit {
  // Define the columns that will be displayed
  displayedColumns: string[] = [
    'id',
    'nombre',
    'apellido',
    'genero',
    'fechaNacimiento',
    'edit',
    'delete',
  ];

  // Example data source
  dataSource = new MatTableDataSource<{
    id: number;
    nombre: string;
    apellido: string;
    genero: string;
    fechaNacimiento: Date | null;
  }>([
    {
      id: 1,
      nombre: 'Juan',
      apellido: 'Pérez',
      genero: 'Masculino',
      fechaNacimiento: new Date(2000, 1, 15),
    },
    {
      id: 2,
      nombre: 'Ana',
      apellido: 'Gómez',
      genero: 'Femenino',
      fechaNacimiento: new Date(1998, 5, 23),
    },
    // Add more rows here
  ]);

  constructor() {}

  ngOnInit(): void {}

  // Method to handle adding a new row
  addNewRow() {
    const newRow = {
      id: this.dataSource.data.length + 1,
      nombre: '',
      apellido: '',
      genero: '',
      fechaNacimiento: null,
    };
    this.dataSource.data = [...this.dataSource.data, newRow];
  }

  // Method to handle editing a row
  editRow(row: any) {
    // Implement the edit logic here
    console.log('Editing row', row);
  }

  // Method to handle deleting a row
  deleteRow(row: any) {
    this.dataSource.data = this.dataSource.data.filter((r) => r !== row);
  }
}
