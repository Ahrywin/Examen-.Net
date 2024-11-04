# README

## Script para Crear la Tabla `Usuarios` e Insertar Registros Semilla

Este script SQL se utiliza para crear la tabla `Usuarios` en la base de datos existente y para insertar registros de usuario semilla.  este script se ejecuta en una base de datos que se encuentra en un servidor en la nube no es necesario crear una base de datos nueva.

### Crear la Tabla `Usuarios`

El siguiente comando crea la tabla `Usuarios` con los campos necesarios:

```sql
CREATE TABLE Usuarios (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    token varchar(255),
    password varchar(100) NOT NULL,
    brithday datetime,
    name varchar(60),
    name2 varchar(60) NOT NULL,
    lastName varchar(60) NOT NULL,
    displayName varchar(200),
    email varchar(100) NOT NULL,
    phoneNumber varchar(18) NOT NULL,
    photoUrl varchar(255) NOT NULL,
    country varchar(50) NOT NULL,
    estado varchar(50) NOT NULL,
    userRol int NOT NULL,
    emailVerified bit,
    phoneVerified bit,
    createAt datetime,
    lastLogin datetime,
    origin varchar(100),
    createdBy UNIQUEIDENTIFIER
);


### Agregar datos semilla a la tabla `Usuarios`

El siguiente comando agrega datos semilla a la tabla `Usuarios`:

```sql
INSERT INTO Usuarios (token, password, brithday, name, name2, lastName, displayName, email, phoneNumber, photoUrl, country, estado, userRol, emailVerified, phoneVerified, createAt, lastLogin, origin, createdBy)
VALUES 
('token1', 'password1', '1990-01-01', 'Juan', 'Pablo', 'García', 'Juanito', 'juan.garcia@example.com', '555-1234', 'http://example.com/photo1.jpg', 'España', 'Madrid', 1, 1, 1, GETDATE(), GETDATE(), 'web', NEWID()),
('token2', 'password2', '1985-05-15', 'María', 'Jose', 'López', 'Mari', 'maria.lopez@example.com', '555-5678', 'http://example.com/photo2.jpg', 'México', 'CDMX', 2, 1, 1, GETDATE(), GETDATE(), 'mobile', NEWID()),
('token3', 'password3', '1992-09-30', 'Carlos', 'Andrés', 'Martínez', 'Carlitos', 'carlos.martinez@example.com', '555-8765', 'http://example.com/photo3.jpg', 'Argentina', 'Buenos Aires', 1, 1, 0, GETDATE(), GETDATE(), 'web', NEWID()),
('token4', 'password4', '1988-12-12', 'Laura', 'Beatriz', 'Hernández', 'Lau', 'laura.hernandez@example.com', '555-4321', 'http://example.com/photo4.jpg', 'Colombia', 'Bogotá', 2, 0, 1, GETDATE(), GETDATE(), 'mobile', NEWID()),
('token5', 'password5', '1979-07-23', 'Pedro', 'Antonio', 'Sánchez', 'Pedrito', 'pedro.sanchez@example.com', '555-1357', 'http://example.com/photo5.jpg', 'Chile', 'Santiago', 1, 1, 1, GETDATE(), GETDATE(), 'web', NEWID());
