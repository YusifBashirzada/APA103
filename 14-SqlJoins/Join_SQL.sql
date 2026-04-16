create database Company2;

use Company2;

create table Countries(
Id int primary key identity,
Name nvarchar(50) not null
)

create table Cities(
Id int primary key identity,
Name nvarchar(50) not null,
CountryId int foreign key references Countries(Id)
)

create table Employees(
Id int primary key identity,
Name nvarchar(50) not null,
Surname nvarchar(50) not null,
Age int not null,
Salary decimal(10,2) not null,
Position varchar(100) not null,
IsDeleted bit not null,
CityId int foreign key references Cities(Id)
)

INSERT INTO Countries(Name)
VALUES 
('Azerbaijan'),
('Turkey'),
('Germany'),
('USA'),
('Italy'),
('France');

INSERT INTO Cities (Name, CountryId)
VALUES 
('Baku', 1),
('Ganja', 1),
('Sumqayit', 1),

('Istanbul', 2),
('Ankara', 2),
('Izmir', 2),

('Berlin', 3),
('Munich', 3),

('New York', 4),
('Los Angeles', 4),

('Rome', 5),
('Milan', 5),

('Paris', 6),
('Lyon', 6);

INSERT INTO Employees (Name, Surname, Age, Salary, Position, IsDeleted, CityId)
VALUES 
('Ali', 'Aliyev', 25, 1500.00, 'Developer', 0, 1),
('Veli', 'Huseynov', 30, 2000.00, 'Designer', 0, 2),
('Aysel', 'Mammadova', 28, 1800.00, 'HR Specialist', 1, 3),
('Nicat', 'Quliyev', 27, 2200.00, 'Backend Developer', 0, 1),
('Leyla', 'Hasanova', 24, 1600.00, 'UI/UX Designer', 1, 2),
('Huseyin', 'Abdurrahmanoglu', 34, 800, 'Reseption', 0, 2),

('John', 'Smith', 35, 3500.00, 'Software Engineer', 0, 9),
('Emma', 'Johnson', 29, 3200.00, 'Product Manager', 0, 10),
('Ramin', 'Veliyev', 34, 800, 'Reseption', 0, 1),

('Marco', 'Rossi', 40, 4000.00, 'Architect', 0, 11),
('Luca', 'Bianchi', 33, 3000.00, 'Developer', 1, 12),

('Pierre', 'Dubois', 38, 3800.00, 'Team Lead', 0, 13),
('Marie', 'Martin', 27, 2900.00, 'QA Engineer', 0, 14);


Select e.Name as EmployeesName, e.Surname as EmployeesSurname, ci.Name as City, co.Name as Country from Employees as e
inner join Cities as ci
on e.CityId = ci.id
inner join Countries as co
on ci.CountryId = co.id

Select e.Name as EmployeesName, co.Name as Country from Employees as e
inner join Cities as ci
on e.CityId = ci.id
inner join Countries as co
on ci.CountryId = co.id
where e.Salary > 2000

Select ci.Name as City, co.Name as Country from Cities as ci
inner join Countries as co
on ci.CountryId = co.id

Select e.Name, e.Surname, e.Age, e.Salary, e.Position, e.IsDeleted, ci.Name as City, co.Name as Country From Employees as e
inner join Cities as ci
on e.CityId = ci.id
inner join Countries as co
on ci.CountryId = co.id
where e.Position = 'Reseption'

Select e.Name, e.Surname, ci.Name as City, co.Name as Country from Employees as e
inner join Cities as ci
on e.CityId = ci.id
inner join Countries as co
on ci.CountryId = co.id
where e.IsDeleted = 1