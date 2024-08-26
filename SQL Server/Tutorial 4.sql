/*  ------ DAY 4 ---------- */

-- Multi-statement table-valued function
alter function getCustomersOnOrderedDate(@date date)
returns @table Table(customer_id int primary key,order_status int,order_date date,name nvarchar(40))
as
begin
	if @date ='2017-12-02'
		set @date='2017-12-01'
	insert into @table
	select cust.customer_id,ord.order_status,ord.order_date,CONCAT_WS(' ',cust.first_name,cust.last_name) as name from sales.orders as ord
	join sales.customers as cust
	on ord.customer_id=cust.customer_id
	where ord.order_date=@date
	return
end

-- calling the function
select * from getCustomersOnOrderedDate('2017-12-04')

-- Joining multiple tables
select ord.order_id,ord.product_id,ord.quantity,ord.list_price,orders.order_status,orders.order_date,cust.first_name,cust.last_name,cust.email,cust.phone,prod.product_name,prod.model_year,prod.list_price from sales.order_items as ord
join sales.orders as orders
on ord.order_id=orders.order_id
join sales.customers as cust
on orders.customer_id = cust.customer_id
join production.products as prod
on ord.product_id=prod.product_id


-- creating function to encrypt using with encryption
create function getFullDetails(@date int)
returns Table
with encryption
as
return (select ord.order_id,ord.product_id,ord.quantity,ord.list_price,orders.order_status,orders.order_date,cust.first_name,cust.last_name,cust.email,cust.phone,prod.product_name,prod.model_year from sales.order_items as ord
	join sales.orders as orders
	on ord.order_id=orders.order_id
	join sales.customers as cust
	on orders.customer_id = cust.customer_id
	join production.products as prod
	on ord.product_id=prod.product_id
	where model_year=@date
)

-- seeing the declaration of the function
exec sp_helptext getFullDetails

select * from getFullDetails(2017)

-- applying the schema binding option to the function 
alter function getFullDetails(@date int)
returns Table
with encryption,schemabinding
as
return (select ord.order_id,ord.product_id,ord.quantity,ord.list_price,orders.order_status,orders.order_date,cust.first_name,cust.last_name,cust.email,cust.phone,prod.product_name,prod.model_year from sales.order_items as ord
	join sales.orders as orders
	on ord.order_id=orders.order_id
	join sales.customers as cust
	on orders.customer_id = cust.customer_id
	join production.products as prod
	on ord.product_id=prod.product_id
	where model_year=@date
)

/* Temporary Tables */

-- local temporary tables
-- creating local temporary tables
create table #demo_table(ID int primary key, name nvarchar(30) not null, address nvarchar(50))

-- inserting value into temporary tables
insert into #demo_table values (1,'naem1','address1'),(2,'name2','address2'),(3,'name3',null)

-- select clause on temporary tables
select * from #demo_table

-- updating the value inside the temporary tables
update #demo_table set address='address3' where address is null


-- creating temporary procedure
create procedure #newproc
@id int
as
begin
	select * from #demo_table
end

exec #newproc 2


-- global temporary tables
create table ##demo_table(id int, name nvarchar(40), address nvarchar(30))

-- inserting the value into it
insert into ##demo_table values (1,'naem1','address1'),(2,'name2','address2'),(3,'name3',null)

-- select clause
select * from ##demo_table

/* Indexes */

-- creating indexes
create index IX_Order_date
on sales.orders (order_date desc)

select * from sales.orders where order_date='2017-02-10'

-- dropping the index
drop index sales.orders.IX_Order_date

-- listing the index availables in the
exec sp_helpindex 'sales.orders'
