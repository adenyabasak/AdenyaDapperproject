# Adenya Dapper Project - Freelance Job Platform

Adenya Dapper Project is a modern Freelance Job Platform developed using **ASP.NET Core MVC**, **Dapper**, and **SQL Server**. The project demonstrates high-performance database operations by combining **Dapper** with **Stored Procedures**, providing a lightweight and efficient alternative to traditional ORM solutions.

The application allows employers to publish freelance jobs while users can browse job listings, submit proposals, and manage their accounts through a modern and responsive interface. It also includes an Admin Panel, Dashboard, Reporting System, Authentication, Excel & PDF Export features.

---

# Project Architecture

```
SQL Server
     │
Stored Procedures
     │
Dapper
     │
Repository Layer
     │
ASP.NET Core MVC
     │
Bootstrap User Interface
```

---

# Technologies

| Technology | Description |
|------------|-------------|
| ASP.NET Core MVC | Frontend & Backend Framework |
| Dapper | Micro ORM |
| SQL Server | Database |
| Stored Procedures | Database Operations |
| ADO.NET | Authentication |
| Bootstrap 5 | Responsive UI |
| LINQ | Reporting |
| ClosedXML | Excel Export |
| iTextSharp | PDF Export |
| Session | Authentication |

---

# NuGet Packages

- Dapper
- Microsoft.Data.SqlClient
- ClosedXML
- iTextSharp.LGPLv2.Core
- Microsoft.AspNetCore.Session

---

# Project Features

- ASP.NET Core MVC
- Dapper Integration
- SQL Server Database
- Stored Procedures
- CRUD Operations
- Repository Pattern
- Session Authentication
- Admin Panel
- User Registration
- User Login
- Dashboard
- Reporting System
- Excel Export
- PDF Export
- Responsive Bootstrap Design

---

# Authentication

The project contains two predefined demo accounts for testing purposes.

## Administrator Account

| Email | Password |
|-------|----------|
| admin@gmail.com | 1234 |

The administrator has full access to the management panel, dashboard, reports, users, categories, jobs and proposals.

---

## User Account

| Email | Password |
|-------|----------|
| user@gmail.com | 1234 |

The user can browse job listings, submit proposals and manage personal activities.

---

# Database Structure

The project is built on four main relational tables.

## Users

Stores all registered users.

- UserId
- FullName
- Email
- Password
- Role

---

## Categories

Stores freelance job categories.

- CategoryId
- CategoryName

---

## Jobs

Stores freelance job advertisements.

- JobId
- Title
- Description
- Budget
- CategoryId
- UserId

---

## Proposals

Stores freelancer proposals submitted for jobs.

- ProposalId
- Price
- Description
- JobId
- UserId

---

# Why Dapper?

Instead of using Entity Framework Core, this project was developed with **Dapper**, a lightweight Micro ORM known for its speed and simplicity.

All database operations are performed through **Stored Procedures**, providing:

- Better Performance
- Faster Query Execution
- Secure Database Access
- Reusable SQL Logic
- Clean Repository Structure

---

# Home Page

The Home page introduces visitors to the Freelance Job Platform through a modern landing page. Users can explore the platform, browse featured freelance jobs and navigate to different sections using a responsive Bootstrap interface.

### Features

- Responsive Design
- Modern Landing Page
- Bootstrap Components
- Easy Navigation

<img src="https://raw.githubusercontent.com/adenyabasak/AdenyaDapperproject/master/images/home.png" width="100%">

---

# Home About Section

The About section provides information about the platform, explaining its purpose and helping visitors understand how employers and freelancers interact within the system.

<img src="https://raw.githubusercontent.com/adenyabasak/AdenyaDapperproject/master/images/homealt.png" width="100%">

---

# Home Statistics

This section presents key platform statistics, allowing visitors to quickly understand the overall activity of the system.

<img src="https://raw.githubusercontent.com/adenyabasak/AdenyaDapperproject/master/images/homeortakisim.png" width="100%">

---

# About Page

The About page introduces the project in more detail and explains the goals of the Freelance Job Platform.

<img src="https://raw.githubusercontent.com/adenyabasak/AdenyaDapperproject/master/images/hakkimizda.png" width="100%">

---

# Contact Page

The Contact page allows visitors to reach the platform administrators and provides communication information.

