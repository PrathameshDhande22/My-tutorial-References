/*  --------- DAY 1 ---------- */

-- Creating the database
create database sampleDB;

-- altering or changing the database name or rename the database
alter database sampleDB modify name= NewlyCreatedDB;

-- using the System Stored Procedure to rename the Database
Execute sp_renamedb sampleDB,NewlyCreatedDB;

-- to list the databases present in the connection.
select name from sys.databases;

-- or you can use the system stored procedure to execute these
execute sp_databases;

-- delete or drop a databases;
drop database NewlyCreatedDb;

-- using the newly created database;
use sampleDB;

-- setting the database to single user mode
alter database sampleDB set Single_user with rollback immediate;

-- creating a table
create table Student(
	-- adding the primary key to one field
	id int not null primary key,
	name nvarchar(30) not null,
	branchid int not null
)

-- creating another table
create table Branch(
	id int not null primary key,
	branchname nvarchar(10) not null
)

-- Adding the foreign key to the table of student
alter table student add constraint Student_branchid_FK
foreign key(branchid) references Branch(id);

-- adding the foreign key while creating table but need to create the constraint.
create table Employee(id int primary key not null,branchid int not null,
foreign key(branchid) references branch(id));

-- inserting a data into a table
insert into branch(id,branchname) values (1,'Comp');

-- inserting a multiple data into a table
insert into branch(id,branchname) values (2,'Extc'),(3,'Mech');

-- select statement
select * from branch;

-- alter a constraint adding a default constraint
alter table Student add constraint DF_Student_branchid default 1 for branchid;

insert into Student(id,name) values(193,'John');
select * from student;

-- adding the column in the table using alter query
alter table student add rollno int null constraint DF_student_rollno default 0 ;

insert into student(id,name,branchid) values (198,'name',3);
select * from student;

-- drop the constraint 
alter table student
drop constraint DF_student_rollno;

-- adding the constraint while creating the table
create table sampletable(
	id int Constraint PK_sampletable_id Primary key not null,
	name nvarchar(30),
	rollno int constraint DF_sampletable_rollno Default 10
)

-- listing the tables present in the databases
select * from sys.tables;

-- listing the columns present in the tables by passing the table name.
exec sp_columns 'Branch';

-- listing the default constriants present in the tables of the selected databases
select * from sys.default_constraints;


-- adding the referential integrity to the columns
alter table student add constraint Student_branchid_FK
foreign key(branchid) references Branch(id) on delete set null;

delete from branch where id=3;

-- check constraint
alter table student add constraint ck_student_age check(age>0 and age<150)

insert into student(id,name,branchid) values(192,'prakash',1);
select * from student

-- identity constraint -> creating the column with identity constraint
create table sampletable1(
	id int identity(10,1) primary key not null,
	name nvarchar(30) not null
);

-- inserting the data into the sampletable
insert into sampletable values (1,'name1'); -- throws error we cannot directly insert the value into the database whose column is identity.
insert into sampletable1(name) values ('name2');
select * from dbo.sampletable1;

select SCOPE_IDENTITY()
select @@IDENTITY