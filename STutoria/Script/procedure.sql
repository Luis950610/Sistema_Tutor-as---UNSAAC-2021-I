CREATE PROCEDURE spu_Usuario_Recuperar 
@CodUsuario varchar(5) 
as 
 begin
  Select * from Usuario where CodUsuario = @CodUsuario;
end;


Create Procedure spu_Usuario_Agregar
@CodUsuario Varchar(5),
@Hash Varchar(40),
@UserNew Varchar(50),
@UserEdit Varchar(50),
@TipoUser Varchar(1)
as
begin 
 IF NOT EXISTS(SELECT 1 FROM Usuario
			 WHERE CodUsuario=@CodUsuario)
	BEGIN
		INSERT INTO Usuario(CodUsuario,Hash,UserNew,UserEdit,DateNew,DateEdit,TipoUser)
			VALUES(@CodUsuario,@Hash,@UserNew,@UserEdit,SYSDATETIME(),SYSDATETIME(),@TipoUser)
	END
	ELSE
		UPDATE Usuario
			SET  
			Hash=@Hash, 
			UserEdit=@UserEdit, 
			DateEdit=SYSDATETIME(), 
			TipoUser=@TipoUser
			 WHERE CodUsuario=@CodUsuario;
end;



create procedure spu_Usuario_Eliminar
@CodUsuario varchar(5)
as
begin
 delete from  Usuario where CodUsuario=@CodUsuario;
end;
Create procedure spu_Usuario_Recuperar
@CodUsuario varchar(5)
as
 begin
	select CodUsuario,Hash,UserNew ,UserEdit,TipoUser from Usuario where CodUsuario=@CodUsuario;
 end;


 create procedure spu_Usuario_Listar
 as
 begin
 Select CodUsuario,Hash,UserNew ,UserEdit,TipoUser from Usuario ; 
 end;

create Procedure spu_Usuario_Buscar
@CodUsuario Varchar(5)
as
begin
select distinct CodUsuario,Hash,UserNew ,UserEdit,TipoUser
    from Usuario
	WHERE CodUsuario like '%'+@CodUsuario+'%' 
	ORDER BY CodUsuario;
end;


exec spu_Usuario_Recuperar Admin
select * from Usuario
exec spu_Usuario_Agregar 'Admin','P7T8s3og68I=','Admin','Admin','D'

select * from Estudiante