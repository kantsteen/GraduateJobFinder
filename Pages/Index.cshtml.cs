using GraduateJobFinder.Data;
using GraduateJobFinder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GraduateJobFinder.Pages;

public class IndexModel : PageModel
{
    private readonly GraduateJobFinderContext _context;

    public IndexModel(GraduateJobFinderContext context)
    {
        _context = context;
    }

    public string CurrentSort { get; set; } = "date_desc";
    public string NextDateSort { get; set; }
    public IList<JobPosting> JobPostings { get; set; } = default!;
    public List<string> ProgLangList = new List<string> {"Python", "C", "C++", "Java", "C#", "JavaScript", "Visual Basic",
                                 "SQL", "R", "Rust", "Fortran", "Go", "Delphi/Object Pascal", "PHP",
                                 "Scratch", "Assembly Language", "Ada", "Swift", "Objective-C", "COBOL",
                                 "TypeScript", "Kotlin", "Dart", "Ruby", "Lua", "Scala", "Elixir",
                                 "Julia", "Haskell", "Zig"};
    public List<string>? LanguageFilter { get; set; }

    public async Task OnGetAsync(string sortOrder, List<string>? programmingLanguages)
    {
        IQueryable<JobPosting> jobPostsIQ = _context.JobPosting;

        if (programmingLanguages != null && programmingLanguages.Count > 0)
        {
            jobPostsIQ = jobPostsIQ.Where(j => programmingLanguages.Any(language => j.Description.Contains(language)));
            LanguageFilter = programmingLanguages;
        }

        CurrentSort = sortOrder == "date_asc" ? "date_asc" : "date_desc";
        NextDateSort = sortOrder == "date_asc" ? "date_desc" : "date_asc";

        switch (sortOrder)
        {
            case "date_asc":
                jobPostsIQ = jobPostsIQ.OrderBy(j => j.Date);
                break;
            default:
                jobPostsIQ = jobPostsIQ.OrderByDescending(j => j.Date);
                break;
        }

        JobPostings = await jobPostsIQ.AsNoTracking().ToListAsync();
    }
}
