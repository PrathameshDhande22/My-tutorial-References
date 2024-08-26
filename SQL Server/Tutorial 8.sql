/* --------- Day 8 ----------- */

/* difference between except and not in operator */

-- using except
select * from dice1
except
select * from dice2

-- using not in operator
select * from dice1
where no not in(select no from dice2)

-- insert the duplicates in dice1 tables
insert into dice1 values (3)

/* Intersect Operator */

select * from dice1
intersect
select * from dice2

-- same using join
select dice1.no from dice1
join dice2
on dice1.no=dice2.no

/* Cross Apply & Outer Apply */

Create function fn_GetEmployeesByDepartmentId(@DepartmentId int)
Returns Table
as
Return
(
    Select Id, Name, Gender, Salary, DepartmentId
    from Employee where DepartmentId = @DepartmentId
)

-- cross apply to apply join to table and function
select * from fn_GetEmployeesByDepartmentId(1)
select * from Employee
select * from Department

-- same using join
select E.id,E.Name,E.Gender,E.Salary,D.id,D.DepartmentName from Employee as E
join Department as D
on D.id=E.Departmentid

-- same using cross apply 
select D.id,D.departmentname,E.id,E.name,E.salary from Department as D
cross apply fn_GetEmployeesByDepartmentId(D.id) as E

-- using left join 
select E.id,E.Name,E.Gender,E.Salary,D.id,D.DepartmentName from Employee as E
right join Department as D
on D.id=E.Departmentid

-- using outer apply
select D.id,D.departmentname,E.id,E.name,E.salary from Department as D
outer apply fn_GetEmployeesByDepartmentId(D.id) as E

/* DDL Triggers */

-- creating the ddl trigger
alter trigger PreventDroppingTable
on database
for DROP_TABLE
as
begin
	rollback
	print 'Dropping the table you cannot drop the table'
end

-- creating the table
create table demotable (id int)

-- trying to drop the table
drop table demotable  -- you cannot drop the table

-- disabling the triggers
disable trigger PreventDroppingTable on database

-- enabling the triggers
enable trigger PreventDroppingTable on database

-- server scoped trigger
create trigger preventDroppingTable
on all server
for Drop_table
as
begin
	print 'you are not allowed to drop the table'
	rollback transaction
end

-- dropping the trigger
drop trigger preventDroppingTable

/* Select INTO Statement */

select * from Branch
Select * from Student
-- creates the new table
select * into StudentBackup from Student

select * from StudentBackup

-- creating the columns of the specified columns
select id,name,age into studentsOnly from Student
select * from studentsOnly

create table studenttable(id int,name nvarchar(50), age int)

-- you cannot use select into statement to already created table instead use insert into 
select id,name,age into studenttable from student

-- insert into statement
insert into studenttable
select id,name,age from student

select * from studenttable

/* Table Valued parameters */

-- creating the table types
create type StudentTableType as Table (
	id int,
	name nvarchar(50),
	branchid int,
	age int
)

-- drop the types
drop type StudentTabletype

-- adding the constriant to the type
create type StudentTableType as Table (
	id int primary key,
	name nvarchar(50),
	branchid int,
	age int
)

-- listing the table types present in the database
select * from sys.types where is_table_type=1
exec sp_table_types
select * from sys.table_types

-- passing the table type as parameter to the stored procedure
create procedure spAddMoreStudent
@studentTabletype StudentTableType readonly
as
begin
	insert into Student(id,name,branchid,age)
	select * from @studentTabletype
end

-- declaring the variable of the table type
declare @studentTabletype StudentTableType
insert into @studentTabletype values (233,'nadim',2,43),(256,'shaikh',3,67)

-- executing the stored procedure
exec spAddMoreStudent @studentTabletype

select * from Student

/* Grouping Sets */

select * from employees
select country,gender,sum(Salary),grouping(gender),GROUPING_ID(Country,Gender) from employees
group by GROUPING Sets(  -- grouping sets
	(Country,gender),
	(country),
	(gender),
	()
)
order by grouping(Country),GROUPING(gender)

-- grouping  id
select country,gender,sum(Salary),grouping(gender),GROUPING_ID(Country,Gender) as grp from employees
group by GROUPING Sets(  -- grouping sets
	(Country,gender),
	(country),
	(gender),
	()
)
order by grp

/* Over Clause */

-- using simple group by
select distinct prod.product_id, prod.product_name,sum(stocks.quantity)
from production.products as prod
join production.stocks as stocks
on prod.product_id=stocks.product_id
group by prod.product_id

select product_id, product_name,price,
sum(quantity) over(partition by product_id) as Total_Quantity,
brand,
category,
max(price) over(partition by category) as MaxPrice_Category,
avg(price) over(partition by category) as AvgPrice_category
from vw_ProductwithCategory

alter view vw_ProductwithCategory
as
select distinct prod.product_id, prod.product_name,prod.list_price as price,sum(stocks.quantity) over(partition by prod.product_id) as quantity,prod.model_year as model_year, cat.category_name as category,brand.brand_name as brand
from production.products as prod
join production.stocks as stocks
on prod.product_id=stocks.product_id
join production.brands as brand
on prod.brand_id=brand.brand_id
join production.categories as cat
on prod.category_id=cat.category_id

-- row number
select distinct product_id,product_name,category,brand,ROW_NUMBER() over(partition by category order by product_id)
from vw_ProductwithCategory
order by category


/* RANK & DENSE_RANK */

select * from Employee
insert into Employee values (6,'Mary','Male',67000,1),(7,'Steve','Male',78000,2),(8,'Anthony','Male',23000,3)

select id,Name,Gender,Salary, Rank() over(order by salary),DENSE_RANK() over(order by salary)  from Employee

