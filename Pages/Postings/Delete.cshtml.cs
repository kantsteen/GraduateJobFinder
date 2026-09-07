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
    public class DeleteModel : PageModel
    {
        private readonly GraduateJobFinder.Data.GraduateJobFinderContext _context;

        public DeleteModel(GraduateJobFinder.Data.GraduateJobFinderContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobposting = await _context.JobPosting.FindAsync(id);
            if (jobposting != null)
            {
                JobPosting = jobposting;
                _context.JobPosting.Remove(JobPosting);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
