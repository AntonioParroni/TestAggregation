use Gestional;

-- ==== PROJECTS TABLE ====
CREATE TABLE Projects (
    ProjectId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL
);

-- ==== EMPLOYEES TABLE ====
CREATE TABLE Employment (
    EmployeeId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL
);

-- ==== ACTIVITIES TABLE ====
CREATE TABLE Activities (
    ActivityId INT IDENTITY(1,1) PRIMARY KEY,
    ProjectId INT NOT NULL,
    EmployeeId INT NOT NULL,
    ActivityDate DATE NOT NULL,
    Hours INT NOT NULL,

    FOREIGN KEY (ProjectId) REFERENCES Projects(ProjectId),
    FOREIGN KEY (EmployeeId) REFERENCES Employment(EmployeeId)
);


