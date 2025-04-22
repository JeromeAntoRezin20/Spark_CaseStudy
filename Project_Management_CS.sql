
CREATE TABLE Project (
    Id int PRIMARY KEY IDENTITY(1,1),
    ProjectName varchar(100) NOT NULL,
    Description varchar(500),
    StartDate DATE NOT NULL,
    Status varchar(20) CHECK (Status IN ('started', 'dev', 'build', 'test', 'deployed'))
);
GO

CREATE TABLE Employee (
    Id int PRIMARY KEY IDENTITY(1,1),
    Name varchar(100) NOT NULL,
    Designation varchar(100) NOT NULL,
    Gender varchar(10),
    Salary DECIMAL(10,2),
    Project_id int FOREIGN KEY REFERENCES Project(Id) ON DELETE CASCADE
);
GO

CREATE TABLE Task (
    Task_id int PRIMARY KEY IDENTITY(1,1),
    Task_name varchar(200) NOT NULL,
    Project_id int NOT NULL FOREIGN KEY REFERENCES Project(Id) ,
    Employee_id int NOT NULL FOREIGN KEY REFERENCES Employee(Id),
    AllocationDate DATE DEFAULT GETDATE(),
    DeadlineDate DATE,
    Status varchar(20) CHECK (Status IN ('Assigned', 'Started', 'Completed'))
);
GO

INSERT INTO Project (ProjectName, Description, StartDate, Status)
VALUES 
('E-Commerce Platform', 'Online shopping website with payment gateway', '2023-01-15', 'deployed'),
('HR Management System', 'System for managing employee records and payroll', '2023-02-10', 'test'),
('Inventory Tracker', 'Application to track warehouse inventory', '2023-03-05', 'build'),
('Customer Support Portal', 'Ticketing system for customer support', '2023-01-20', 'deployed'),
('Mobile Banking App', 'iOS/Android banking application', '2023-04-01', 'dev'),
('Data Analytics Dashboard', 'Business intelligence dashboard', '2023-02-28', 'test'),
('Fitness Tracker', 'Mobile app for tracking workouts', '2023-03-15', 'build'),
('Hotel Booking System', 'Online reservation system for hotels', '2023-01-10', 'deployed'),
('Social Media Platform', 'New social networking site', '2023-05-01', 'started'),
('Document Management', 'System for organizing company documents', '2023-04-15', 'dev'),
('Fleet Management', 'Tracking system for company vehicles', '2023-03-01', 'test'),
('E-Learning Platform', 'Online courses and training system', '2023-02-15', 'deployed'),
('Healthcare Portal', 'Patient records management system', '2023-04-10', 'build'),
('Restaurant POS', 'Point of sale system for restaurants', '2023-01-25', 'deployed'),
('Weather Application', 'Real-time weather forecasting app', '2023-03-20', 'dev');

Select *from Project


INSERT INTO Employee (Name, Designation, Gender, Salary, Project_id)
VALUES 
('John Smith', 'Project Manager', 'Male', 85000.00, 1),
('Emily Johnson', 'Senior Developer', 'Female', 75000.00, 1),
('Michael Brown', 'Database Administrator', 'Male', 72000.00, 2),
('Sarah Wilson', 'UI/UX Designer', 'Female', 68000.00, 3),
('David Lee', 'Backend Developer', 'Male', 70000.00, 4),
('Jennifer Davis', 'QA Engineer', 'Female', 65000.00, 5),
('Robert Taylor', 'DevOps Engineer', 'Male', 78000.00, 6),
('Jessica Anderson', 'Frontend Developer', 'Female', 69000.00, 7),
('William Martinez', 'Business Analyst', 'Male', 67000.00, 8),
('Amanda Thompson', 'Technical Writer', 'Female', 62000.00, 9),
('Christopher Garcia', 'Full Stack Developer', 'Male', 73000.00, 10),
('Elizabeth Robinson', 'Scrum Master', 'Female', 71000.00, 11),
('James Clark', 'System Architect', 'Male', 82000.00, 12),
('Ashley Rodriguez', 'Mobile Developer', 'Female', 74000.00, 13),
('Daniel Lewis', 'Data Scientist', 'Male', 79000.00, 14);


Select *from Employee


INSERT INTO Task (Task_name, Project_id, Employee_id, AllocationDate, DeadlineDate, Status)
VALUES 
('Design database schema', 1, 2, '2023-01-16', '2023-01-23', 'Completed'),
('Implement payment gateway', 1, 5, '2023-01-18', '2023-02-15', 'Started'),
('Create employee registration form', 2, 3, '2023-02-12', '2023-02-19', 'Completed'),
('Develop inventory search functionality', 3, 4, '2023-03-07', '2023-03-14', 'Started'),
('Build ticket assignment system', 4, 6, '2023-01-22', '2023-01-29', 'Completed'),
('Implement biometric login', 5, 7, '2023-04-03', '2023-04-17', 'Assigned'),
('Create sales trend visualization', 6, 8, '2023-03-01', '2023-03-15', 'Started'),
('Design workout tracking UI', 7, 9, '2023-03-17', '2023-03-24', 'Completed'),
('Implement room availability check', 8, 10, '2023-01-12', '2023-01-19', 'Completed'),
('Develop post sharing feature', 9, 11, '2023-05-03', '2023-05-17', 'Assigned'),
('Create document versioning system', 10, 12, '2023-04-17', '2023-04-24', 'Started'),
('Implement GPS tracking', 11, 13, '2023-03-03', '2023-03-10', 'Completed'),
('Build quiz module', 12, 14, '2023-02-17', '2023-02-24', 'Completed'),
('Develop patient records encryption', 13, 15, '2023-04-12', '2023-04-19', 'Started'),
('Create order management screen', 14, 1, '2023-01-27', '2023-02-03', 'Completed');

Select *from Task
