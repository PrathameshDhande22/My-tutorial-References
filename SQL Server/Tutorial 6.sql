/* --------- Day 6 ---------- */

/* Pivot Operator */

-- using group by 
SELECT 
    category_name, 
    COUNT(product_id) product_count,
	model_year
FROM 
    production.products p
    JOIN production.categories c 
        ON c.category_id = p.category_id
GROUP BY 
    category_name,model_year;

-- using pivot operator
SELECT * FROM (
    SELECT 
        category_name, 
        product_id,
		model_year
    FROM 
        production.products p
        INNER JOIN production.categories c 
            ON c.category_id = p.category_id
) t
PIVOT(
    COUNT(product_id) 
    FOR category_name IN (
        [Children Bicycles], 
        [Comfort Bicycles], 
        [Cruisers Bicycles], 
        [Cyclocross Bicycles], 
        [Electric Bikes], 
        [Mountain Bikes], 
        [Road Bikes])
) AS pivot_table;

/* Error handling */

-- checking the error in the statements
insert into Student values (433,'name5',6,43)
if(@@ERROR <>0)
	print 'Error occured'
else
	print 'Successful'

/* Transaction */

begin transaction
insert into Student values (77,'student1',2,45)
commit transaction

select * from StudentLog
select * from Student

-- transaction in the stored procedure
alter procedure spChecktheValue
@id int
as
begin
	begin try
		begin transaction
			if(@id=0)
				begin
				-- raising the error
					raiserror('id with 0 is incompatible',16,1)
					return
				end
			insert into sampletable(id,name,rollno) values (@id,'name',@id+23)
			commit transaction
			print 'transaction is commited'
	end try
	begin catch
		rollback transaction
		print 'transaction is rollback'
		select ERROR_MESSAGE(),ERROR_LINE(),ERROR_PROCEDURE()
	end catch
end

-- executing the stored procedure
exec spChecktheValue 0
select * from sampletable

/* Subquery */

-- getting the month that has the large orders
select * from vw_TotalOrderPerMonthPerYear
where Total_Orders =(select max(Total_Orders) from vw_TotalOrderPerMonthPerYear)

create view vw_TotalOrderPerMonthPerYear
as
	(select count(order_id) Total_orders,datename(month,order_date) [month],datename(year,order_date) [year] from sales.orders
	group by datename(month,order_date),datename(year,order_date))

-- correlated subquery
select product_id,product_name,model_year,list_price,(select sum(quantity) from production.stocks where product_id=prod.product_id) quantity from production.products as prod

-- getting the products whose price is greater than the average price
select product_id,product_name,category_id,model_year,list_price
from production.products as prod
where list_price > (select avg(list_price) from production.products as prod1 where prod1.category_id=prod.category_id)
