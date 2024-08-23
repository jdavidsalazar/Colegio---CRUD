import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { ProfesoresService } from '../../services/profesores.service';

@Component({
  selector: 'app-profesores',
  templateUrl: './profesores.component.html',
  styleUrls: ['./profesores.component.css'],
})
export class ProfesoresComponent implements OnInit {
  displayedColumns: string[] = [
    'id',
    'nombre',
    'apellidos',
    'genero',
    'edit',
    'delete',
  ];

  dataSource = new MatTableDataSource<any>([]);

  generoOptions: string[] = ['Masculino', 'Femenino', 'Otro'];

  constructor(private profesoresService: ProfesoresService) {}

  ngOnInit(): void {
    this.loadProfesores();
  }

  loadProfesores(): void {
    this.profesoresService.getProfesores().subscribe(
      (data) => {
        this.dataSource.data = data;
      },
      (error) => {
        console.error('Error loading profesores', error);
      }
    );
  }

  addNewRow() {
    const newRow = {
      id: null,
      nombre: '',
      apellidos: '',
      genero: '',
      isEditMode: true,
    };
    this.dataSource.data = [newRow, ...this.dataSource.data];
  }

  saveRow(row: any) {
    if (!row.nombre || !row.apellidos || !row.genero) {
      console.error('Validation failed: All fields are required');
      alert('Please fill out all required fields.');
      return;
    }

    // add new Profesor
    if (row.id === null) {
      const { id, isEditMode, ...payload } = row;
      const payloadArray = [payload];

      this.profesoresService.addProfesor(payloadArray).subscribe(
        (addedProfesor) => {
          row.id = addedProfesor.id;
          row.isEditMode = false;
          console.log('Profesor added', addedProfesor);

          this.loadProfesores();
        },
        (error) => {
          console.error('Error adding profesor', error);
          alert(`An error occurred while adding the profesor: ${error.error}`);
        }
      );
    } else {
      // Update existing Profesor
      const { isEditMode, ...payload } = row;

      this.profesoresService.updateProfesor(row.id, payload).subscribe(
        (updatedProfesor) => {
          row.isEditMode = false;
          console.log('Profesor updated', updatedProfesor);

          this.loadProfesores();
        },
        (error) => {
          console.error('Error updating profesor', error);
          alert(
            `An error occurred while updating the profesor: ${error.error}`
          );
        }
      );
    }
  }

  editRow(row: any) {
    row.isEditMode = true;
  }

  deleteRow(row: any) {
    this.profesoresService.deleteProfesor(row.id).subscribe(
      () => {
        this.dataSource.data = this.dataSource.data.filter((r) => r !== row);
      },
      (error) => {
        console.error('Error deleting profesor', error);
      }
    );
  }
}
