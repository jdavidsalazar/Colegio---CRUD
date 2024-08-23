CREATE TABLE Grados (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    ProfesorId INT,
    IsActive BIT,
    FOREIGN KEY (ProfesorId) REFERENCES Profesores(Id)
);