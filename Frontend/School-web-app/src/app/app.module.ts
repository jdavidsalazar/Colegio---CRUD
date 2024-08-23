import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';

import { AppComponent } from './app.component';
import { NavbarModule } from './navbar/navbar.module';
import { AlumnosComponent } from './alumnos/alumnos.component';
import { ProfesoresComponent } from './profesores/profesores.component';
import { GradosComponent } from './grados/grados.component';
import { AlumnogradoComponent } from './alumnogrado/alumnogrado.component';

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
    AlumnogradoComponent,
  ],
  imports: [
    BrowserModule,
    NavbarModule,
    AppRoutingModule,
    MatToolbarModule,
    MatIconModule,
    MatTableModule,
    MatButtonModule,
    MatInputModule,
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
