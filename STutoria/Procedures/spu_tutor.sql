Create Procedure spu_Tutor_Agregar
@CodDocente Varchar(5),
@Nombres Varchar(20),
@ApellidoPaterno Varchar(25),
@ApellidoMaterno Varchar(25),
@Clase Varchar(20),
@Categoria Varchar(20),
@Regimen Varchar(20),
@EscuelaProfecional Varchar(4),
@CantidadEstudiantes Varchar(4)
as
begin 
 IF NOT EXISTS(SELECT 1 FROM Tutor
			 WHERE CodDocente=@CodDocente)
	BEGIN
		INSERT INTO Tutor(CodDocente,Nombres,ApellidoPaterno,ApellidoMaterno,Clase,Categoria,Regimen,EscuelaProfesional,CantidadEstudiantes)
			VALUES(@CodDocente,@Nombres,@ApellidoPaterno,@ApellidoMaterno,@Clase,@Categoria,@Regimen,@EscuelaProfecional,@CantidadEstudiantes)
	END
	ELSE
		UPDATE Tutor
			SET  
			Nombres=@Nombres, 
			ApellidoPaterno=@ApellidoPaterno, 
			ApellidoMaterno=@ApellidoMaterno, 
			Clase=@Clase,
			Categoria=@Categoria,
			Regimen=@Regimen,
			EscuelaProfesional=@EscuelaProfecional,
			CantidadEstudiantes=@CantidadEstudiantes
			WHERE CodDocente=@CodDocente;
end;
go;
create procedure spu_Tutor_Eliminar
@CodDocente varchar(5)
as
begin
 delete from  Tutor where CodDocente=@CodDocente;
end;
go;
Create procedure spu_Tutoir_Recuperar
@CodDocente varchar(5)
as
 begin
	select CodDocente,Nombres,ApellidoPaterno,ApellidoMaterno,Clase,Categoria,Regimen,EscuelaProfesional,CantidadEstudiantes  from Tutor where  CodDocente=@CodDocente;
 end;
 Go;

 create procedure spu_Tutor_Listar
 as
 begin
 Select CodDocente,Nombres,ApellidoPaterno,ApellidoMaterno,Clase,Categoria,Regimen,EscuelaProfesional,CantidadEstudiantes from Tutor; 
 end;
 go;
create Procedure spu_Tutor_Buscar
@CodDocente Varchar(5)
as
begin
select distinct CodDocente,Nombres,ApellidoPaterno,ApellidoMaterno,Clase,Categoria,Regimen,EscuelaProfesional
    from Tutor
	WHERE CodDocente like '%'+@CodDocente+'%' 
	ORDER BY CodDocente;
end;