import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { AlumnoGradoService } from '../services/alumnogrado.service';

@Component({
  selector: 'app-alumno-grados',
  templateUrl: './alumnogrado.component.html',
  styleUrls: ['./alumnogrado.component.css'],
})
export class AlumnoGradosComponent implements OnInit {
  displayedColumns: string[] = [
    'id',
    'alumnoId',
    'gradoId',
    'grupo',
    'edit',
    'delete',
  ];
  dataSource = new MatTableDataSource<any>([]);

  constructor(private alumnoGradoService: AlumnoGradoService) {}

  ngOnInit(): void {
    this.loadAlumnoGrados();
  }

  loadAlumnoGrados(): void {
    this.alumnoGradoService.getAlumnoGrados().subscribe(
      (data) => {
        this.dataSource.data = data;
      },
      (error) => {
        console.error('Error loading alumno grados', error);
      }
    );
  }

  addNewRow() {
    const newRow = {
      id: null,
      alumnoId: null,
      gradoId: null,
      grupo: '',
      isEditMode: true,
    };
    this.dataSource.data = [newRow, ...this.dataSource.data];
  }

  editRow(row: any) {
    row.isEditMode = true;
  }

  saveRow(row: any) {
    if (!row.alumnoId || !row.gradoId || !row.grupo) {
      console.error('Validation failed: All fields are required');
      alert('Please fill out all required fields.');
      return;
    }

    // Add new AlumnoGrado
    if (row.id === null) {
      const { id, isEditMode, ...payload } = row;

      // Make sure to send the payload as an array of objects
      this.alumnoGradoService.addAlumnoGrado([payload]).subscribe(
        (addedAlumnoGrado) => {
          row.id = addedAlumnoGrado[0].id; // Assuming API returns an array
          row.isEditMode = false;
          console.log('AlumnoGrado added', addedAlumnoGrado);

          this.loadAlumnoGrados();
        },
        (error) => {
          console.error('Error adding alumno grado', error);
          alert(
            `An error occurred while adding the alumno grado: ${error.error}`
          );
        }
      );
    } else {
      // Update existing AlumnoGrado
      const { isEditMode, ...payload } = row;

      this.alumnoGradoService.updateAlumnoGrado(row.id, payload).subscribe(
        (updatedAlumnoGrado) => {
          row.isEditMode = false;
          console.log('AlumnoGrado updated', updatedAlumnoGrado);

          this.loadAlumnoGrados();
        },
        (error) => {
          console.error('Error updating alumno grado', error);
          alert(
            `An error occurred while updating the alumno grado: ${error.error}`
          );
        }
      );
    }
  }

  deleteRow(row: any) {
    this.alumnoGradoService.deleteAlumnoGrado(row.id).subscribe(
      () => {
        this.dataSource.data = this.dataSource.data.filter((r) => r !== row);
      },
      (error) => {
        console.error('Error deleting alumno grado', error);
      }
    );
  }
}
