import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-grados',
  templateUrl: './grados.component.html',
  styleUrls: ['./grados.component.css'],
})
export class GradosComponent implements OnInit {
  // Define the columns that will be displayed
  displayedColumns: string[] = ['id', 'nombre', 'profesorId', 'edit', 'delete'];

  // Example data source
  dataSource = new MatTableDataSource<{
    id: number;
    nombre: string;
    profesorId: number;
  }>([
    {
      id: 1,
      nombre: 'Primero',
      profesorId: 101,
    },
    {
      id: 2,
      nombre: 'Segundo',
      profesorId: 102,
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
      profesorId: 0,
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
