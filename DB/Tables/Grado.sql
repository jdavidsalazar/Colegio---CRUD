CREATE TABLE Grado (
    Id INT PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    ProfesorId INT,
    FOREIGN KEY (ProfesorId) REFERENCES Profesor(Id)
);