/*  ------ DAY 3 ---------- */

/* Creating Stored procedure with return values */
create procedure spGetTotalProductsByBrandID
@id int
as 
begin
	return (select count(product_id) from production.products where brand_id=@id)
end

-- calling the stored procedure with return values
declare @totalCount int
exec @totalCount= spGetTotalProductsByBrandID 1
select @totalCount

-- using the return values with output parameter
create procedure spBrandFromProducts
@id int,
@brandname varchar(30) out
as 
begin
	select @brandname=brand_name from production.brands where brand_id=@id
	return 10
end

-- executing the stored procedure
declare @brandname varchar(30)
declare @status int
exec @status = spBrandFromProducts '1',@brandname output
select @brandname as Brand_Name,@status as Procedure_Status

/* Schema */

-- creating the schema
create schema userdata;

-- listing the schemas present in the database
select * from sys.schemas;

-- creating table inside the schema
create table userdata.bankdetails(
	id int primary key not null,
	name nvarchar(30),
	bank_name nvarchar(30)
)

-- inserting the data into the schema table
insert into userdata.bankdetails values (1,'name1','BOI')

create procedure userdata.getBankCount
as
begin
	select * from userdata.bankdetails
end
exec getBankCount

drop table userdata.bankdetails;

-- drop the schema
drop schema userdata;

/* String Functions */
-- ASCII Function
select AScii('A') as AscII_Value

-- Char Function
select char(67) as character

-- LTRim function
select LTRIM('            prathamesh     dhande') as trimmed

-- RTrim Function
select '       prathamesh   dhande         '
select RTRIM('       prathamesh   dhande     ') as trimmed_right

-- Lower the characters
select lower('PRATHAMESH') 

-- Uppercase the characters
select upper(lower('PRATHAMESH'))

-- Reverse the character
select reverse('PRATHAMESH')

-- Len Returns the length of the character.
select len('PRATHAMESH')

-- trim function trims from left and right
select trim('       prathamesh   dhande     ')

-- space function
select 'Prathamesh'+space(10)+'dhande'

-- translate function
select translate('prathamesh','a','z')

-- left function
select left('prathamesh',3)

-- right function
select right('prathamesh',4)

-- char index function
select CHARINDEX('a','prathamesh',4)

-- substring function
select SUBSTRING('prathamesh',6,len('prathamesh'))

-- Replicate Function
select replicate('Prathamesh ',5);

-- patindex function
select PATINDEX('%h%','Prathamesh')

-- replace function
select REPLACE('Prathamesh','tha','n')

-- Stuff Function
select STUFF('Prathamesh',3,5,'******')

-- concat function
select concat('Prathamesh','Prashant','Dhande')

-- concat Ws function
select CONCAT_WS(' ','Prathamesh','Prashant','Dhande')

/* Datetime functions */

-- date function to get the system current date and time
select GETDATE();

-- current timestamp system
select CURRENT_TIMESTAMP;

-- sysdatetime function to get the more precision date and time
select SYSDATETIME();

-- sysdatetimeoffset to get the utc time with the offset
select SYSDATETIMEOFFSET();

-- get the utc date
select GETUTCDATE();

-- get the utc date with more precision fraction
select SYSUTCDATETIME();

-- isdate function to check if the given value is a valid date or datetime, or time
select ISDATE('2024-08-13 14:58:01') -- return 1
select ISDATE('2024-08-13 14:58:01.2362550') -- return 0

-- day() returns the day of the month for the given date
select day('2024-08-09 14:58:01')

-- month() returns the month number for the given date
select month(getDate())

-- year() returns the year number for the given date.
select year(getDate())

-- datename() returns the nvarchar() for the part of the date.
select DATENAME(day,getDate())
select DATENAME(weekday,getDate())
select DATEPart(month,getDate())
select DATENAME(year,getDate())

-- datepart returns the integer and works similar to datename
select datepart(month,getDate())
select datepart(weekday,getDate())
select datepart(HOUR,getDate())

-- dateadd to add the number of date to add in a current date
select DATEADD(month,2,getDate())
select DATEADD(day,10,getDate())

-- datediff returns the count of the difference between the given datepart from start date to end date
select DATEDIFF(year,'2003-04-22',GETDATE())
select DATEDIFF(day,'2024-08-10',GETDATE())

/* Conversion datatypes to another datatypes */

-- using cast function
select CAST(GETDATE() as nvarchar) 

-- using convert function
select CONVERT(nvarchar,getDate())

-- passing the style parameter to the convert function.
select CONVERT(nvarchar,getDate(),103); -- used to format the date
 
/* Variable Declaration */

-- declaring the variable
declare @my_name nvarchar(30)='prathamesh',@new_id int=4;
select @my_name,@new_id

-- setting the value
set @my_name='dhande'
select @my_name

/* Looping */

-- printing the tables of 2
declare @table_of int =10,@i int=1
while @i<=10
begin
	print cast(@table_of as nvarchar)+'x'+cast(@i as nvarchar)+' = '+cast((@table_of*@i) as nvarchar)
	set @i=@i+1
end

/* Functions */

-- Scalar functions

-- creating functions
create function SumofNumbers(@start_no int,@end_no int)
returns int
as 
begin
	declare @sum int=0
	while @start_no <=@end_no
	begin
		set @sum=@start_no+@sum;
		set @start_no=@start_no+1
	end
	return @sum
end

-- view the content of the function
sp_helptext 'dbo.SumofNumbers'

-- calling the function
select dbo.SumofNumbers(1,10)

-- droping the function or deleteing the function
drop function dbo.SumofNumbers

-- Inline Table Valued Function
-- Creating function
create function getProductsByBrandName(@brand_name nvarchar(30))
returns table
as
return (select product_id,product_name,brand_id,prod.category_id,category_name,list_price from production.products as prod
join production.categories as cat
on prod.category_id = cat.category_id
where category_name=@brand_name)

-- calling the function
select * from getProductsByBrandName('Electric Bikes')
