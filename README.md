DVLD — Driving \& Vehicle License Department



A desktop application for managing driving license services, applications, and driver records.



Overview



DVLD is a C# Windows Forms application built to organize driving license department operations. The project follows a three-layer architecture to separate the presentation, business logic, and data access responsibilities.



Technologies Used

C#

Windows Forms (WinForms)

.NET Framework 4.7.2

Microsoft SQL Server

ADO.NET

SQL

Architecture



The solution is organized into three main layers:



Presentation Layer (DVLD) — Windows Forms user interface and application screens.

Business Layer (DVLD.Business) — Business rules, validation, and application logic.

Data Access Layer (DVLD.DataAccess) — Database queries and data operations.

Main Features

People management

Driver management

Local driving license applications

License information and eligibility validation

International driving license applications

International driving license records

Application and license data management

Project Structure

DVLD Project/

├── DVLD/

├── DVLD.Business/

├── DVLD.DataAccess/

├── DVLD\_Image/

├── .gitignore

└── README.md

Requirements

Windows

Visual Studio with .NET Framework 4.7.2 development support

Microsoft SQL Server

A configured DVLD database

Setup

Clone or download this repository.

Open DVLD/DVLD.slnx in Visual Studio.

Configure your SQL Server connection string in your local App.config.

Make sure the required DVLD database and tables exist.

Build the solution and run the application.



Configuration note: App.config.example is provided as a template. Create or configure your local App.config using your own database settings. Do not commit real passwords or other sensitive credentials.



Purpose



This project demonstrates practical experience with C#, Windows Forms, SQL Server, database access, layered architecture, and building a multi-form desktop application.



Status: Ongoing learning project.

