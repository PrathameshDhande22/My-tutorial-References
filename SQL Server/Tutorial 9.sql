/* ------------ Day 9 ------------- */

/* Difference between row_number, rank and dense rank */
select id,name,gender,salary,row_number() over(order by salary) rowno,rank() over(order by salary) simple_rank,DENSE_RANK() over(order by salary) dense_rank
from employee


/* Lead and Lag function */

select id,name,gender,salary, LEAD(salary,1,0) over(order by salary) as nextSalary, LAG(salary,1,0) over(order by salary) as prevSalary,LEAD(salary,1,0) over(order by salary)-Salary as diffSalary
from employee

/* First value function */
select id,name,gender,salary, FIRST_VALUE(salary) over(partition by gender order by salary desc) as highSalary
from employee

select cust.first_name,cust.last_name,ordi.list_price,ordi.list_price-FIRST_VALUE(ordi.list_price) over(order by ord.order_date) as purchase_ince,ord.order_date
from sales.orders as ord
join sales.customers as cust
on ord.customer_id=cust.customer_id
join sales.order_items as ordi
on ordi.order_id=ord.order_id
where ord.customer_id=5
order by ord.order_date

/* Rows and range in SQL */
-- include all the rows from starting to end columns
select id,name,gender,salary,count(salary) over(order by salary rows between unbounded preceding and unbounded following)
from Employee

-- specifying the rows to be counted
select id,name,gender,salary,count(salary) over(order by salary rows between 1 preceding and 1 following),sum(salary) over(order by salary rows between 1 preceding and 1 following)
from Employee


-- specifying the range
select id,name,gender,salary,count(salary) over(order by salary rows between 1 preceding and 1 following),sum(salary) over(order by salary range between unbounded preceding and current row)
from Employee

/* Last value */
select id,name,gender,salary,LAST_VALUE(salary) over(order by salary rows between unbounded preceding and unbounded following)
from Employee

/* IIF Function */
declare @name nvarchar(40)
set @name='nothing'
select IIF(@name='nothing','Provide Name','Correct Name')

/* Try_Parse Function */
select TRY_PARSE('123' as int) -- returns 123
select TRY_PARSE('12B' as int) -- returns null
-- using parse method
select PARSE('12B' as int) -- raise errors

/* Try convert function */
select TRY_CONVERT(int,'123') -- returns 123
select TRY_CONVERT(int,'12b') -- returns null
select CONVERT(int,'12b') -- throws error as explicitly conversion

/* Datetime from parts function */
select DATEFROMPARTS(2003,03,22) 
select DATEFROMPARTS(2003,null,21) -- returns null


/* Offset and fetch clause */
select * from employee
order by id
offset 2 rows
fetch next 2 rows only


/* GUID */

-- delcaring the guid variable
declare @uniqueid uniqueidentifier
set @uniqueid=NEWID() -- newid returns the guid or uniqueidentifier
select @uniqueid

-- creating the table of Guid
create table sampleCustomers(
	id uniqueidentifier default newid(),
	name nvarchar(40)
)

-- inserting the data into the table
insert into sampleCustomers(name) values ('Steve'),('Mark'),('John'),('Anthony')

select * from sampleCustomers

-- checking if the guid is null

-- using is null keyword
declare @idvar uniqueidentifier
set @idvar=null
if( @idvar is null)
	print 'idvar is null'
else 
	print @idvar

-- using isnull function
select ISNULL(@idvar,newid())

-- using colescpe function
select coalesce(@idvar,newid())

-- creating the empty guid
select cast(cast(0 as binary) as uniqueidentifier)

-- checking if the guid is empty
declare @emptyid uniqueidentifier
set @emptyid = '00000000-0000-0000-0000-000000000000'
if(@emptyid=cast(cast(0 as binary) as uniqueidentifier))
	print 'empty'

/* Dynamic SQL */

-- writing the sql query in string
declare @statement nvarchar(1000)
set @statement = 'select * from employee'

-- executing the sql string using stored procedure
exec sp_executesql @statement

-- passing the parameters to it.
declare @statement1 nvarchar(1000)
declare @params nvarchar(1000)

-- sql string
set @statement1='select * from employee where name=@name and id=@id'
-- parameters declaration
set @params='@name nvarchar(30), @id int'

-- executing the sql string 
execute sp_executesql @statement1,@params,@id=3,@name='Steve'

--creating the table using sql string
declare @statement2 nvarchar(1000)
set @statement2='create table sampletable2(id int)'
print @statement2
exec sp_executesql @statement2


/* SQL Query plan cache */

-- to view the query plan cache
select * from sys.dm_exec_cached_plans
cross apply sys.dm_exec_sql_text(plan_handle)
cross apply sys.dm_exec_query_plan(plan_handle)

-- free the cache
dbcc freeproccache

select * from employee

-- Executing dynamic sql using exec keyword
execute('select * from employee ')

-- parameterizing the value in the exec sql statement
declare @statement3 nvarchar(max)
declare @params1 nvarchar(1000)
declare @name2 nvarchar(50)='Steve'
declare @id int=3

set @statement3='select * from employee where Name='+QUOTENAME(@name2)
print @statement3
exec(@statement3)

-- sql table name in dynamic sql
declare @statement4 nvarchar(max)
declare @tablename nvarchar(70)='dice1'
set @statement4='select * from '+QUOTENAME(@tablename)
exec(@statement4)

-- output parameter in dynamic sql
declare @statement5 nvarchar(max)
declare @count int
declare @gender nvarchar(40)='male'
set @statement5='select @count=count(*) from employee where Gender=@gender'
-- output parameter
exec sp_executesql @statement5,N'@gender nvarchar(40),@count int output',@gender=@gender,@count=@count output
select @count

-- calling stored procedure using dynamic sql
create proc spGetEmployeeByGender
@gender nvarchar(40),
@count int output
as
begin
	select @count=count(*) from employee where Gender=@gender
end

declare @count3 int
exec spGetEmployeeByGender 'male',@count3 out
select @count3

declare @statement6 nvarchar(max)
declare @gender4 nvarchar(50)='male'
declare @count5 int

set @statement6='exec spGetEmployeebyGender @gender=@gender4,@count=@count5 out'
exec sp_executesql @statement6,N'@gender4 nvarchar(50),@count5 int output',@gender4=@gender4,@count5=@count5 output
select @count5


-- temp tables in dynamic SQL
declare @statement7 nvarchar(max)

set @statement7='create table #test(id int) insert into #test values (1),(2),(3)'
exec sp_executesql @statement7

set @statement7='select * from #test'
exec sp_executesql @statement7


create table #test (id int)
insert into #test values (1),(23)
declare @statement8 nvarchar(max)='select * from #test'
exec(@statement8)

