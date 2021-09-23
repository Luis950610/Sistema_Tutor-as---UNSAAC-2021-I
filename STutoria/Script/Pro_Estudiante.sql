Create Procedure spu_Estudiante_Agregar
@CodEstudiante Varchar(6),
@Nombres Varchar(45),
@ApellidoPaterno Varchar(35),
@ApellidoMaterno Varchar(35),
@CarreraProfecional Varchar(4),
@Condicion Varchar(10)
as
begin 
 IF NOT EXISTS(SELECT 1 FROM Estudiante
			 WHERE CodEstudiante=@CodEstudiante)
	BEGIN
		INSERT INTO Estudiante(CodEstudiante,Nombres,ApellidoPaterno,ApellidoMaterno,CarreraProfesional,Condicion)
			VALUES(@CodEstudiante,@Nombres,@ApellidoPaterno,@ApellidoMaterno,@CarreraProfecional,@Condicion)
	END
	ELSE
		UPDATE Estudiante
			SET  
			Nombres=@Nombres, 
			ApellidoPaterno=@ApellidoPaterno, 
			ApellidoMaterno=@ApellidoMaterno, 
			CarreraProfesional=@CarreraProfecional,
			Condicion=@Condicion
			WHERE CodEstudiante=@CodEstudiante;
end;

create procedure spu_Estudiante_Eliminar
@CodEstudiante varchar(6)
as
begin
 delete from  Estudiante where CodEstudiante=@CodEstudiante;
end;

Create procedure spu_Estudiante_Recuperar
@CodEstudiante varchar(6)
as
 begin
	select CodEstudiante,Nombres,ApellidoPaterno,ApellidoMaterno,CarreraProfesional,Condicion  from Estudiante where  CodEstudiante=@CodEstudiante;
 end;


 create procedure spu_Estudiante_Listar
 as
 begin
 Select CodEstudiante,Nombres,ApellidoPaterno,ApellidoMaterno,CarreraProfesional,Condicion from Estudiante; 
 end;

create Procedure spu_Estudiante_Buscar
@CodEstudiante Varchar(6)
as
begin
select distinct CodEstudiante,Nombres,ApellidoPaterno,ApellidoMaterno,CarreraProfesional,Condicion
    from Estudiante
	WHERE CodEstudiante like '%'+@CodEstudiante+'%' 
	ORDER BY CodEstudiante;
end;