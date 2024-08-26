/* ----------- Day 5 ------------ */

/* Unique and Non-Unique Indexes */
create table newtable(
	id int primary key not null, -- by default unique clustered index
	name nvarchar(30) not null,
	city nvarchar(5) not null constraint UQ_newTable_city unique, -- by default unique non-clustered index.
)

insert into newtable values (1,'name1','boi'),(2,'name2','boi1')

select * from newtable where city='boi'

-- creating unique nonclustered index
create unique nonclustered index UIX_newtable_name
on newtable (name)

-- droping the index
drop index newtable.UIX_newtable_name

-- space used by table using system stored procedure.
exec sp_spaceused newtable

/* Views */

-- creating views
create view vwTotalProductsByStores
as
select count(ord.order_id) as total_orders,ord.store_id,stores.store_name from sales.orders as ord
join sales.stores as stores
on ord.store_id=stores.store_id
group by ord.store_id,stores.store_name

-- select clause on view
select * from vwTotalProductsByStores;

-- altering the view
alter view vwTotalProductsByStores
as
select count(ord.order_id) as total_order,ord.store_id,stores.store_name from sales.orders as ord
join sales.stores as stores
on ord.store_id=stores.store_id
group by ord.store_id,stores.store_name

-- dropping the views
drop view vwTotalProductsByStores

-- listing the views
select * from sys.views

-- listing the columns in views
exec sp_columns vwTotalProductsBystores

/* Triggers */

create table StudentLog(
	id int,
	message nvarchar(50)
)

-- creating the triggers
create trigger tg_AddInStudentLog
on Student
for insert
as
begin
	declare @id int
	select @id = id from inserted
	insert into StudentLog values (@id,'Student with id = '+cast(@id as nvarchar)+' is inserted')
end

-- triggering the triggers
insert into Student values (185,'name3',2,34),(123,'deepak1',1,45)

select * from Student
select * from StudentLog

create trigger tg_viewoninsert
on Student
for insert
as
begin
	select * from inserted
end

-- dropping the triggers
drop trigger tg_viewoninsert


/* Table Variable */

-- declaring the table
declare @table_variable table(id int,name nvarchar(50))

-- inserting the data into the table variable
insert into @table_variable values (1,'name1'),(2,'name2'),(3,'name3')

-- select clause on table variable
select * from @table_variable

/* Derived Tables */

select * from (
	select count(prod.product_id) as Total_Products,brand.brand_name from production.products as prod
	join production.brands as brand
	on prod.brand_id = brand.brand_id
	group by brand.brand_id,brand.brand_name
) as Total_Products_By_brand
where Total_Products >100

/* CTE */

with Total_Products_By_Brand as (
	select count(prod.product_id) as Total_Products,brand.brand_name from production.products as prod
	join production.brands as brand
	on prod.brand_id = brand.brand_id
	group by brand.brand_id,brand.brand_name
)

select * from Total_Products_By_Brand where Total_Products>6 and not Total_Products>100

select * from Total_Products_By_Brand

-- multiple CTE's
with Total_Products_By_Brand as (
	select count(prod.product_id) as Total_Products,brand.brand_name from production.products as prod
	join production.brands as brand
	on prod.brand_id = brand.brand_id
	group by brand.brand_id,brand.brand_name
),Total_Products_By_Category as (
	select count(prod.product_id) as Total_Products,cat.category_name from production.products as prod
	join production.categories as cat
	on prod.category_id=cat.category_id
	group by cat.category_id,cat.category_name
)

select * from Total_Products_By_Brand
union
select * from Total_Products_By_Category




