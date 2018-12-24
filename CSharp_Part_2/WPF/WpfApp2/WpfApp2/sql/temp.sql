INSERT into Departament(Name) values ('Dep of phil');

select * from Departament;
select * from Employee;

delete from Departament where Name = 'Dep of phil';

UPDATE Employee SET Name = 'John', Departament_ID = 4 WHERE ID = 10;

TRUNCATE TABLE Departament;
TRUNCATE TABLE Employee;