<img src="https://raw.githubusercontent.com/adenyabasak/AdenyaDapperproject/master/images/iletisim.png" width="100%">

---


# Dashboard

The Dashboard serves as the central management panel of the Freelance Job Platform. It provides administrators with a quick overview of the entire system through statistical cards, reports, and quick navigation menus.

The dashboard helps administrators monitor platform activities without manually checking database records.

### Dashboard Features

- Total Users
- Total Categories
- Total Jobs
- Total Proposals
- Quick Navigation Cards
- Modern Responsive Design

<img src="https://raw.githubusercontent.com/adenyabasak/AdenyaDapperproject/master/images/dashboard.png" width="100%">

---

# Category Management

The Category Management page enables administrators to organize freelance job categories. Categories help employers classify their job advertisements, making it easier for freelancers to find relevant opportunities.

### Features

- List Categories
- Add Category
- Update Category
- Delete Category
- Stored Procedure CRUD
- Dapper Repository

<img src="https://raw.githubusercontent.com/adenyabasak/AdenyaDapperproject/master/images/kategori.png" width="100%">

---

# Job Management

The Job Management page allows administrators to control all freelance job advertisements published on the platform.

Administrators can create new job postings, edit existing advertisements or remove outdated listings.

### Features

- View Jobs
- Add Job
- Update Job
- Delete Job
- Category Relationship
- Dapper CRUD

<img src="https://raw.githubusercontent.com/adenyabasak/AdenyaDapperproject/master/images/isler.png" width="100%">

---

# User Management

The User Management page contains all registered users within the system.

Administrators can monitor user accounts and perform complete CRUD operations when necessary.

### Features

- User List
- Add User
- Update User
- Delete User
- Session Authentication

<img src="https://raw.githubusercontent.com/adenyabasak/AdenyaDapperproject/master/images/kullaniciler.png" width="100%">

---

# Proposal Management

Freelancers submit proposals for available job advertisements through the Proposal module.

Administrators can review all submitted proposals and manage them through the administration panel.

### Features

- Proposal List
- Add Proposal
- Update Proposal
- Delete Proposal
- Job Relationship

<img src="https://raw.githubusercontent.com/adenyabasak/AdenyaDapperproject/master/images/teklif.png" width="100%">

---

# Add New Job

This page allows administrators to publish new freelance job advertisements by entering all required information.

### Features

- Job Title
- Description
- Budget
- Category Selection

<img src="https://raw.githubusercontent.com/adenyabasak/AdenyaDapperproject/master/images/yeniisekle.png" width="100%">

---

# Add New User

Administrators can create new user accounts directly from the administration panel.

Each user is stored securely inside SQL Server.

<img src="https://raw.githubusercontent.com/adenyabasak/AdenyaDapperproject/master/images/yenikullaniciekle.png" width="100%">

---

# Add New Proposal

This page enables administrators to create new proposals manually for demonstration or management purposes.

<img src="https://raw.githubusercontent.com/adenyabasak/AdenyaDapperproject/master/images/yeniteklifekle.png" width="100%">

---

# User Job Listings

After logging into the platform, users can browse all available freelance job advertisements.

Users can review project details and submit proposals for jobs matching their skills.

<img src="https://raw.githubusercontent.com/adenyabasak/AdenyaDapperproject/master/images/userisilanigorme.png" width="100%">

---

# User Proposal Page

The User Proposal page displays all proposals submitted by the logged-in user.

This page allows freelancers to track their submitted offers and review proposal details.

<img src="https://raw.githubusercontent.com/adenyabasak/AdenyaDapperproject/master/images/userteklif.png" width="100%">

---

# Reporting System

The application contains a reporting module developed using LINQ and SQL queries.

The reporting page provides administrators with valuable information about platform activity.

### Reports Include

- Total User Count
- Total Category Count
- Total Job Count
- Total Proposal Count
- Average Budget
- Highest Budget
- Lowest Budget
- Most Active Category

<img src="https://raw.githubusercontent.com/adenyabasak/AdenyaDapperproject/master/images/dashboard.png" width="100%">

---

# Excel Export

Reports can be exported directly to Microsoft Excel using **ClosedXML**.

This feature allows administrators to analyze data outside the application and create professional reports.

