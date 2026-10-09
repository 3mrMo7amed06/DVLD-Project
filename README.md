DVLD - Driving & Vehicle License Department

A desktop application for managing driving license operations, applications, tests, drivers, users, and license-related processes.

The project was built using C# Windows Forms, SQL Server, ADO.NET, and a 3-Layer Architecture to separate the presentation, business, and data access logic.

📌 About the Project

DVLD is a desktop management system designed to simulate the core operations of a Driving & Vehicle License Department.

The system manages people, drivers, users, applications, driving licenses, tests, international licenses, and detained/released licenses.

The project focuses on applying practical software development concepts such as:

Object-Oriented Programming
3-Layer Architecture
Database Design
ADO.NET
CRUD Operations
Business Logic Separation
Reusable Windows Forms UserControls
SQL Server Database Integration
✨ Features
👤 People Management
Add new people
Edit person information
Delete people
Search and filter people
View person details
Manage nationality information
👨‍💼 Users & Drivers
Manage system users
Add and edit users
Change password
View user details
Manage drivers
View driver information
📝 Applications
Manage application types
Create Local Driving License Applications
Manage Local Driving License Applications
Create International Driving License Applications
Manage International Licenses
🚗 Driving Licenses
Issue driving licenses
Renew driving licenses
Replace lost licenses
Replace damaged licenses
View license information
View driver's license history
🧪 Tests & Appointments
Manage test types
Schedule test appointments
Vision tests
Written tests
Street tests
Record test results
Handle retake test applications
🔒 Detained Licenses
Detain a driving license
Manage detained licenses
Release detained licenses
Track release information
🏗️ Architecture

The application follows a 3-Layer Architecture:

┌─────────────────────────────┐
│      Presentation Layer     │
│   WinForms + UserControls   │
└──────────────┬──────────────┘
               │
               ▼
┌─────────────────────────────┐
│        Business Layer       │
│       Business Logic        │
└──────────────┬──────────────┘
               │
               ▼
┌─────────────────────────────┐
│      Data Access Layer      │
│          ADO.NET            │
└──────────────┬──────────────┘
               │
               ▼
┌─────────────────────────────┐
│          SQL Server         │
└─────────────────────────────┘

Presentation Layer

Contains:

Windows Forms
UserControls
UI logic
User interaction
Business Layer

Contains the application's business logic and entities, including classes such as:

clsPerson
clsUser
clsDriver
clsApplication
clsLicense
clsTest
clsTestAppointment
clsInternationalLicense
clsDetainedLicense
Data Access Layer

Handles communication with SQL Server using ADO.NET.

Examples include:

clsPersonData
clsUserData
clsDriverData
clsApplicationData
clsLicenseData
clsTestData
clsTestAppointmentData
clsInternationalLicenseData
clsDetainedLicenseData
🛠️ Technologies
C#
Windows Forms
.NET
SQL Server
ADO.NET
Visual Studio
3-Layer Architecture
🗄️ Database

The application uses Microsoft SQL Server as its database management system.

The database stores and manages information related to:

People
Countries
Users
Drivers
Applications
Application Types
License Classes
Licenses
Tests
Test Appointments
International Licenses
Detained Licenses
📂 Project Structure
DVLD
│
├── Forms
│   ├── Main
│   ├── Applications
│   ├── Tests
│   ├── People
│   └── Users
│
├── UserControls
│   ├── Applications
│   ├── Licenses
│   ├── People
│   ├── Users
│   └── Tests
│
├── Business
│
└── DataAccess

📸 Screenshots
Main Dashboard

Screenshot coming soon.

Manage People

Screenshot coming soon.

Manage Users

Screenshot coming soon.

Local Driving License Applications

Screenshot coming soon.

Tests & Appointments

Screenshot coming soon.

Issue Driving License

Screenshot coming soon.

International Driving License

Screenshot coming soon.

Detain & Release License

Screenshot coming soon.

🎥 Demo

A short walkthrough demonstrating the main workflows of the DVLD system.

Demo video coming soon.

🚀 How to Run
Prerequisites
Visual Studio
SQL Server
SQL Server Management Studio
Setup
Clone the repository.
Open the solution in Visual Studio.
Restore or create the DVLD database.
Configure the SQL Server connection.
Build the solution.
Run the application.

Database setup details will be added with the project database/scripts.

🎯 Project Goals

This project was built to practice and apply:

C# and Object-Oriented Programming
Windows Forms development
SQL Server database development
ADO.NET
Multi-layer application architecture
Database-driven application design
Reusable UserControls
Business logic separation
Real-world CRUD workflows
👨‍💻 Author

Amr Mohamed

Computer Science Student
