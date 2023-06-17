# This is mysql Advance Tutorial

# Trigger Tutorial

select * from employee;
select * from department;

-- lets add the age column in the employee table
alter table employee
add column age int not null;

-- lets learn the limit and offset keyword
-- limit return only given number of rows
select * from employee limit 4;

-- offset return the rows excluding the first to given number
select * from employee limit 1,4;

-- alternate syntax
select * from employee limit 4 offset 1;

-- lets create before insert trigger
-- trigger are of before insert, before update, before delete, after update,after insert, after delete

delimiter $$
create trigger ageverify
before insert 
on employee for each row
begin
if new.age<18 then set new.age=0;
end if;
end $$
delimiter ;

-- to view the triggers
show triggers;

-- lets insert the value with age below to 18
describe employee;
insert into employee values
(1223,"STEVE","BORN","SALESMAN","4503","1880-2-3",1000,0,10,16);

select * from employee;

-- to drop the trigger
drop trigger ageverify;

select * from employee;

-- lets create the before delete trigger
CREATE TABLE backuptable (
    id INT,
    name VARCHAR(40)
);

delimiter $$
create trigger addtables
before delete
on example for each row
begin
insert into backuptable value (old.id,old.name);
end $$
delimiter ;

-- lets delete one value
delete from example where id=5;

-- lets view the example table and backuptable
select * from example;
select * from backuptable;

-- this is how trigger works

# Control Flow Tutorial
-- if expression we have seen

-- ifnull
select ifnull(null,"Prathamesh");
select ifnull("Prathamesh",null);
select ifnull("Prathamesh","Dhande");

-- nullif
select nullif(null,"Prathamesh");
select nullif("Prathamesh",null);
select nullif("Prathamesh",'prathamesh');

-- case statement
SELECT 
    CASE 1
        WHEN 1 THEN 'One'
        WHEN 2 THEN 'Two'
        ELSE 'More'
    END AS caseStatement;

SELECT 
    empcode,
    EmpFName,
    CASE deptcode
        WHEN 10 THEN 'Finance'
        WHEN 20 THEN 'Software'
        WHEN 30 THEN 'Sales'
        WHEN 40 THEN 'Marketing'
        ELSE 'Admin'
    END AS department
FROM
    employee
ORDER BY department;

# Stored Procedure
-- Syntax:
delimiter $$
create procedure getbySalary()
begin
select * from employee group by deptcode order by deptcode;
end $$
delimiter ;

-- calling the procedure
call getbySalary();

-- listing the procedure
show procedure status where db=database();

-- droping the procedure
drop procedure getbySalary;

-- procedure with arguments out parameter
delimiter $$
create procedure getTotalsalary(out totalsalary int)
begin
select sum(salary) into totalsalary from employee;
end $$
delimiter ;

-- calling the procedure
call gettotalsalary(@st);
select @st as Total_Salary;

-- procedure with in parameters
delimiter $$
create procedure getSalarybyjob(in jobtype varchar(20),out totalSalary int)
begin
select sum(salary) into totalSalary from employee where job=jobtype;
end $$
delimiter ;

-- calling the procedure with in and out parameter
call getSalarybyjob("software engineer",@jt);
SELECT @jt;

-- declaring variable in stored procedure
delimiter $$
create procedure variableproc()
begin
-- declaring the variable
declare total int default 0;

-- assigning the value to the variable
set total=100;

select count(*) into total from employee;

-- calling the variable
select total;

end $$
delimiter ;

call variableproc();

select * from employee;

-- usage of control flow statements in stored procedure
delimiter $$
create procedure wantsotincreased(in name varchar(30),out increasedby int)
begin

declare salarypro int default 0;

SELECT 
    salary
INTO salarypro FROM
    employee
WHERE
    empfname = name;

if salarypro<=1000 and salarypro>=0 then 
	set increasedby=1000;
elseif salarypro<=2000 and salarypro>=1001 then
	set increasedby=500;
else 
	set increasedby=100;
end if;

end $$
delimiter ;

select * from employee;
call wantsotincreased("tim",@inc);
select @inc;

-- looping in stored procedure
-- three types of loop while loop, repeat loop, simple loop
-- do while loop
delimiter $$
create procedure loopcounter()
begin 
declare i int default 0;
declare con varchar(255) default "";
-- do while loop
runloop:while i<=10 do
-- just like break statement in programming language 
if i=8 then leave runloop;
end if;

set con=concat_ws(",",con,i);
set i=i+1;
end while;

SELECT con;
end $$
delimiter ;

call loopcounter();