SELECT
    product_name,
    order_id
FROM
    production.products p
left JOIN sales.order_items o ON o.product_id = p.product_id
where order_id is null
ORDER BY
    order_id;

create table dice2(no int)
insert into dice2 values (2)
insert into dice1 values (1),(2),(3),(4),(5),(6)
select * from dice1
cross join dice2

/* 20 August */
-- try to insert space in unique column
exec sp_columns uniqueTable

alter table uniqueTable
add constraint UQ_uniqueTable_name unique(name)  

truncate table uniqueTable

select len(name),name from uniqueTable

insert into uniqueTable values ('   b   ')

alter table uniqueTable
drop constraint UQ_uniqueTable_name

alter table uniqueTable
alter column name varchar(50) not null

create function fn_UpdateFunction()
returns Table
as
Return (Select * from uniqueTable)

insert into fn_UpdateFunction() values (5,'name4')
update fn_UpdateFunction() set id=6 where name='name4'

-- referential integrity
select * from Student
select * from branch
update branch set id=6 where id=1

alter table Student
drop constraint Student_branchid_FK

alter table Student
add constraint FK_Student_branchid 
foreign key (branchid) references Branch(id) 
on update cascade


-- can we perform update operation in the function
alter function fn_AddTheValue(@id int)
returns @newTable Table (id int)
as
begin
	insert into @newTable values (@id)
	update @newTable set id=23 where id=@id
	return 
end

drop function fn_AddTheValue

select * from dbo.fn_AddTheValue(2)

-- creating the stored procedure that returns the table
create procedure sp_getTheTable
@Table_Variable as table(id int,name nvarchar(50))
as
begin
	insert into @Table_Variable values (1,'name1')
	select * from @Table_Variable
end

-- usage of subquery
select * from emp;
select * from emp where salary=(select Max(salary) from emp)

-- adding the primary key in another table
create table newtable(id int primary key not null,empid int)

alter table newtable
add constraint PK_newtable_empid Primary key (empid)

select * from Student
select * into StudentBackup from Student

-- can first value return null 
select id,FIRST_VALUE(id) over(order by id) from demotable
insert into demotable values (null),(1),(2),(200),(45)

create table employee(
	id int primary key,
	fullname nvarchar(40),
	managerId int,
	Dateofjoining date,
	city nvarchar(4))

insert into employee values (123,'name1',782,'2023-05-23','Tor'),(124,'name2',543,'2022-01-23','Can')

insert into employee values (543,'name3',566,'2023-08-12','Bor')

select * from employee
where =2023

select distinct * from employee as emp1
join employee as emp2
on emp1.managerId=emp2.id