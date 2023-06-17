# This is the Basic Tutorial of the MySQL

-- database Creation query
create database tutorial;

-- to use the database query
use tutorial;

-- To list the tables under the database
show tables;

-- show databases;
show databases;

-- Create table command query
 CREATE TABLE Example (
    id INT,
    name VARCHAR(30)
);
 
-- to view the data in the table query
select * from example;

-- inserting the data into the table
insert into example values (1,"Prathamesh"),(2,"John"),(3,"Steve"),(4,"Sahil");

-- to view the logical view of the table
describe example;

-- constraints in sql while creating table
create table example1(
name varchar(20) not null, -- not null constraint
rollno int primary key auto_increment, -- auto increment constraint and primary key constraint
isTrans bool default False, -- default constraint
transid int not null unique, -- unique constraint
age int not null check(age<=15) -- check constraint
);

-- to view the logical view of the created table
describe example1;

-- Datatypes in sql
create table datatypes(
id int, -- integer datatype
bigid bigint, -- biginteger datatype
result float, -- float datatype
decimaltype decimal, -- decimal datatype
name varchar(10), -- varchar datatype
isMarried char, -- char datatype
isTrans bool, -- boolean datatype
gender enum("Male","Female","other"), -- enum datatype
todayis datetime, -- datetime datatype
address json -- json datatype
);

-- let look at the logical view of the table datatypes
describe datatypes;

-- lets insert the data in the datatypes table
-- to insert the json datatype you must include it in the '{datas}' 
 insert into datatypes values (1,2992,3.2,50.0,"Prathamesh","N",False,"Male",now(),'{"city":"Boisar","Pincode":401502}'),(1,2992,3.2,50.0,"John","Y",True,"Female",now(),'{"city":"tarapur","Pincode":401504}');
 
 -- lets view the data in the datatypes
 select * from datatypes;
 
 -- to get particular column selected to view query is
 select id,bigid,result,name,isMarried,isTrans,gender,date(todayis),address->>"$.city",address->>"$.Pincode" from datatypes;
 
 -- foreign key constraint
 -- suppose if you forget too give the primary key to one of its column you can add it using the alter command
alter table example add primary key(id);

-- lets create another table which will take reference from it
CREATE TABLE referenceTable (
    id INT,
    job VARCHAR(20) NOT NULL
);

-- which means when ever the parent column is deleted it also gets deleted
alter table referenceTable add Foreign key(id) references example(id) on delete cascade;

-- lets view the logical view
describe referenceTable;

-- adds the data in parent table
insert into example values (1,"Prathamesh"),(2,"sushant"),(3,"john"),(4,"Kepler");

-- adds the data in referenced table
insert into referenceTable values (1,"React"),(2,"C++"),(2,"C");

-- lets view the tables
select * from referencetable;
select * from example;

-- consider we want to insert multiple json data in datatypes table
 insert into datatypes values (1,2992,3.2,50.0,"Prathamesh","N",False,"Male",now(),'{"city":"Boisar","Pincode":401502,"Parcel":{"city":"tarapur"}}'),(1,2992,3.2,50.0,"John","Y",True,"Female",now(),'{"city":"tarapur","Pincode":401504,"Parcel":{"city":"Palgar"}}');
 
 -- lets view the mutiple json data
select address from datatypes;
select address->>"$.Parcel.city" from datatypes;

-- using alter command you can add the column in the table
alter table example1 add column birth_date date not null;

-- lets see the column has been added or not
describe example1;

-- suppose you want to rename the column name of the table you do using rename command
alter table referencetable rename column job to jobdetail;

-- lets see the column name is changed
select * from referencetable;

-- truncate command it can used to delete the whole data of the table 
truncate table example1;

-- drop command
-- drop command can be used to delete column
alter table datatypes drop column address;

-- drop command can be used to delete table
drop table datatypes;

-- drop command can be used to delete database
create database ex;
drop database ex;

-- modify command can be used to modify any datatype of a column
alter table example1 modify isTrans enum("Y","N");

-- update command is used to update the data of the column
update referencetable set id=3 where jobdetail="C";

-- lets see the affect
select * from referencetable;

-- delete command is used to delete the data from the table
delete from referencetable where id=3;

-- delete command to delete all rows or you can say all data;
delete from example1;

-- some examples
CREATE TABLE DEPARTMENT (
    DEPTCODE INT PRIMARY KEY,
    DeptName CHAR(30),
    LOCATION VARCHAR(33)
);

CREATE TABLE EMPLOYEE (
    EmpCode INT PRIMARY KEY,
    EmpFName VARCHAR(15),
    EmpLName VARCHAR(15),
    Job VARCHAR(45),
    Manager CHAR(4),
    HireDate DATE,
    Salary INT,
    Commission INT,
    DEPTCODE INT,
    FOREIGN KEY (DEPTCODE)
        REFERENCES department (deptcode)
);

