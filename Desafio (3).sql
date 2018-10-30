CREATE DATABASE Desafio
go

use Desafio 
go

CREATE TABLE tipoMateria(
	id_tipo_materia int primary key identity(1,1),
	ntipo_materia varchar(20) default 'Optativa' not null
);
go

create table departamento(
	id_departamento int primary key identity(1,1),
	ndepartamento varchar(100) not null unique
);
go

create table areaConocimiento(
	id_area_conocimiento int primary key identity(1,1),
	narea_conocimiento varchar(100) not null unique,
	id_departamento int not null,
	constraint fk_departamento_area foreign key (id_departamento) 
	references departamento (id_departamento)
);
go

create table titulacion(
	id_titulacion int primary key identity,
	ntitulacion varchar(100) not null unique,
	id_area_conocimiento int not null,
	constraint fk_titulacion_areaConocimiento foreign key (id_area_conocimiento) 
	references areaConocimiento(id_area_conocimiento)
);
go



CREATE TABLE profesor(
	id_profesor int primary key identity(1,1),
	nombre varchar(100) not null, 
	apellido varchar(100) not null,
	despacho varchar(6),
	horario_Consultas varchar(150),
	id_area_conocimiento int not null,
	constraint fk_profesor_area foreign key (id_area_conocimiento) 
	references areaConocimiento(id_area_conocimiento)
);
go

CREATE TABLE materia(
	id_materia int primary key identity(1,1),
	nmateria varchar(100) not null unique,
	codigo_materia char(3) not null unique,
	curso int,
	id_tipo_materia int not null,
	id_titulacion int not null,
	creditos_teoricos decimal,
	creditos_laboratorio decimal,
	duracion varchar(50) default 'Primer Semestre',
	limiteAdmision int,
	gruposTeoria int default 1,
	gruposLaboratorio int default 1,
	constraint fk_equivalencia foreign key (id_titulacion) 
	references titulacion (id_titulacion),
	CONSTRAINT FK_MateriaTipo FOREIGN KEY (id_tipo_materia) 
	REFERENCES tipoMateria (id_tipo_materia)
);
go

create table materia_profesor(
	id_materia int not null,
	id_profesor int not null,
	constraint fk_materia foreign key (id_materia) references materia (id_materia),
	constraint fk_profesor foreign key (id_profesor) references profesor (id_profesor)
);

create proc insertarTipo
(
@tipo varchar(20)
) with encryption as
begin
	insert into tipoMateria(ntipo_materia) values (@tipo);
end

exec insertarTipo 'Optativa';
exec insertarTipo 'Obligatoria';

create proc verTipos
with encryption as
begin
	select * from tipoMateria;
end

create proc insertarDepartamento(
@departamento varchar(100)
) with encryption as
begin
	insert into departamento(ndepartamento) values (@departamento);
end

exec insertarDepartamento 'Estudios Tecnologicos';
exec insertarDepartamento 'Ciencias Basicas';

create proc verDepartamentos
with encryption as
begin
	select * from departamento;
end

exec verDepartamentos

insert into areaConocimiento(narea_conocimiento, id_departamento) 
values ('Programacion',1);

insert into titulacion(ntitulacion,id_area_conocimiento)
values ('Programador',1);

select titulacion.ntitulacion, areaConocimiento.narea_conocimiento, departamento.ndepartamento
from titulacion join areaConocimiento on titulacion.id_area_conocimiento = areaConocimiento.id_area_conocimiento
join departamento on areaConocimiento.id_departamento = departamento.id_departamento;

create proc insertarMateria(
@materia varchar(100),
@codigo_materia char(3),
@curso int,
@id_tipo_materia int,
@id_titulacion int,
@creditos_teoricos decimal,
@creditos_laboratorio decimal,
@duracion varchar(50),
@limiteAdmision int,
@gruposTeoria int,
@gruposLaboratorio int
)
with encryption as
begin
	insert into materia values (@materia,@codigo_materia,@curso,@id_tipo_materia,@id_titulacion,@creditos_teoricos,@creditos_laboratorio,@duracion,@limiteAdmision,@gruposTeoria,@gruposLaboratorio)
end

create proc modificarMateria(
@materia varchar(100),
@codigo_materia char(3),
@curso int,
@id_tipo_materia int,
@id_titulacion int,
@creditos_teoricos decimal,
@creditos_laboratorio decimal,
@duracion varchar(50),
@limiteAdmision int,
@gruposTeoria int,
@gruposLaboratorio int,
@idMateria int
)
with encryption as
begin
	update materia set nmateria=@materia,codigo_materia=@codigo_materia,curso=@curso,id_tipo_materia=@id_tipo_materia,id_titulacion=@id_titulacion,creditos_teoricos=@creditos_teoricos,creditos_laboratorio=@creditos_laboratorio,duracion=@duracion,limiteAdmision=@limiteAdmision,gruposTeoria=@gruposTeoria,gruposLaboratorio=@gruposLaboratorio where id_materia=@idMateria
end

create proc eliminarMateria(
@idMateria int
) with encryption as
begin
	delete from materia where id_materia = @idMateria;
end

create proc insertarProfe
(
@nombre varchar(100), 
@apellido varchar(100),
@despacho varchar(6),
@horario_Consultas varchar(150),
@id_area_conocimiento int
) with encryption as
begin
	insert into profesor values
	(@nombre, @apellido,@despacho,@horario_Consultas,@id_area_conocimiento)
end

create proc modificarProfe
(
@id_profesor int,
@nombre varchar(100), 
@apellido varchar(100),
@despacho varchar(6),
@horario_Consultas varchar(150),
@id_area_conocimiento int
) with encryption as
begin
	update profesor set nombre=@nombre, apellido=@apellido, despacho=@despacho,horario_Consultas=@horario_Consultas,id_area_conocimiento=@id_area_conocimiento where id_profesor=id_profesor;
end

create proc eliminarProfe
(@id_profesor int)
with encryption as
begin
	delete from profesor where id_profesor=@id_profesor;
end

select * from materia where id_materia = 1;

select materia.nmateria as Nombre, materia.codigo_materia as Codigo, materia.curso as Curso, 
tipoMateria.ntipo_materia as Tipo, titulacion.ntitulacion as Titulacion, materia.creditos_teoricos as [Creditos Teoricos], 
materia.creditos_laboratorio as [Creditos Laboratorio], materia.duracion as Duracion, materia.limiteAdmision as [Limite Adision], 
materia.gruposTeoria as [Grupos Teoria], materia.gruposLaboratorio as [Grupos Laboratorio] 
from tipoMateria join materia on tipoMateria.id_tipo_materia = materia.id_tipo_materia join titulacion 
on titulacion.id_titulacion = materia.id_titulacion where materia.id_materia = 1;


create proc mostrarMaterias
(
@idTipo int
) as
begin
	select * from materia where id_tipo_materia = @idTipo;
end


create proc verProfesores
as
begin
	select * from profesor;
end