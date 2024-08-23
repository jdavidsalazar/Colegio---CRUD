CREATE TABLE AlumnoGrado (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    AlumnoId INT,
    GradoId INT,
    Grupo NVARCHAR(50),
    IsActive BIT,
    FOREIGN KEY (AlumnoId) REFERENCES Alumnos(Id),
    FOREIGN KEY (GradoId) REFERENCES Grados(Id)
);