INSERT INTO DEPARTMENT VALUES (10, 'FINANCE', 'EDINBURGH'),
                              (20,'SOFTWARE','PADDINGTON'),
                              (30, 'SALES', 'MAIDSTONE'),
                              (40,'MARKETING', 'DARLINGTON'),
                              (50,'ADMIN', 'BIRMINGHAM');
                       
INSERT INTO EMPLOYEE  
VALUES (9369, 'TONY', 'STARK', 'SOFTWARE ENGINEER', 7902, '1980-12-17', 2800,0,20),
       (9499, 'TIM', 'ADOLF', 'SALESMAN', 7698, '1981-02-20', 1600, 300,30),    
       (9566, 'KIM', 'JARVIS', 'MANAGER', 7839, '1981-04-02', 3570,0,20),
       (9654, 'SAM', 'MILES', 'SALESMAN', 7698, '1981-09-28', 1250, 1400, 30),
       (9782, 'KEVIN', 'HILL', 'MANAGER', 7839, '1981-06-09', 2940,0,10),
       (9788, 'CONNIE', 'SMITH', 'ANALYST', 7566, '1982-12-09', 3000,0,20),
       (9839, 'ALFRED', 'KINSLEY', 'PRESIDENT', 7566, '1981-11-17', 5000,0, 10),
       (9844, 'PAUL', 'TIMOTHY', 'SALESMAN', 7698, '1981-09-08', 1500,0,30),
       (9876, 'JOHN', 'ASGHAR', 'SOFTWARE ENGINEER', 7788, '1983-01-12',3100,0,20),
       (9900, 'ROSE', 'SUMMERS', 'TECHNICAL LEAD', 7698, '1981-12-03', 2950,0, 20),
       (9902, 'ANDREW', 'FAULKNER', 'ANAYLYST', 7566, '1981-12-03', 3000,0, 10),
       (9934, 'KAREN', 'MATTHEWS', 'SOFTWARE ENGINEER', 7782, '1982-01-23', 3300,0,20),
       (9591, 'WENDY', 'SHAWN', 'SALESMAN', 7698, '1981-02-22', 500,0,30),
       (9698, 'BELLA', 'SWAN', 'MANAGER', 7839, '1981-05-01', 3420, 0,30),
       (9777, 'MADII', 'HIMBURY', 'ANALYST', 7839, '1981-05-01', 2000, 200, NULL),
       (9860, 'ATHENA', 'WILSON', 'ANALYST', 7839, '1992-06-21', 7000, 100, 50),
       (9861, 'JENNIFER', 'HUETTE', 'ANALYST', 7839, '1996-07-01', 5000, 100, 50);

select * from department;
select * from employee;

-- logical operators
-- AND operator
select * from employee where job="Analyst" and Commission<=100;

-- OR operator
select * from employee where Job="Salesman" or job="Manager";

-- NOT operator
select * from employee where Commission!=0;

-- mysql supports all type of the comparison operator

-- special operator
-- Between operator
select * from employee where Salary between 1000 and 2000;

-- IN operator
select * from employee where salary in (1000,2000,3000);

-- like operator
select * from employee where EmpFName like "rose";

-- is Null operator
select * from employee where DEPTCODE is null;

-- distinct operator
select distinct job from employee;

-- string matching
-- wildcard matching % is used to match string of two or more characters
select * from employee where empfname like "%a%";

-- escape character _ is used to match string of one character only
select * from employee where empfname like "S_M";

-- variable making in sql
# declaring variable using set @variablename=value
set @var=date(now());
# viewing the data inside the variable using Select @variablename;
select @var Today_date;

-- Aggregations to be used with groupby clause only
SELECT DISTINCT
    job,
    SUM(salary),
    MIN(salary),
    MAX(salary),
    COUNT(job),
    AVG(commission)
FROM
    employee
GROUP BY job;

-- order by clause
SELECT DISTINCT
    job,
    SUM(salary) AS Total_Salary,
    MIN(salary) AS Minimum_Salary,
    MAX(salary) AS Maximum_Salary,
    COUNT(job) AS Total_Employee,
    AVG(commission) Average_commission
FROM
    employee
GROUP BY job
ORDER BY job DESC;

-- having clause
SELECT DISTINCT
    job,
    SUM(salary) AS Total_Salary,
    MIN(salary) AS Minimum_Salary,
    MAX(salary) AS Maximum_Salary,
    COUNT(job) AS Total_Employee,
    AVG(commission) Average_commission
FROM
    employee
GROUP BY job
HAVING SUM(salary) < 3000
ORDER BY job DESC;

-- another example of having clause
SELECT DISTINCT
    job,
    SUM(salary) AS Total_Salary,
    MIN(salary) AS Minimum_Salary,
    MAX(salary) AS Maximum_Salary,
    COUNT(job) AS Total_Employee,
    AVG(commission) Average_commission
FROM
    employee
GROUP BY job
HAVING COUNT(job) >= 3
ORDER BY job DESC;

-- union command
-- to use union command the column should be of same datatype and using union it returns the unique data only
select empcode from employee
union
select deptcode from department;

-- to get duplicate data as well instead of union use union all
select empcode from employee
union all
select deptcode from department;

