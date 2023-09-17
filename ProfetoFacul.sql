create database ProjetoFacul

use ProjetoFacul

create table Cliente(
  Id varchar(50) PRIMARY KEY,
  Nome varchar(100),
  Telefone varchar(50) ,
  Celular varchar(50) ,
  Email varchar(100) ,  
  Endereco varchar(50) ,
  Numero varchar(10) ,
  Cep varchar(50) ,
  Cidade varchar(50),
  UF varchar(10)
  
)

create procedure ClienteIncluir(

 @Id varchar(50) ,
  @Nome varchar(100),
  @Telefone varchar(50) ,
  @Celular varchar(50) ,
  @Email varchar(100) ,  
  @Endereco varchar(100) ,
  @Numero varchar(10) ,
  @Cep varchar(50) ,
  @Cidade varchar(50),
  @UF varchar(10)
  )
  as

  insert into Cliente(Id,Nome,Telefone,Celular,Email,Endereco,Numero,Cep,Cidade,UF)
  values(@Id,@Nome,@Telefone,@Celular,@Email,@Endereco,@Numero,@Cep,@Cidade,@UF)

  create procedure ClienteListar

  as

  Select Id,Nome,Telefone,Celular,Email,Endereco,Numero,Cep,Cidade,UF
  from Cliente

  create procedure ClienteExcluir

  @Id varchar (50)

  as

  delete from Cliente where Id=@id

