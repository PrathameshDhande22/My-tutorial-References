/*  ------ DAY 2 ---------- */

/* to retreive the last generated identity value */
-- using Select_IDENTITY function
select SCOPE_IDENTITY();

-- using global @@IDENTITY variable
select @@IDENTITY;

-- using IDENT_CURRENT function to get the last generated value for the given tablename.
select IDENT_CURRENT('sampletable');

/* Unique key constraint */

-- adding unique key while creating table
create table uniqueTable(
	id int primary key not null,
	name nvarchar(30) unique,
)

-- adding unique key using alter statement
alter table sampletable
add constraint UQ_sampletable_name Unique(name);

insert into sampletable(id,name,rollno) values (4,'name1',1);
select * from sampletable;

/* Select Statement */

-- select statement
select * from sampletable;

-- select statement to show only specific columns
select id,name from sampletable;

-- select only distinct row from the table
select distinct name from student;

-- Select statement to apply some condition
select * from student where id=193;

-- Where condition with not equal to operator
select * from student where id<>192;

-- in operator
use BikeStores;
select * from production.products; 
select * from production.products where product_id in (1,2,3); -- displaying only the records which are required.

-- between operator
select distinct model_year from production.products;
select * from production.products where brand_id between 1 and 3; -- displaying the records which are between the range including the range too.

-- like Operator
select * from sales.customers;
select * from sales.customers where first_name like 'L%'; -- displaying only the rows which starts with L but any character

-- not operator
select * from production.products where brand_id not in (1,2,3) -- displaying only the rows which doesn't contain the brands given in the list.

-- wildcard operators
select * from sales.customers where first_name like '_nn%';  -- _ matches only one character

select * from sales.customers where first_name like 'L[a-z]'; -- matches based on brackets

-- And and or Operators
select * from production.categories;
select * from production.categories where category_name ='Road Bikes' or category_name='Electric Bikes'; -- usage of or Operator

select * from production.categories where category_name ='Road Bikes' or category_name='Electric Bikes' and category_id=5;

/* Order by statement */

select * from sales.customers;
-- sorting the first name in ascending order
select * from sales.customers order by first_name asc;
-- sorting in descending order
select * from sales.customers order by first_name desc, state asc;

/* Top Records */
-- using number
select top 3 * from sales.customers;

-- using percent
select top 10 percent * from sales.customers;

select * from production.stocks;
-- displaying the top stocks which are available
select top 2 * from production.stocks order by quantity desc;

/* Offset and fetching the rows */
select * from production.products order by model_year desc offset 2 rows fetch next 3 rows only;

/* Group by Clause */
-- using aggregate function using group by clause
select * from sales.order_items;
select Sum(list_price) from sales.order_items;
-- column alias
select order_id, min(list_price)as [Minimum Price],sum(list_price),max(list_price) from sales.order_items group by order_id;

-- multiple grouping
select state,city,count(customer_id) from sales.customers group by city,state;

/* Having Clause */
select state,city,count(customer_id) from sales.customers group by city,state having state='TX';


/* JOINS */

-- inner join
select product_id,product_name,model_year,cat.category_name from production.products as prod 
inner join production.categories as cat
on prod.category_id=cat.category_id;

-- cross joins
select * from sales.staffs;
select * from sales.stores;
select first_name,last_name,store_name,state from sales.stores cross join sales.staffs;

-- self join
use sampleDB;
select * from Student;
-- can be used to find the duplicates data but different id.
select s1.id, s1.age,s2.name,s2.id,s1.name from student as s1
join student as s2
on s1.name=s2.name and s1.id<>s2.id;


/* ISNULL Function */
select id,name,isnull(age,0) from student;

/* COALESCE function */
select id,name, coalesce(age,0) from student;
select coalesce(null,null,null,'Prathamesh') as Name;

/* CASE Statement */
select id,name,case when age is null then 0 else age end from student;

/* Union & Union all */

select id,name from student
union 
select id,branchname from Branch;

/* Stored Procedures */

-- creating the procedures
create procedure spGetProductsbyBrand
	-- procedures with parameters
@brandname nvarchar(30)
as 
begin
	select * from production.products as prod join production.brands as br
	on prod.brand_id=br.brand_id
	where br.brand_name=@brandname;
end

select * from production.brands;
-- executing the stored procedures
spGetProductsbyBrand 'Pure Cycles';

-- another method for executing the stored procedure
exec spGetProductsbyBrand 'Trek';

-- altering the procedure
alter procedure spGetProductsbyBrand
@brandname nvarchar(30)
as 
begin
	select * from production.products as prod join production.brands as br
	on prod.brand_id=br.brand_id
	where br.brand_name=@brandname and prod.model_year!=2016
end

-- dropping the procedure
drop procedure spGetProductsbyBrand;

-- creating stored procedure with output parameters
create procedure spGetTotalCustomersFromCity
@cityname nvarchar(30),
@totalcustomers int output  -- declaring the output parameter
as
begin
	select @totalcustomers = count(customer_id) from sales.customers group by city having city=@cityname;
end

-- executing the stored procedure with output parameter
declare @customers int -- declaring the variable to store the output result from the stored Procedure
exec spGetTotalCustomersFromCity 'New York',@customers out;
print @customers -- printing the result of the output parameter
select @customers;

-- executing the stored procedure with named parameter
declare @count_cust int
exec spGetTotalCustomersFromCity @totalcustomers=@count_cust output ,@cityname = 'Long Beach';
select @count_cust;

-- to view the content of the stored procedure
exec sp_helptext spGetTotalCustomersFromCity

-- to encrypt the stored procedure such that you cannot view it using sp_helptext system stored procedure
alter procedure spGetTotalCustomersFromCity
@cityname nvarchar(30),
@totalcustomers int output  -- declaring the output parameter
with encryption
as
begin
	select @totalcustomers = count(customer_id) from sales.customers group by city having city=@cityname;
end

-- to get the view about the dataypes and parameters used in the stored procedure or any tables.
sp_help spGetTotalCustomersFromCity

