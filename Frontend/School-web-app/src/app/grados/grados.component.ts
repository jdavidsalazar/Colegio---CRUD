import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { GradoService } from '../services/grados.service';
@Component({
  selector: 'app-grados',
  templateUrl: './grados.component.html',
  styleUrls: ['./grados.component.css'],
})
export class GradosComponent implements OnInit {
  displayedColumns: string[] = ['id', 'nombre', 'profesorId', 'edit', 'delete'];

  dataSource = new MatTableDataSource<any>([]);

  constructor(private gradosService: GradoService) {}

  ngOnInit(): void {
    this.loadGrados();
  }

  loadGrados(): void {
    this.gradosService.getGrados().subscribe(
      (data) => {
        this.dataSource.data = data;
      },
      (error) => {
        console.error('Error loading grados', error);
      }
    );
  }

  addNewRow() {
    const newRow = {
      id: null,
      nombre: '',
      profesorId: null,
      isEditMode: true,
    };
    this.dataSource.data = [newRow, ...this.dataSource.data];
  }

  saveRow(row: any) {
    if (!row.nombre || !row.profesorId) {
      console.error('Validation failed: All fields are required');
      alert('Please fill out all required fields.');
      return;
    }

    // add new Grado
    if (row.id === null) {
      const { id, isEditMode, ...payload } = row;

      // Wrap payload in an array to match the expected request format
      this.gradosService.addGrado([payload]).subscribe(
        (addedGrado) => {
          row.id = addedGrado.id;
          row.isEditMode = false;
          console.log('Grado added', addedGrado);

          this.loadGrados();
        },
        (error) => {
          console.error('Error adding grado', error);
          alert(`An error occurred while adding the grado: ${error.error}`);
        }
      );
    } else {
      // Update existing Grado
      const { isEditMode, ...payload } = row;

      this.gradosService.updateGrado(row.id, payload).subscribe(
        (updatedGrado) => {
          row.isEditMode = false;
          console.log('Grado updated', updatedGrado);

          this.loadGrados();
        },
        (error) => {
          console.error('Error updating grado', error);
          alert(`An error occurred while updating the grado: ${error.error}`);
        }
      );
    }
  }

  editRow(row: any) {
    row.isEditMode = true;
  }

  deleteRow(row: any) {
    this.gradosService.deleteGrado(row.id).subscribe(
      () => {
        this.dataSource.data = this.dataSource.data.filter((r) => r !== row);
      },
      (error) => {
        console.error('Error deleting grado', error);
      }
    );
  }
}
