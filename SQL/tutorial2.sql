# This is the Intermediate Tutorial Containing 
# Join, Math Function, String Function, Subquery, Date Function, If Expression

# join Tutorial

-- simple join query
SELECT 
    ex.id, ex.name, rt.id, rt.jobdetail
FROM
    example AS ex
        JOIN
    referencetable AS rt ON rt.id = ex.id;
    
-- inner join
select ex.id,ex.name,rt.id,rt.jobdetail from example as ex
inner join referencetable as rt
on rt.id=ex.id;

-- left join
select ex.id,ex.name,rt.id,rt.jobdetail from example as ex
left join referencetable as rt
on rt.id=ex.id;

-- right join
select ex.id,ex.name,rt.id,rt.jobdetail from referencetable as rt
right join example as ex
on ex.id=rt.id;

-- full outer join
select ex.id,ex.name,rt.id,rt.jobdetail from example as ex
left join referencetable as rt
on rt.id=ex.id
union
select ex.id,ex.name,rt.id,rt.jobdetail from referencetable as rt
right join example as ex
on ex.id=rt.id;

-- cross join
insert into referencetable(id,jobdetail) value(3,"Java");
select ex.id,ex.name,rt.id,rt.jobdetail from example as ex
cross join referencetable as rt;

-- date function tutorial

-- to get the current date
select now();

-- to set the date
select date("2022/12/02");

-- to get the date from the now function
select date(now());

-- formatting the date
select date_format(date(now()),"%M %D %Y") as Current;

-- getting the date difference
select datediff("2022-03-10","2022-03-4") as Difference;

-- getting the current date
select current_date();

-- to add the number of days in the date
select date_add("2021-04-02",interval 10 day);

-- you can also add the month week too
select date_add("2021-04-01",interval 1 month);


# String Function 

-- concatenation concat()
select concat("1st String","2nd String","3rd String");

-- concatenation using separator
select concat_ws("|","1st String","2nd String","3rd String") as Concat;

-- length of the string
select length("Prathamesh");

-- char length
select char_length("PrathameshJ");

-- reverse of the string
select reverse("Prathamesh") as reveresed;

-- replace of the string
select replace("Prathamesh is a boy","boy","Young");

-- triming the string
select ltrim("   Prathamesh   " );

-- trim all the string
select trim("    prathamesh  ");

-- position of the string
select position("mesh" in "Prathamesh is boy");

-- getting the ascii value of the given char
select ascii("A");

# Math Functions

SELECT 
    ABS(- 34.2299993493) Absolute_value,
    CEIL(34.923) Ceil,
    FLOOR(32.923) Floor,
    MOD(5, 10) MOD_value,
    ROUND(34.23232, 2) Round_Off_Value,
    POW(2, 3) Power_Value,
    SQRT(2) Square_Root_Value,
    ROUND(RAND(), 2) * 100 Random_Value;
 
-- for more math function refer to mysql documentation


# Subquery Tutorial
select * from employee;

-- subquery with select statement
select Salary,Empfname,empcode from employee
where salary =(select min(salary) from employee);

-- subquery with insert statement
insert into example(id,name)
select empcode,concat_ws(" ",empfname,emplname) from employee
where salary = (select max(salary) from employee);

-- lets see the effect
select * from example;

-- subquery with update statement
update example set id=5 
where id=(select empcode from employee where 
salary=(select max(salary) from employee));

-- subquery with delete statement
delete from example
where id=(select max(id) from referencetable);

-- if expression
select * from employee;
SELECT 
    empcode,
    CONCAT_WS(' ', empfname, emplname) AS Name,
    job,
    IF(commission = 0, 'True', 'False') AS Takes_Commission
FROM
    employee;