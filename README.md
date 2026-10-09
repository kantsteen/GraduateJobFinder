# GraduateJobFinder
GraduateJobFinder is a side project I'm working on to help junior developers find jobs tailored to their skills and skill level.
Right now it's very early in development, so it doesn't fetch job postings from the internet yet. 


## Features
- Create, read, update and delete job postings
- Sort job postings by date
- Filter job postings by programming language


## Tech stack
- C# / .NET 10
- ASP.NET Core Razor Pages
- Entity Framework Core
- SQLite
- Bootstrap

## Getting started

### Prerequisites
You need the [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) to build and run the app.

### How to run it locally
Run the following commands to clone and run the project  
```bash
git clone https://github.com/kantsteen/GraduateJobFinder.git
cd GraduateJobFinder
dotnet run
```
The SQLite database is created and filled with sample job postings automatically on the first run.  
Then open http://localhost:5138 in your browser.


## Project structure
```
GraduateJobFinder/
├── Data/
│   └── GraduateJobFinderContext.cs   # EF Core DbContext: the connection between the models and the database
├── Migrations/                       # EF Core migrations that create and update the database schema
├── Models/
│   ├── JobPosting.cs                 # A job posting (company, title, description, location, date, URL)
│   ├── ProgrammingLanguage.cs        # A programming language (many-to-many with JobPosting)
│   └── SeedData.cs                   # Applies migrations and seeds the database with sample job postings
├── Pages/
│   ├── Index.cshtml(.cs)             # Front page: lists job postings with sorting and language filter
│   ├── _JobPosting.cshtml            # Partial view that renders a single job posting
│   ├── Postings/                     # Create, read, update and delete pages for job postings
│   └── Shared/                       # Shared layout used by all pages
├── Properties/
│   └── launchSettings.json           # Launch profiles (ports and environment) for local development
├── wwwroot/                          # Static files: CSS, JavaScript and third-party libraries
├── appsettings.json                  # App configuration
├── appsettings.Development.json      # Development configuration, including the SQLite connection string
└── Program.cs                        # App entry point: registers services and configures the request pipeline
```



## Future plans

### User facing
- Filter job postings based on distance from location
- Filter by type of job (internship, freelance, part time, full time)
- Adding an application deadline field
- Search for job postings
- Aggregating actual job postings from the internet

### Technical
- Adding tests (unit, e2e, integration)
- CI/CD using GitHub Actions
- Deployment so anyone can access the live web app
- Pagination