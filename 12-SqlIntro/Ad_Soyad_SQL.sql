create database Company;
use Company;

create table Employees (
  EmployeeID int,
  FirstName nvarchar(20),
  LastName nvarchar(20),
  Email varchar(40),
  PhoneNumber varchar(40),
  HireDate date,
  JobTitle nvarchar(40),
  Salary money,
  Department nvarchar(40)
)

INSERT INTO Employees
VALUES 
(1, 'Ali', 'Huseynov', 'ali.h@gmail.com', '0501234567', '2023-01-10', 'Developer', 1500.00, 'IT'),
(2, 'Leyla', 'Aliyeva', 'leyla.a@gmail.com', '0502345678', '2022-03-15', 'HR Specialist', 1200.00, 'HR'),
(3, 'Murad', 'Mammadov', 'murad.m@gmail.com', '0513456789', '2021-06-20', 'Accountant', 1300.00, 'Finance'),
(4, 'Aysel', 'Huseynova', 'aysel.h@gmail.com', '0554567890', '2020-09-01', 'Project Manager', 2500.00, 'IT'),
(5, 'Rashad', 'Aliyev', 'rashad.a@gmail.com', '0505678901', '2023-05-12', 'Support Engineer', 1100.00, 'IT'),
(6, 'Nigar', 'Rahimova', 'nigar.r@gmail.com', '0516789012', '2019-11-30', 'Designer', 1400.00, 'Marketing'),
(7, 'Orkhan', 'Ismayilov', 'orkhan.i@gmail.com', '0557890123', '2022-07-18', 'Backend Developer', 1800.00, 'IT'),
(8, 'Sona', 'Guliyeva', 'sona.g@gmail.com', '0508901234', '2021-02-25', 'HR Manager', 2000.00, 'HR'),
(9, 'Tural', 'Hasanov', 'tural.h@gmail.com', '0519012345', '2020-12-05', 'Data Analyst', 1700.00, 'Analytics'),
(10, 'Elvin', 'Mustafayev', 'elvin.m@gmail.com', '0550123456', '2023-08-14', 'DevOps Engineer', 2200.00, 'IT'),
(11, 'Gunel', 'Suleymanova', 'gunel.s@gmail.com', '0501122334', '2022-01-10', 'QA Engineer', 1600.00, 'IT'),
(12, 'Kamal', 'Aliyev', 'kamal.a@gmail.com', '0512233445', '2021-04-18', 'System Admin', 1900.00, 'IT'),
(13, 'Fidan', 'Mammadova', 'fidan.m@gmail.com', '0553344556', '2020-10-25', 'UX Designer', 1500.00, 'Design'),
(14, 'Zaur', 'Quliyev', 'zaur.q@gmail.com', '0504455667', '2019-06-12', 'Team Lead', 3000.00, 'IT'),
(15, 'Sabina', 'Huseynli', 'sabina.h@gmail.com', '0515566778', '2023-03-08', 'Marketing Specialist', 1400.00, 'Marketing'),
(16, 'Eldar', 'Rzayev', 'eldar.r@gmail.com', '0556677889', '2021-09-19', 'Backend Developer', 2100.00, 'IT'),
(17, 'Lala', 'Hasanova', 'lala.h@gmail.com', '0507788990', '2022-11-30', 'HR Assistant', 1100.00, 'HR'),
(18, 'Anar', 'Mikayilov', 'anar.m@gmail.com', '0518899001', '2020-02-14', 'Database Admin', 2300.00, 'IT'),
(19, 'Nurlan', 'Ismayilzade', 'nurlan.i@gmail.com', '0559900112', '2023-06-22', 'Frontend Developer', 1800.00, 'IT'),
(20, 'Sevda', 'Aliyeva', 'sevda.a@gmail.com', '0501011121', '2019-08-05', 'Finance Manager', 2700.00, 'Finance');

Select * From Employees;

Select * From Employees where Salary > 2000;

Select * From Employees where Department = 'IT';

Select * From Employees Order By Salary Desc;

Select FirstName, Salary From Employees 

Select * From Employees where HireDate > '2020-12-31';

Select * From Employees where Email like '%company.az%';

Select Max(Salary) From Employees;

Select Min(Salary) From Employees;

Select Avg(Salary) From Employees;

Select Count(*) as AllEmployeesCount From Employees;

Select Sum(Salary) as AllEmployeesSalarySum From Employees;

Select Department, Count(*) as EmployeeCount From Employees 
Group By Department;

Select Department, Avg(Salary) as AvgSalary From Employees
Group By Department;

Select Department, Max(Salary) as MaximumSalary From Employees
Group By Department;

Update Employees set Salary = 2800 where EmployeeID = 1;

Update Employees set Salary = Salary + (Salary * 0.1);

Update Employees set JobTitle = 'HR Meneceri' where FirstName = 'Leyla' and LastName = 'Hesenova'

Delete From Employees where EmployeeID = 5;

Insert Into Employees
Values
(21, 'Huseyin', 'Memmedzade', 'huseyin.h@gmail.com', '0509543437', '2026-03-28', 'Full Stack Developer', 1300.00, 'IT')

Delete From Employees where Salary < 1500;

Select * From Employees where FirstName like '%a%';

Select * From Employees where Salary between 2000 and 2500;

Select * From Employees where Department in ('Maliyyə', 'IT');