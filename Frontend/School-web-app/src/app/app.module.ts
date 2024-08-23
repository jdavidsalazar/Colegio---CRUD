import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSelectModule } from '@angular/material/select';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavbarModule } from './navbar/navbar.module';
import { AlumnosComponent } from './alumnos/alumnos.component';
import { ProfesoresComponent } from './profesores/profesores.component';
import { GradosComponent } from './grados/grados.component';
import { AlumnoGradosComponent } from './alumnogrado/alumnogrado.component';

import { AlumnosService } from './services/alumnos.service';
import { ProfesoresService } from './services/profesores.service';
import { GradoService } from './services/grados.service';
import { AlumnoGradoService } from './services/alumnogrado.service';

@NgModule({
  declarations: [
    AppComponent,
    AlumnosComponent,
    ProfesoresComponent,
    GradosComponent,
    AlumnoGradosComponent,
  ],
  imports: [
    BrowserModule,
    NavbarModule,
    AppRoutingModule,
    RouterModule,
    MatToolbarModule,
    MatIconModule,
    MatTableModule,
    MatButtonModule,
    MatInputModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MatDatepickerModule,
    MatNativeDateModule,
    BrowserAnimationsModule,
    MatSelectModule,
  ],
  providers: [
    AlumnosService,
    ProfesoresService,
    GradoService,
    AlumnoGradoService,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
