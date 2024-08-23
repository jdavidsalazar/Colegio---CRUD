import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-alumno-grado',
  templateUrl: './alumnogrado.component.html',
  styleUrls: ['./alumnogrado.component.css'],
})
export class AlumnogradoComponent implements OnInit {
  // Define the columns that will be displayed
  displayedColumns: string[] = ['id', 'alumnoId', 'grupo', 'edit', 'delete'];

  // Example data source
  dataSource = new MatTableDataSource<{
    id: number;
    alumnoId: number;
    grupo: string;
  }>([
    {
      id: 1,
      alumnoId: 101,
      grupo: 'A',
    },
    {
      id: 2,
      alumnoId: 102,
      grupo: 'B',
    },
    // Add more rows here
  ]);

  constructor() {}

  ngOnInit(): void {}

  // Method to handle adding a new row
  addNewRow() {
    const newRow = {
      id: this.dataSource.data.length + 1,
      alumnoId: 0,
      grupo: '',
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
