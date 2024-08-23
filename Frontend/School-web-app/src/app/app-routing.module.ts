import { AlumnosComponent } from './alumnos/alumnos.component';
import { ProfesoresComponent } from './profesores/profesores.component';
import { GradosComponent } from './grados/grados.component';
import { AlumnoGradosComponent } from './alumnogrado/alumnogrado.component';

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: 'alumnos', component: AlumnosComponent },
  { path: 'profesores', component: ProfesoresComponent },
  { path: 'grados', component: GradosComponent },
  { path: 'alumnogrado', component: AlumnoGradosComponent },
  { path: '', redirectTo: '/alumnos', pathMatch: 'full' },
  { path: '**', redirectTo: '/alumnos' },
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
