using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GraduateJobFinder.Data;
using GraduateJobFinder.Models;
using System.ComponentModel.DataAnnotations;

// TODO understand this file better
namespace GraduateJobFinder.Pages_Postings
{
    public class EditModel : PageModel
    {
        private readonly GraduateJobFinder.Data.GraduateJobFinderContext _context;

        public EditModel(GraduateJobFinder.Data.GraduateJobFinderContext context)
        {
            _context = context;
        }

        [BindProperty]
        public JobPosting JobPosting { get; set; } = default!;

        public List<string> AllProgrammingLanguageNames { get; set; } = [];

        [BindProperty]
        [Required(ErrorMessage = "Enter a programming language")]
        public string LanguageName { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobPosting = await _context.JobPosting.Include(j => j.ProgrammingLanguages).FirstOrDefaultAsync(j => j.Id == id);
            if (jobPosting == null)
            {
                return NotFound();
            }

            await LoadAllProgrammingLanguageNamesAsync();

            JobPosting = jobPosting;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            await LoadAllProgrammingLanguageNamesAsync();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var jobPosting = await _context.JobPosting
                .Include(j => j.ProgrammingLanguages)
                .FirstOrDefaultAsync(j => j.Id == JobPosting.Id);

            if (jobPosting == null)
            {
                return NotFound();
            }

            if (!String.IsNullOrWhiteSpace(LanguageName))
            {
                string language = LanguageName.Trim();

                var alreadyAdded = jobPosting.ProgrammingLanguages
                    .Any(programmingLanguage => programmingLanguage.Name == language);

                if (alreadyAdded)
                {
                    ModelState.AddModelError(
                        nameof(LanguageName),
                        $"'{language}' is already added to this job posting."
                        );
                    return Page();
                }

                var programmingLanguage = await _context.ProgrammingLanguage
                    .FirstOrDefaultAsync(p => p.Name == language);
                if (programmingLanguage == null)
                {
                    programmingLanguage = new ProgrammingLanguage() { Name = language };
                }

                jobPosting.ProgrammingLanguages.Add(programmingLanguage);
            }

            // TODO understand this line better
            _context.Entry(jobPosting).CurrentValues.SetValues(JobPosting);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobPostingExists(JobPosting.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPostRemoveLanguageAsync(string languageToRemove)
        {
            var jobPosting = await _context.JobPosting
                .Include(j => j.ProgrammingLanguages)
                .FirstOrDefaultAsync(j => j.Id == JobPosting.Id);

            if (jobPosting == null)
            {
                return NotFound();
            }

            if (!String.IsNullOrWhiteSpace(languageToRemove))
            {
                var programmingLanguage = jobPosting.ProgrammingLanguages.FirstOrDefault(p => p.Name == languageToRemove);

                // If the job posting has no language equal to languageToRemove, programmingLanguage is null
                if (programmingLanguage != null)
                {
                    jobPosting.ProgrammingLanguages.Remove(programmingLanguage);
                    await _context.SaveChangesAsync();
                }
            }

            return RedirectToPage(new {id = JobPosting.Id});
        }

        private async Task LoadAllProgrammingLanguageNamesAsync()
        {
            AllProgrammingLanguageNames = await _context.ProgrammingLanguage
                .OrderBy(programmingLanguage => programmingLanguage.Name)
                .Select(programmingLanguage => programmingLanguage.Name)
                .AsNoTracking()
                .ToListAsync();
        }

        private bool JobPostingExists(int id)
        {
            return _context.JobPosting.Any(e => e.Id == id);
        }
    }
}
