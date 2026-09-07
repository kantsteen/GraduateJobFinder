using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GraduateJobFinder.Models;

namespace GraduateJobFinder.Data
{
    public class GraduateJobFinderContext : DbContext
    {
        public GraduateJobFinderContext (DbContextOptions<GraduateJobFinderContext> options)
            : base(options)
        {
        }

        public DbSet<GraduateJobFinder.Models.JobPosting> JobPosting { get; set; } = default!;
    }
}
