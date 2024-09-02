/* Dapper Tutorial */

exec sp_columns StudentTableType
select * from sales.staffs

select * from sales.staffs as staff
join sales.stores as store
on staff.store_id=store.store_id

select * from sales.stores as store
join sales.staffs as staff
on store.store_id=staff.store_id

select * from production.categories

Select * from getProductsByBrandName('Cruisers Bicycles');
exec spProductByBrand 'Trek'

select * from Branch
select * from student
insert into student values (134,'chahar',3,34)

select * from sales.staffs where staff_id=11

update student set name='Tim' where name='name1'


exec spGetEmployeeByGender 'Female',@count out

declare @count int
exec spGetTotalCustomersFromCity 'Sacramento', @count output
select @count

select * from sales.customers 
declare @count int
exec spGetTotalCustomersFromCity 'Uniondale',@count output
select @count

exec sp_helptext spAddMoreStudent

select * from production.brands
alter procedure getError
as
begin
	raiserror('Not Known Error',16,1)
end

exec getError

select count(*) from Employee where city='Tor'
select * from Department

select * from employee

select top 100 * from production.products
exec sp_columns employee


select * from production.brands

select prod.product_name,prod.category_id,brand.brand_name
from production.brands as brand
right join production.products as prod
on brand.brand_id=prod.brand_id

select *,dense_rank() over(order by salary desc) from empdetails



