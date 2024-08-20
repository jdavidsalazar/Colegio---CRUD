CREATE TABLE AlumnoGrado (
    Id INT PRIMARY KEY,
    AlumnoId INT,
    GradoId INT,
    Grupo NVARCHAR(50),
    FOREIGN KEY (AlumnoId) REFERENCES Alumno(Id),
    FOREIGN KEY (GradoId) REFERENCES Grado(Id)
);