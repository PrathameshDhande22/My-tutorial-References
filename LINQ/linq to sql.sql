/* LINQ to SQL Tutorial */ 

-- script
Create table Departments
(
     ID int primary key identity,
     Name nvarchar(50),
     Location nvarchar(50)
)
GO

Create table Employees
(
     ID int primary key identity,
     FirstName nvarchar(50),
     LastName nvarchar(50),
     Gender nvarchar(50),
     Salary int,
     DepartmentId int foreign key references Departments(Id)
)
GO

Insert into Departments values ('IT', 'New York')
Insert into Departments values ('HR', 'London')
Insert into Departments values ('Payroll', 'Sydney')
Insert into Departments values ('Technician','Canada')
GO

Insert into Employees values ('Mark', 'Hastings', 'Male', 60000, 1)
Insert into Employees values ('Steve', 'Pound', 'Male', 45000, 3)
Insert into Employees values ('Ben', 'Hoskins', 'Male', 70000, 1)
Insert into Employees values ('Philip', 'Hastings', 'Male', 45000, 2)
Insert into Employees values ('Mary', 'Lambeth', 'Female', 30000, 2)
Insert into Employees values ('Valarie', 'Vikings', 'Female', 35000, 3)
Insert into Employees values ('John', 'Stanmore', 'Male', 80000, 1)
GO

select * from employees
go

-- create stored procedure
create proc getEmployees
as
begin
	select * from employees
end
go

-- create another table
create table Student(
	id int,
	name nvarchar(40),
	rollno int Identity,
	school nvarchar(70)
)
go

select * from Student
go

-- stored procedure with output paramete
alter proc getTotalEmployeeCount
@gender nvarchar(40),
@count int output
as
begin
	select @count=count(id) from employees
	where Gender=@gender
end
go

declare @count int
exec getTotalEmployeeCount 'Male',@count out
select @count
go

-- creating a stored procedure which throws error
create proc spThrowError
as
begin	
	raiserror('unable to find error',16,1)
end
go

exec spThrowError
go

-- creating the table valued parameter
create type TyEmployee as table(
	FirstName nvarchar(50),
	LastName nvarchar(50),
	Gender nvarchar(50),
	Salary int,
	DepartmentId int
)
go

--creating a stored procedure with TVPs
create proc spAddInTheEmployees
@tabletype TyEmployee readonly
as
begin
	insert into employees
	select * from @tabletype
end
go

declare @tabletype TyEmployee
insert into @tabletype values ('Steve','Louis','Male',60000,null)
exec spAddInTheEmployees @tabletype
select * from Employees
go

create function fnGetCount(@Gender nvarchar(40))
returns int
as
begin
	declare @count int
	select @count=count(id) from employees
	where Gender=@gender
	return @count
end
go

select dbo.fnGetCount('Male');
go

SELECT [t1].[Name] AS [Key],count([t0].id)
FROM [dbo].[Employees] AS [t0]
INNER JOIN [dbo].[Departments] AS [t1] ON [t0].[DepartmentId] = ([t1].[ID])
GROUP BY [t1].[Name]
go

-- left outer join
select * from Employees as emp
right join Departments as dept
on emp.DepartmentId=dept.ID
