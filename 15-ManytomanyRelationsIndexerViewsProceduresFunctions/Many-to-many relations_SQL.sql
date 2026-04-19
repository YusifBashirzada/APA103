create database CompanyMM;

use CompanyMM;

create table Employees (
EmployeeID int primary key identity,
FirstName nvarchar(50) not null,
LastName nvarchar(50) not null,
BirthDate date,
Email varchar(50) unique not null
)

create table Projects (
ProjectID int primary key identity,
ProjectName nvarchar(50) not null,
StartDate date not null,
EndDate date,
Check(EndDate is null or EndDate >= StartDate)
)

create table EmployeeProjects (
EmployeeID int,
ProjectID int,
AssignedDate date,

primary key (EmployeeId, ProjectId),

foreign key (EmployeeId) references Employees(EmployeeId),
foreign key (ProjectId) references Projects(ProjectId),

Check (AssignedDate <= GetDate())
)


Insert into Employees (FirstName, LastName, BirthDate, Email) 
Values
('Ali', 'Huseynov', '1995-03-12', 'ali.h@gmail.com'),
('Leyla', 'Hesenova', '1998-07-25', 'leyla.h@gmail.com'),
('Murad', 'Memmedov', '1992-11-05', 'murad.m@gmail.com'),
('Aysel', 'Aliyeva', '1996-02-18', 'aysel.a@gmail.com'),
('Anar', 'Kerimov', '1994-09-30', 'anar.k@gmail.com'),
('Sevda', 'Quliyeva', '1993-06-14', 'sevda.q@gmail.com'),
('Eldar', 'Ismayilov', '1991-12-01', 'eldar.i@gmail.com'),
('Nigar', 'Abbasova', '1997-04-22', 'nigar.a@gmail.com'),
('Rauf', 'Suleymanov', '1990-08-10', 'rauf.s@gmail.com'),
('Kamal', 'Hasanov', '1995-01-17', 'kamal.h@gmail.com'),
('Lala', 'Mammadova', '1999-05-09', 'lala.m@gmail.com'),
('Orxan', 'Rahimov', '1993-10-03', 'orxan.r@gmail.com'),
('Sabina', 'Aliyeva', '1996-07-19', 'sabina.a@gmail.com'),
('Tural', 'Bagirov', '1992-02-27', 'tural.b@gmail.com'),
('Gunel', 'Asadova', '1998-12-15', 'gunel.a@gmail.com');


Insert into Projects (ProjectName, StartDate, EndDate) 
Values
('Website Development', '2023-01-01', '2023-06-01'),
('Mobile App', '2023-02-15', '2023-08-30'),
('E-commerce Platform', '2023-03-10', NULL),
('CRM System', '2023-04-05', '2023-12-20'),
('AI Chatbot', '2023-05-01', NULL),
('Banking System', '2023-06-01', '2024-01-15'),
('Game Development', '2023-07-20', NULL),
('Cloud Migration', '2023-08-10', '2024-02-28'),
('Security System', '2023-09-01', NULL),
('Analytics Dashboard', '2023-10-05', '2024-03-10');

Insert into EmployeeProjects (EmployeeID, ProjectID, AssignedDate) 
Values
(1, 1, '2023-01-05'),
(1, 2, '2023-02-10'),
(2, 1, '2023-01-10'),
(2, 3, '2023-03-15'),
(3, 2, '2023-02-20'),
(3, 4, '2023-04-01'),
(3, 5, '2023-05-17'),
(3, 8, '2023-07-26'),
(4, 5, '2023-05-10'),
(5, 6, '2023-06-12'),
(6, 7, '2023-07-25'),
(7, 8, '2023-08-18'),
(8, 9, '2023-09-05'),
(9, 10, '2023-10-10'),
(9, 3, '2023-08-23'),
(10, 3, '2023-03-25'),
(10, 4, '2023-04-15'),
(11, 5, '2023-05-20'),
(12, 6, '2023-06-18'),
(13, 7, '2023-07-30'),
(14, 8, '2023-08-22'),
(15, 8, '2023-08-28'),
(15, 9, '2023-09-12'),
(15, 10, '2023-10-18');

Select * From Employees;

Select * From Projects;

Select e.FirstName, e.LastName, p.ProjectName from Employees as e
join EmployeeProjects as ep
on ep.EmployeeID = e.EmployeeID
join Projects p
on ep.ProjectID = p.ProjectID

Select p.ProjectName, COUNT(ep.EmployeeID) as EmployeeCount from Projects as p
left join EmployeeProjects as ep
on p.ProjectID = ep.ProjectID
Group By p.ProjectName

Select e.FirstName, e.LastName, Count(ep.ProjectID) as ProjectCount from Employees as e
left join EmployeeProjects as ep
on e.EmployeeID = ep.EmployeeID
Group By e.EmployeeID, e.FirstName, e.LastName
Having Count(ep.ProjectID) > 2;

Go;

create view EmployeeProjectView as
Select e.EmployeeID, 
       Concat(e.FirstName, ' ', e.LastName) as FullName,
       p.ProjectID, 
       p.ProjectName, 
       ep.AssignedDate
From Employees as e
join EmployeeProjects as ep
on e.EmployeeID = ep.EmployeeID
join Projects as p
on ep.ProjectID = p.ProjectID

Select * From EmployeeProjectView where EmployeeID = 1;

Go;

create procedure sp_AssignEmployeeToProject
    @empId int,
    @projId int
as
begin
    if not exists (
        Select * from EmployeeProjects
        where EmployeeID = @empId and ProjectID = @projId
    )
    begin
        Insert into EmployeeProjects (EmployeeID, ProjectID, AssignedDate)
        Values (@empId, @projId, GetDate())
    end
end

Exec sp_AssignEmployeeToProject 2, 3;

Exec sp_AssignEmployeeToProject 1, 5;

Go;

create function fn_GetProjectCount (
    @empId int
)
returns int
as
begin
    Declare @ProjectCount int;

    Select @ProjectCount = Count(*) from EmployeeProjects as e
    where e.EmployeeID = @empId

    return @ProjectCount;
end

Select dbo.fn_GetProjectCount(2) as ProjectCount

Exec sp_AssignEmployeeToProject 1, 6;

Select * From EmployeeProjects where EmployeeID = 9

Delete From EmployeeProjects where EmployeeID = 9