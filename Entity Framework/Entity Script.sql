/* Entity Tutorial */

select * from Employees

exec sp_columns Employees

delete from Employees where ID=15

create table sampletable(id int)

declare @i int=1
while @i<=100
begin
	insert into #temptable values (@i*50,'Person '+cast(@i as nvarchar),'Technician')
	set @i=@i+1
end
select * from sampletable
select @@ROWCOUNT
select * from #temptable
SELECT @@SERVERNAME
truncate table sampletable

create table #temptable (id int,name nvarchar(50),course nvarchar(50))

DBCC FREEPROCCACHE

SELECT cp.usecounts, cp.cacheobjtype, cp.objtype, st.text, qp.query_plan
FROM sys.dm_exec_cached_plans AS cp
CROSS APPLY sys.dm_exec_sql_text(plan_handle) AS st
CROSS APPLY sys.dm_exec_query_plan(plan_handle) AS qp
ORDER BY cp.usecounts DESC

alter table sampletable
add name nvarchar(40)


alter table sampletable
add course nvarchar(50)

-- update using join
update sampletable
set course=t1.course
from sampletable s1
inner join #temptable t1
on s1.id=t1.id


-- creating the table type
create type TypeSample as Table(id int,name nvarchar(50),course nvarchar(50))

-- creating the stored procedure with table valued parameter
create proc spAddintheSample
@tabletype TypeSample Readonly
as
begin
	update sampletable
	set course=t1.course,name=t1.name
	from sampletable s1
	inner join @tabletype t1
	on s1.id=t1.id
end

declare @tablet TypeSample
insert into @tablet values (0,'Person 200','Arts')
exec spAddintheSampleMerge @tablet
select * from sampletable

-- creating the stored procedure with merge clause
create proc spAddintheSampleMerge
@tabletype TypeSample Readonly
as
begin
	merge sampletable s using @tabletype t
	on s.id=t.id
	when matched 
		then update set name=t.name, course=t.course;
end

merge sampletable s 
using #temptable t
on s.id=t.id
when matched 
	then update set name=t.name, course=t.course;

merge sampletable s
using #temptable t
on s.id=t.id
when matched then delete;

select * from employees
SELECT FirstName st FROM Employees AS st WHERE st.FirstName = 'Mark'

select * from production.products

select distinct firstname,LastName from Employees

create table sampTable (id int,name nvarchar(40))
exec sp_tables

select * from Students

select * from StudentCourse

select * from Student
where rollno >26 and rollno<30

-- create column of rowversion in student table
alter table Student
add rowversion timestamp

-- creating the stored procedure to get the courses assinged to particular student
create proc sp_GetCoursesOfStudentId
@id int
as
begin
	select c.CourseName,c.CourseId from StudentCourse as sc
	join Course as c
	on sc.CourseId=c.CourseId
	where sc.StudentId=@id
end

-- executing the stored procedure
exec sp_GetCoursesOfStudentId 2

-- Creating the stored procedure with output parameter
alter proc sp_GetTotalStudentCourseByCount
@courseName nvarchar(40),
@count int output
as
begin	
	select @count=count(*) from StudentCourse as sc
	join Course as c
	on sc.CourseId=c.CourseId
	join Students as s
	on sc.StudentId=s.StudentId
	where c.CourseName=@courseName
end

-- executing the stored procedure
declare @count int
exec sp_GetTotalStudentCourseByCount 'Biology',@count out
select @count

-- creating the stored Procedure with TVPs
create type StudentType as Table(
	id int,
	name nvarchar(30),
	school nvarchar(50)
)

create proc sp_AddTheStudent
@tabletype StudentType readonly
as
begin
	insert into Student(id,name,school)
	select id,name,school from @tabletype
end

-- creating the stored procedure with Insert Mapping
create proc sp_InsertStudent
@id int,
@name nvarchar(50),
@school nvarchar(50)
as
begin
	insert into Student(id,name,school) values (@id,@name,@school)
	select SCOPE_IDENTITY() AS ROLLNO;
END

-- enum supporting in EF
create table EmployeeRole(
	id int,
	roleu int
)
alter table EmployeeRole
alter column id int not null

alter table EmployeeRole
add Constraint PK_EmployeeRole_id primary key(id)

insert into EmployeeRole values (1,1),(2,1),(3,1),(4,2),(5,2),(6,3);

select * from EmployeeRole

-- Creating the Simple Function
create function fn_GetCountOfStudents(@coursename nvarchar(40))
returns int
as
begin	
	declare @count int
	select @count=count(*) from StudentCourse as sc
	join Course as c
	on sc.CourseId=c.CourseId
	join Students as s
	on sc.StudentId=s.StudentId
	where c.CourseName=@courseName
	return @count
end

-- calling the function
select dbo.fn_GetCountOfStudents('Biology')


-- creating the table valued function
create function fn_GetStudentDetails(@courseName nvarchar(40))
returns table
return (
	select s.StudentId,s.StudentName,c.CourseName from StudentCourse as sc
	join Course as c
	on sc.CourseId=c.CourseId
	join Students as s
	on sc.StudentId=s.StudentId
	where c.CourseName=@courseName
)

-- calling the table valued function
select * from fn_GetStudentDetails('Biology')

-- creating the multistatement-table-valued fn
create function fn_GetStudentDetailsMulti(@courseName nvarchar(40))
returns @result Table(id int,StudentName nvarchar(60),CourseName nvarchar(60))
as
begin
	insert into @result
	select s.StudentId,s.StudentName,c.CourseName from StudentCourse as sc
	join Course as c
	on sc.CourseId=c.CourseId
	join Students as s
	on sc.StudentId=s.StudentId
	where c.CourseName=@courseName
	return 
end

select * from Course
exec sp_columns Course

create table #temp(CourseId int,CourseName nvarchar(100))
insert into #temp
select * from Course
drop table Course

use Shopping
truncate table shop.ShopProducts
select * from shop.ShopProducts
use master

use shopping
select * from shop.ShopProducts
select * from visit.Visitor
select * from shop.__MigrationHistory
truncate table shop.__MigrationHistory

insert into shop.Samples values ('b'),('c');
select * from shop.Samples
exec sp_columns __MigrationHistory

drop database Shopping

