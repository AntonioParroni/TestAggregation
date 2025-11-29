-- ==== INSERT PROJECTS ====
INSERT INTO Projects (Name) VALUES
('Mars Rover'),
('Manhattan');

-- ==== INSERT EMPLOYEES ====
INSERT INTO Employees (Name) VALUES
('Mario'),
('Giovanni'),
('Lucia');

-- ==== INSERT ACTIVITIES ====
INSERT INTO Activities (ProjectId, EmployeeId, ActivityDate, Hours) VALUES
(1, 1, '2021-08-27', 5), -- Mars Rover, Mario
(2, 2, '2021-08-31', 3), -- Manhattan, Giovanni
(1, 1, '2021-09-01', 3), -- Mars Rover, Mario
(1, 3, '2021-09-01', 3), -- Mars Rover, Lucia
(2, 1, '2021-08-27', 2), -- Manhattan, Mario
(2, 2, '2021-09-01', 4); -- Manhattan, Giovanni
