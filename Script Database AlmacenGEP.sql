CREATE DATABASE AlmacenGEP
GO
CREATE TABLE tipo_documento
(
	id_tipo_documento INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	tipo_documento VARCHAR(50) NOT NULL
)
GO
CREATE TABLE persona_prestamos
(
	id_persona_prestamo INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	id_tipo_documento INT NOT NULL FOREIGN KEY REFERENCES tipo_documento(id_tipo_documento),
	numero_documento INT NOT NULL,
	nombres VARCHAR(150) NOT NULL,
	apellidos VARCHAR(150) NOT NULL,
	teléfono VARCHAR(150) NOT NULL,
	correo VARCHAR(110) NOT NULL,
	fecha_creacion DATETIME NOT NULL, 
	estado BIT NOT NULL
)
GO
CREATE TABLE estado_herramienta
(
	id_estado INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	tipo_estado VARCHAR(100) NOT NULL,
	estado BIT NOT NULL
)
GO
CREATE TABLE herramientas
(
	id_herramienta INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	herramienta VARCHAR(300) NOT NULL,
	fecha_creacion DATETIME NOT NULL,
	estado BIT NOT NULL, 
)
GO 
CREATE TABLE prestamos
(
	id_prestamo INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	id_herramienta INT NOT NULL FOREIGN KEY REFERENCES herramientas(id_herramienta), 
	id_persona_retira INT NOT NULL FOREIGN KEY REFERENCES persona_prestamos(id_persona_prestamo), 
	id_persona_entrega INT NOT NULL FOREIGN KEY REFERENCES persona_prestamos(id_persona_prestamo), 
	id_persona_devulve INT NULL FOREIGN KEY REFERENCES persona_prestamos(id_persona_prestamo), 
	id_persona_recibe INT NULL FOREIGN KEY REFERENCES persona_prestamos(id_persona_prestamo), 
	id_estado_encuentra INT NOT NULL FOREIGN KEY REFERENCES estado_herramienta(id_estado), 
	id_estado_entrega INT NULL FOREIGN KEY REFERENCES estado_herramienta(id_estado), 
	observacion VARCHAR(1000) NULL,
	fecha_prestamo DATETIME NOT NULL,
	fecha_devolucion DATETIME NULL,
	entregado BIT NULL
)
