using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GraduateJobFinder.Models
{
    // Figure out if this is the correct way to make 'Name' unique - that is by adding an attribute to a class
    [Index(nameof(Name), IsUnique = true)]
    public class ProgrammingLanguage
    {
        public int Id { get; set; }

        public required string Name {get; set; }

        // Figure out why ' = new()' is needed
        public List<JobPosting> JobPostings { get; set; } = new();
    }
}