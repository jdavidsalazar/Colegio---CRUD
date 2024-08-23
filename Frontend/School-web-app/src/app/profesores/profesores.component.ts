import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-profesores',
  templateUrl: './profesores.component.html',
  styleUrls: ['./profesores.component.css'],
})
export class ProfesoresComponent implements OnInit {
  // Define the columns that will be displayed
  displayedColumns: string[] = [
    'id',
    'nombre',
    'apellido',
    'genero',
    'edit',
    'delete',
  ];

  // Example data source
  dataSource = new MatTableDataSource<{
    id: number;
    nombre: string;
    apellido: string;
    genero: string;
  }>([
    {
      id: 1,
      nombre: 'Carlos',
      apellido: 'Sánchez',
      genero: 'Masculino',
    },
    {
      id: 2,
      nombre: 'Lucía',
      apellido: 'Martínez',
      genero: 'Femenino',
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
