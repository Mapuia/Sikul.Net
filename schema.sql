-- AcademicYears Table
CREATE TABLE AcademicYears (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Year TEXT NOT NULL UNIQUE,
    StartDate DATE,
    EndDate DATE,
    IsActive INTEGER DEFAULT 0 -- Added IsActive column
);

-- Classes Table
CREATE TABLE Classes (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    ClassName TEXT NOT NULL UNIQUE
);

-- Sections Table
CREATE TABLE Sections (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    SectionName TEXT NOT NULL UNIQUE
);

-- Users Table
CREATE TABLE Users (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Username TEXT NOT NULL UNIQUE,
    Password TEXT NOT NULL,
    Role TEXT NOT NULL
);

-- Students Table
CREATE TABLE Students (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL,
    Guardian TEXT,
    DOB DATE,
    Aadhaar TEXT,
    APAR TEXT,
    Address TEXT,
    UserId INTEGER,
    AdmissionYear INT,
    Creation_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    Modified_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);

-- Admission Table
CREATE TABLE Admission (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    StudentId INTEGER NOT NULL,
    AcademicYearId INTEGER,
    ClassId INTEGER,
    SectionId INTEGER,
    RollNo INTEGER,
    UserId INTEGER,   
    Creation_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    Modified_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (ClassId) REFERENCES Classes(Id),
    FOREIGN KEY (SectionId) REFERENCES Sections(Id),
    FOREIGN KEY (AcademicYearId) REFERENCES AcademicYears(Id),
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);

-- ExamTypes Table
CREATE TABLE ExamTypes (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    ExamTypeName TEXT NOT NULL UNIQUE,
    MajorMaxMark REAL,
    MinorMaxMark REAL
);

-- Subjects Table
CREATE TABLE Subjects (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    SubjectName TEXT NOT NULL UNIQUE,
    SubjectCategory TEXT
);

-- Marks Table
CREATE TABLE Marks (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    StudentId INTEGER,
    SubjectId INTEGER,
    ExamTypeId INTEGER,
    AcademicYearId INTEGER,
    MarksObtained REAL,
    UserId INTEGER,
    Creation_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    Modified_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    Grade TEXT,
    FOREIGN KEY (StudentId) REFERENCES Students(Id),
    FOREIGN KEY (SubjectId) REFERENCES Subjects(Id),
    FOREIGN KEY (ExamTypeId) REFERENCES ExamTypes(Id),
    FOREIGN KEY (AcademicYearId) REFERENCES AcademicYears(Id),
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);

-- Results Table
CREATE TABLE Results (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    StudentId INTEGER,
    AcademicYearId INTEGER,
    TotalMarks REAL,
    Percentage REAL,
    Division TEXT,
    UserId INTEGER,
    Creation_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    Modified_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    Rank INTEGER,
    ResultStatus TEXT,
    FOREIGN KEY (StudentId) REFERENCES Students(Id),
    FOREIGN KEY (AcademicYearId) REFERENCES AcademicYears(Id),
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);

-- CumulativeMarks Table
CREATE TABLE CumulativeMarks (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    StudentId INTEGER,
    SubjectId INTEGER,
    TotalMarks REAL,
    AverageMarks REAL,
    AcademicYearId INTEGER,
    FOREIGN KEY (StudentId) REFERENCES Students(Id),
    FOREIGN KEY (SubjectId) REFERENCES Subjects(Id),
    FOREIGN KEY (AcademicYearId) REFERENCES AcademicYears(Id)
);

-- ReportCards Table
CREATE TABLE ReportCards (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    StudentId INTEGER,
    AcademicYearId INTEGER,
    ReportCardData TEXT, -- JSON or XML data
    UserId INTEGER,
    Creation_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    Modified_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (StudentId) REFERENCES Students(Id),
    FOREIGN KEY (AcademicYearId) REFERENCES AcademicYears(Id),
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);

-- Settings Table
CREATE TABLE Settings (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    PassMarkPercentage REAL,
    GradeEvaluationCriteria TEXT, -- JSON or XML data
    DivisionCriteria TEXT, -- JSON or XML data
    CurrentAcademicYearId INTEGER NOT NULL,
    FOREIGN KEY (CurrentAcademicYearId) REFERENCES AcademicYears(Id)
);