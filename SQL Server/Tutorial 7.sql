/* ------------ Day 7 ------------- */

/* Cursors */

declare @productName nvarchar(80)
declare @productID int

-- declaring the cursor
declare ProductCursor Cursor for
select Top 10 product_id,product_name from production.products
join production.brands as brand
on brand.brand_id=production.products.brand_id

-- open a cursor
open productCursor

-- fetching the next rows of the cursor
fetch next from productCursor into @productID,@productName

while(@@FETCH_STATUS = 0)
begin
	fetch next from productCursor into @productID,@productName
	print cast(@productID as nvarchar)+' '+@productName
end

-- closing a cursor
close productCursor

-- deallocating the cursor
deallocate productCursor

/* Listing all tables, view, functions, procedures */

-- listing all tables
select * from sys.tables
select * from sysobjects where xtype='u'
select * from INFORMATION_SCHEMA.TABLES

-- listing all stored procedures
select * from sys.procedures
select * from sysobjects where xtype='p'
select * from INFORMATION_SCHEMA.ROUTINES

/* Change column datatype without dropping the tables */

alter table newtable
alter column empid nvarchar(40)

/* Optional Parameters in Stored Procedure */

create proc spProductByBrand
-- default parameter
@brand_name nvarchar(50) = null
as
begin
	select * from production.products as prod
	join production.brands as brand
	on prod.brand_id=brand.brand_id
	where brand.brand_name=@brand_name  or @brand_name is null
end

-- executing the stored procedure
execute spProductByBrand
execute spProductByBrand 'Trek'

/* Deadlock analysis */
-- read the error log 
execute sp_readerrorlog

/* Except Operator */
select * from dice1
select * from dice2

-- except operator example
select * from dice1
except
select * from dice2