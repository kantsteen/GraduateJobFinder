using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GraduateJobFinder.Data;
using GraduateJobFinder.Models;
using Microsoft.EntityFrameworkCore;
using Humanizer;
using System.ComponentModel.DataAnnotations;

namespace GraduateJobFinder.Pages_Postings
{
    public class CreateModel : PageModel
    {
        private readonly GraduateJobFinder.Data.GraduateJobFinderContext _context;

        public CreateModel(GraduateJobFinder.Data.GraduateJobFinderContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            IQueryable<string> allProgrammingLanguages = _context.ProgrammingLanguage.OrderBy(p => p.Name)
                                                                         .Select(p => p.Name);
            AllProgrammingLanguages = allProgrammingLanguages.AsNoTracking().ToList();
            return Page();
        }

        [BindProperty]
        public JobPosting JobPosting { get; set; } = default!;

        public List<string> AllProgrammingLanguages { get; set; } = [];

        [BindProperty]
        [Required(ErrorMessage = "Enter a programming language")]
        public string LanguageName { get; set; }

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (!String.IsNullOrWhiteSpace(LanguageName))
            {
                string language = LanguageName.Trim();

                var programmingLanguage = _context.ProgrammingLanguage.FirstOrDefault(p => p.Name == language);
                if (programmingLanguage == null)
                {
                    programmingLanguage = new ProgrammingLanguage() { Name = language };
                }

                JobPosting.ProgrammingLanguages.Add(programmingLanguage);
            }

            _context.JobPosting.Add(JobPosting);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
