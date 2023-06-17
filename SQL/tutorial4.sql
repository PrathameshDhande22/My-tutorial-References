# This is Expert Mysql Tutorial

-- Stored Function
-- Syntax
delimiter $$
create function commisionwala(name varchar(30))
returns varchar(30)
deterministic
begin
declare comm int default 0;
select commission into comm from employee where EmpFName=name;

if comm=0 then 
	return "Honest";
elseif comm<=100 and comm>0 then
	return "Wants To Earn";
elseif comm<=500 and comm>=101 then
	return "Hungry";
else
	return "Not Best";
end if;
end $$
delimiter ;

-- calling the function
SELECT 
    EmpCode, EmpFName, Job, COMMISIONWALA(empfname) AS earn
FROM
    employee
ORDER BY earns;

-- dropping the function
drop function commisionwala;

-- listing the function
show function status where db=database();

-- Error Handling in stored procedure
insert into referencetable value (8,"C#"); -- error occured in this statement
-- lets handle this error in stored procedure

delimiter $$
create procedure handleerror(id int,jobdetail varchar(20))
begin
-- error should be handle in the before only
declare continue handler for 1452
	begin
		insert into example value(id,current_user());
		insert into referencetable value(id,jobdetail);
	end;

-- multiple handler    
declare exit handler for 1062
	begin
		select "Donot insert the same id";
	end;
    
insert into referencetable value(id,jobdetail);
end $$
delimiter ;

call handleerror(7,"C#");
drop procedure handleerror;
select * from example;
select * from referencetable;

alter table referencetable
modify id int primary key;

-- raising the error 
delimiter $$
create procedure insertdata(in age int)
begin
if age <18 then
	-- raising the error using signal statement
	signal sqlstate '13000' set message_text="Cannot be inserted";
else
	select age as inserted;
end if;
end $$
delimiter ;

drop procedure insertdata;
call insertdata(15);

-- view Tutorial
-- creating the view
create view tableview
as 
select * from employee where job="Manager";

-- viewing the view
select * from tableview;

-- listing the view
show tables where tables_in_tutorial like "%view%";
-- alternate method
show full tables where table_type="VIEW";

-- droping the view
drop view tableview;

-- You can use the same statement of alter, delete , create or replace, update statement as just using with simple table;alter

# Window Function Tutorial
select distinct sum(salary) over(partition by deptcode) as ts from employee;

select row_number() over(order by empcode),EmpCode from employee;

-- for more window function refer to mysql documentation

-- analyzing the table
analyze table employee;

optimize table employee;

check table employee;

repair table employee;

-- regexp tutorial
select * from employee;
select EmpFName from employee where EmpFName regexp '^R|y$';