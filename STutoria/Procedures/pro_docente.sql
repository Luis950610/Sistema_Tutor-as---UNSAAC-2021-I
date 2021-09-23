Create Procedure spu_Docente_Agregar
@CodDocente Varchar(5),
@Nombres Varchar(20),
@ApellidoPaterno Varchar(25),
@ApellidoMaterno Varchar(25),
@Clase Varchar(20),
@Categoria Varchar(20),
@Regimen Varchar(20),
@CarreraProfecional Varchar(4)
as
begin 
 IF NOT EXISTS(SELECT 1 FROM Docente
			 WHERE CodDocente=@CodDocente)
	BEGIN
		INSERT INTO Docente(CodDocente,Nombres,ApellidoPaterno,ApellidoMaterno,Clase,Categoria,Regimen,CarreraProfesional)
			VALUES(@CodDocente,@Nombres,@ApellidoPaterno,@ApellidoMaterno,@Clase,@Categoria,@Regimen,@CarreraProfecional)
	END
	ELSE
		UPDATE Docente
			SET  
			Nombres=@Nombres, 
			ApellidoPaterno=@ApellidoPaterno, 
			ApellidoMaterno=@ApellidoMaterno, 
			Clase=@Clase,
			Categoria=@Categoria,
			Regimen=@Regimen,
			CarreraProfesional=@CarreraProfecional
			WHERE CodDocente=@CodDocente;
end;

create procedure spu_Docente_Eliminar
@CodDocente varchar(5)
as
begin
 delete from  Docente where CodDocente=@CodDocente;
end;

Create procedure spu_Docente_Recuperar
@CodDocente varchar(5)
as
 begin
	select CodDocente,Nombres,ApellidoPaterno,ApellidoMaterno,Clase,Categoria,Regimen,CarreraProfesional  from Docente where  CodDocente=@CodDocente;
 end;


 create procedure spu_Docente_Listar
 as
 begin
 Select CodDocente,Nombres,ApellidoPaterno,ApellidoMaterno,Clase,Categoria,Regimen,CarreraProfesional from Docente; 
 end;

create Procedure spu_Docente_Buscar
@CodDocente Varchar(5)
as
begin
select distinct CodDocente,Nombres,ApellidoPaterno,ApellidoMaterno,Clase,Categoria,Regimen,CarreraProfesional
    from Docente
	WHERE CodDocente like '%'+@CodDocente+'%' 
	ORDER BY CodDocente;
end;