create database VC_CRUD

use VC_CRUD

create table student
(
student_id int identity primary key,
name varchar(50),
address varchar(100),
age int
)

select * from student
delete from student where student_id = 4
go
alter proc sp_student
@student_id					int				=0 ,
@name						varchar(50)		=null,
@address					varchar(100)	=null,
@age						int				=0,
@ops						varchar(50)		=null
as
begin
	if (@ops = 'insert')
	begin
	insert into student (name, address, age) values (@name, @address, @age)
	end

	else if (@ops = 'display')
	begin
	select * from student
	end

	else if (@ops = 'delete')
	begin
	delete from student where student_id = @student_id
	end

	else if (@ops = 'edit')
	begin
	select * from student where student_id = @student_id
	end

	else if (@ops = 'update')
	begin
	update student set name = @name, address = @address, age = @age  where student_id = @student_id 
	end

end