import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { AlumnosService } from '../services/alumnos.service';

@Component({
  selector: 'app-alumnos',
  templateUrl: './alumnos.component.html',
  styleUrls: ['./alumnos.component.css'],
})
export class AlumnosComponent implements OnInit {
  displayedColumns: string[] = [
    'id',
    'nombre',
    'apellidos',
    'genero',
    'fechaNacimiento',
    'edit',
    'delete',
  ];

  dataSource = new MatTableDataSource<any>([]);

  generoOptions: string[] = ['Masculino', 'Femenino', 'Otro'];

  constructor(private alumnosService: AlumnosService) {}

  ngOnInit(): void {
    this.loadAlumnos();
  }

  loadAlumnos(): void {
    this.alumnosService.getAlumnos().subscribe(
      (data) => {
        this.dataSource.data = data;
      },
      (error) => {
        console.error('Error loading alumnos', error);
      }
    );
  }

  addNewRow() {
    const newRow = {
      id: null,
      nombre: '',
      apellidos: '',
      genero: '',
      fechaNacimiento: null,
      isEditMode: true,
    };
    this.dataSource.data = [newRow, ...this.dataSource.data];
  }

  saveRow(row: any) {
    if (!row.nombre || !row.apellidos || !row.genero || !row.fechaNacimiento) {
      console.error('Validation failed: All fields are required');
      alert('Please fill out all required fields.');
      return;
    }

    row.fechaNacimiento = new Date(row.fechaNacimiento).toISOString();

    // add new Alumno
    if (row.id === null) {
      const { id, isEditMode, ...payload } = row;
      const payloadArray = [payload];

      this.alumnosService.addAlumno(payloadArray).subscribe(
        (addedAlumno) => {
          row.id = addedAlumno.id;
          row.isEditMode = false;
          console.log('Alumno added', addedAlumno);

          this.loadAlumnos();
        },
        (error) => {
          console.error('Error adding alumno', error);
          alert(`An error occurred while adding the alumno: ${error.error}`);
        }
      );
    } else {
      // Update existing Alumno
      const { isEditMode, ...payload } = row;

      this.alumnosService.updateAlumno(row.id, payload).subscribe(
        (updatedAlumno) => {
          row.isEditMode = false;
          console.log('Alumno updated', updatedAlumno);

          this.loadAlumnos();
        },
        (error) => {
          console.error('Error updating alumno', error);
          alert(`An error occurred while updating the alumno: ${error.error}`);
        }
      );
    }
  }

  editRow(row: any) {
    row.isEditMode = true;
  }

  deleteRow(row: any) {
    this.alumnosService.deleteAlumno(row.id).subscribe(
      () => {
        this.dataSource.data = this.dataSource.data.filter((r) => r !== row);
      },
      (error) => {
        console.error('Error deleting alumno', error);
      }
    );
  }
}
