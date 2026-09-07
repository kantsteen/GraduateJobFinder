using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GraduateJobFinder.Data;
using GraduateJobFinder.Models;

namespace GraduateJobFinder.Pages_Postings
{
    public class IndexModel : PageModel
    {
        private readonly GraduateJobFinder.Data.GraduateJobFinderContext _context;

        public IndexModel(GraduateJobFinder.Data.GraduateJobFinderContext context)
        {
            _context = context;
        }

        public IList<JobPosting> JobPosting { get;set; } = default!;

        public async Task OnGetAsync()
        {
            JobPosting = await _context.JobPosting.ToListAsync();
        }
    }
}