<img src="https://raw.githubusercontent.com/adenyabasak/AdenyaDapperproject/master/images/excel.png" width="100%">

---

# PDF Export

The project also supports exporting reports as PDF documents.

PDF reports can be archived, printed or shared with other users.

<img src="https://raw.githubusercontent.com/adenyabasak/AdenyaDapperproject/master/images/pdf.png" width="100%">

---



# Dapper & Stored Procedures

One of the most important aspects of this project is the use of **Dapper** together with **SQL Server Stored Procedures** instead of Entity Framework Core.

All CRUD operations are executed through Stored Procedures, while Dapper is responsible for mapping SQL query results to C# objects.

### Advantages

- High Performance
- Lightweight Data Access
- Fast Query Execution
- Reusable SQL Logic
- Better Database Security
- Clean Repository Pattern
- Easy Maintenance

---

# Repository Pattern

The project follows the **Repository Pattern** to separate database logic from the user interface.

This architecture makes the project easier to maintain and allows database operations to be managed from a single layer.

Project Layers

- Models
- Repositories
- Controllers
- Views
- SQL Stored Procedures

This structure keeps the code clean, organized and scalable.

---

# Installation

Clone the repository

```bash
git clone https://github.com/adenyabasak/AdenyaDapperproject.git
```

Open the solution using **Visual Studio 2022**.

Restore all NuGet packages.

Update the SQL Server connection string.

Run the SQL scripts that create the database tables and Stored Procedures.

Finally, start the application.

---

# Project Structure

```
AdenyaDapperProject
│
├── Controllers
├── Models
├── Repositories
├── Views
├── SQL
│   ├── Tables
│   └── Stored Procedures
├── wwwroot
├── Program.cs
└── appsettings.json
```

---

# Project Highlights

The project demonstrates many important backend development concepts.

### Backend

- ASP.NET Core MVC
- Dapper
- SQL Server
- Stored Procedures
- Repository Pattern
- Session Authentication
- CRUD Operations

### Frontend

- Bootstrap 5
- Responsive Design
- Dashboard
- Admin Panel
- User Interface

### Reporting

- Dashboard Statistics
- Excel Export
- PDF Export

---

# Future Improvements

The following features can be added in future versions.

- Identity Authentication
- JWT Authentication
- Email Verification
- Password Recovery
- Real-time Notifications
- SignalR Integration
- Online Messaging
- File Upload System
- Job Status Tracking
- Employer Profiles
- Freelancer Profiles
- Rating System
- Comments
- Payment Integration

---

# Developer

**Başak Erdoğan**

GitHub Profile

https://github.com/adenyabasak

Repository

https://github.com/adenyabasak/AdenyaDapperproject

---

# Project Summary

| Category | Information |
|----------|-------------|
| Project Name | Adenya Dapper Project |
| Project Type | Freelance Job Platform |
| Architecture | ASP.NET Core MVC |
| Database | SQL Server |
| ORM | Dapper |
| Database Access | Stored Procedures |
| Authentication | Session Authentication |
| Dashboard | ✔ |
| Admin Panel | ✔ |
| User Panel | ✔ |
| CRUD Operations | ✔ |
| Excel Export | ✔ |
| PDF Export | ✔ |
| Responsive Design | ✔ |

---

# Demo Accounts

## Administrator

| Email | Password |
|------|----------|
| admin@gmail.com | 1234 |

The administrator has full access to:

- Dashboard
- User Management
- Category Management
- Job Management
- Proposal Management
- Reports
- Excel Export
- PDF Export

---

## User

| Email | Password |
|------|----------|
| user@gmail.com | 1234 |

The user can:

- Browse Freelance Jobs
- View Job Details
- Submit Proposals
- Track Submitted Proposals
- Access Personal Pages

---

# Conclusion

Adenya Dapper Project is a portfolio application developed to demonstrate modern ASP.NET Core MVC development using **Dapper** and **Stored Procedures**.

The project combines high-performance database access, clean architecture, responsive user interface, authentication, reporting and export functionalities into a complete Freelance Job Platform.

It demonstrates practical usage of Dapper, Repository Pattern, Session Authentication, SQL Server Stored Procedures, Excel/PDF Export and responsive Bootstrap design within a real-world scenario.

---

If you like this project, don't forget to leave a ⭐ on GitHub.

