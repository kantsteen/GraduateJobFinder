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
    public class DetailsModel : PageModel
    {
        private readonly GraduateJobFinder.Data.GraduateJobFinderContext _context;

        public DetailsModel(GraduateJobFinder.Data.GraduateJobFinderContext context)
        {
            _context = context;
        }

        public JobPosting JobPosting { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobposting = await _context.JobPosting.FirstOrDefaultAsync(m => m.Id == id);

            if (jobposting is not null)
            {
                JobPosting = jobposting;

                return Page();
            }

            return NotFound();
        }
    }
}
