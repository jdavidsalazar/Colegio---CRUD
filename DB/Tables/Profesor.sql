CREATE TABLE Profesores (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Apellidos NVARCHAR(100) NOT NULL,
    Genero NVARCHAR(10) NOT NULL,
    IsActive BIT
);