🚗 DVLD - Driving & Vehicle License Department

A desktop application for managing driving license operations, applications, tests, drivers, users, and license-related processes.

Built with C# Windows Forms, SQL Server, ADO.NET, and a 3-Layer Architecture, this project demonstrates practical software development and database management concepts.

📌 About the Project

DVLD is a desktop management system designed to simulate the core operations of a Driving & Vehicle License Department.

The system manages people, users, drivers, applications, driving licenses, test appointments, international licenses, and detained or released licenses.

The project focuses on applying Object-Oriented Programming, database design, business logic separation, and reusable Windows Forms components in a real-world-style application.

✨ Features
👤 People Management
Add, edit, delete, and search for people.
View detailed person information.
Manage nationality information.
👨‍💼 Users & Drivers
Manage system users and drivers.
Add and edit user information.
Change user passwords.
View user and driver details.
📝 Applications
Manage application types.
Create and manage Local Driving License Applications.
Create International Driving License Applications.
Manage international license records.
🚘 Driving Licenses
Issue driving licenses.
Renew driving licenses.
Replace lost or damaged licenses.
View license information and driving license history.
🧪 Tests & Appointments
Manage test types.
Schedule test appointments.
Handle vision, written, and street tests.
Record test results.
Handle retake test applications.
🔒 Detained Licenses
Detain driving licenses.
Manage detained licenses.
Release detained licenses.
Track license release information.
📸 Screenshots
 
![Dashboard](dashboard.png)
![Login](login.png)
![Manage-People](manage-people.png)
![manage-users](manage-users.png)
![local-applications](local-applications.png)
![issue-license](issue-license.png)
![international-license](international-license.png)
![detain-license](detain-license.png)
![release-license](release-license.png)
  
 



 




 




 




  

The application follows a 3-Layer Architecture to separate responsibilities and make the code easier to maintain.

┌──────────────────────────────────┐
│       Presentation Layer         │
│    Windows Forms + UserControls  │
└────────────────┬─────────────────┘
                 │
                 ▼
┌──────────────────────────────────┐
│          Business Layer          │
│       Business Logic & Rules     │
└────────────────┬─────────────────┘
                 │
                 ▼
┌──────────────────────────────────┐
│        Data Access Layer         │
│             ADO.NET              │
└────────────────┬─────────────────┘
                 │
                 ▼
┌──────────────────────────────────┐
│           SQL Server             │
└──────────────────────────────────┘
Presentation Layer

Responsible for the user interface and user interaction, including Windows Forms and reusable UserControls.

Business Layer

Contains business entities, application logic, and validation rules.

Examples:

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

Handles database operations and communication with SQL Server using ADO.NET.

Examples:

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
Microsoft SQL Server
ADO.NET
Visual Studio
Object-Oriented Programming (OOP)
3-Layer Architecture
🗄️ Database

The application uses Microsoft SQL Server to store and manage data related to:

People and countries
Users and drivers
Applications and application types
License classes and driving licenses
Tests and test appointments
International licenses
Detained licenses

The application accesses the database through the Data Access Layer using ADO.NET.

📂 Project Structure
DVLD Project/
│
├── DVLD/
│   ├── Forms/
│   ├── UserControls/
│   ├── Properties/
│   ├── Resources/
│   ├── App.config.example
│   └── DVLD.slnx
│
├── DVLD.Business/
│
├── DVLD.DataAccess/
│
├── DVLD_Image/
│
├── Screenshots/
│
├── .gitignore
└── README.md
🚀 How to Run
Prerequisites
Visual Studio
Microsoft SQL Server
SQL Server Management Studio (SSMS)
Setup
Clone or download this repository.
Open DVLD/DVLD.slnx in Visual Studio.
Create or restore the required DVLD database.
Configure the SQL Server connection string in your local App.config.
Build the solution.
Run the application.
Database Configuration

The repository includes App.config.example as a configuration template.

Configure your own local connection string before running the application. Do not commit real database credentials or passwords to GitHub.

Note: Database setup scripts or a database backup should be provided separately if you want others to reproduce the complete database locally.

🎯 Project Goals

This project was developed to practice and apply:

C# and Object-Oriented Programming
Windows Forms application development
SQL Server database design and integration
ADO.NET data access
Multi-layer software architecture
CRUD operations
Business logic separation
Reusable UserControls
Database-driven application workflows
🎥 Demo

A video demonstration of the main application workflows will be added in the future.

👨‍💻 Author

Amr Mohamed

Computer Science Student

GitHub: @3mrMo7amed06
