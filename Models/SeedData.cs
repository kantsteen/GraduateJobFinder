using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraduateJobFinder.Data;
using Microsoft.EntityFrameworkCore;

namespace GraduateJobFinder.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new GraduateJobFinderContext(
                serviceProvider.GetRequiredService<DbContextOptions<GraduateJobFinderContext>>()))
            {
                if (context == null || context.JobPosting == null)
                {
                    throw new ArgumentNullException("Null GraduateJobFinderContext");
                }

                if (context.JobPosting.Any())
                {
                    return;
                }

                context.JobPosting.AddRange(
                    new JobPosting
                    {
                        CompanyName = "Novo Nordisk",
                        Title = "Senior software engineer",
                        Description = "You will work as a senior software engineer",
                        Location = "Copenhagen",
                        Date = new DateTime(2026, 9, 7),
                        URL = "https://www.novonordisk.com/careers.html"
                    },
                    new JobPosting
                    {
                        CompanyName = "Trifork",
                        Title = "Junior .NET Developer",
                        Description = "Build reliable web applications and APIs with C# and .NET",
                        Location = "Aarhus",
                        Date = new DateTime(2026, 9, 6),
                        URL = "https://www.trifork.com/careers"
                    },
                    new JobPosting
                    {
                        CompanyName = "Netcompany",
                        Title = "Backend Developer",
                        Description = "Work with a team to develop scalable backend services for public and private clients",
                        Location = "Copenhagen",
                        Date = new DateTime(2026, 9, 5),
                        URL = "https://www.netcompany.com/careers"
                    },
                    new JobPosting
                    {
                        CompanyName = "Systematic",
                        Title = "Software Developer",
                        Description = "Develop software solutions using modern .NET technologies and agile methods",
                        Location = "Aarhus",
                        Date = new DateTime(2026, 9, 4),
                        URL = "https://www.systematic.com/careers"
                    },
                    new JobPosting
                    {
                        CompanyName = "Vestas",
                        Title = "Graduate Software Engineer",
                        Description = "Help create digital tools that support the development of wind energy solutions",
                        Location = "Aarhus",
                        Date = new DateTime(2026, 9, 3),
                        URL = "https://careers.vestas.com/"
                    },
                    new JobPosting
                    {
                        CompanyName = "Bankdata",
                        Title = "Junior Full-Stack Developer",
                        Description = "Join a cross-functional team building secure banking applications and services",
                        Location = "Silkeborg",
                        Date = new DateTime(2026, 9, 2),
                        URL = "https://www.bankdata.dk/job-og-karriere"
                    }
                );
                context.SaveChanges();
            }
            
        }
        
    }
}