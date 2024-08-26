-- identity question if the insert statement is failed then it insert which values when later inserted.
create database tutorial;

create table employee(
	id int primary key not null identity(10,1),
	name nvarchar(40) not null,
)

use tutorial;
use sampleDB;
select * from sys.databases;
select * from sys.tables;
drop table employee;
insert into employee(name) values ('name4');
select * from employee;
delete from employee;

/* 21 Aug 2024 */
-- create view in view.
alter view vw_NestedView
as
select * from dbo.vwTotalProductsByStores

select * from vw_NestedView

drop view dbo.vw_TotalOrderPerMonthPerYear

-- calling stored procedure in view => failed
create view vw_SPView
as
exec spGetTotalProductsByBrandID 1

-- calling function inside the view
alter view vw_FnView
as
select * from [dbo].[getProductsByBrandName]('Mountain Bikes')

select * from vw_FnView
