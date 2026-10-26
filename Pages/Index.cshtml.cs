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
    public string NextDateSort { get; set; } = "date_asc";
    public IList<JobPosting> JobPostings { get; set; } = default!;
    public List<string> AllProgrammingLanguages { get; set; } = [];
    public List<string>? LanguageFilter { get; set; }

    public async Task OnGetAsync(string sortOrder, List<string>? programmingLanguages)
    {
        // Include the ProgrammingLanguages property so the values in that property are included in the query
        IQueryable<JobPosting> jobPostsIQ = _context.JobPosting.Include(j => j.ProgrammingLanguages);
        IQueryable<string> allProgrammingLanguages = _context.ProgrammingLanguage
                                                            .OrderBy(language => language.Name)
                                                            .Select(language => language.Name);

        if (programmingLanguages != null && programmingLanguages.Count > 0)
        {
            LanguageFilter = programmingLanguages;

            // SQLite is case sensitive and the name values in the ProgrammingLanguages property in each JobPosting object is in lower case. 
            // Therefore the incoming list of programmingLanguages values should be converted to lower-case before filtering 
            programmingLanguages = programmingLanguages.ConvertAll(language => language.ToLower());


            // Filter job postings where for each job posting if any of its programming languages 
            // is in the list of languages being filtered for it is returned
            jobPostsIQ = jobPostsIQ.Where(j => j.ProgrammingLanguages
                                   .Any(postingLanguage => programmingLanguages.Contains(postingLanguage.Name)));


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

        AllProgrammingLanguages = await allProgrammingLanguages.AsNoTracking().ToListAsync();
        JobPostings = await jobPostsIQ.AsNoTracking().ToListAsync();
    }
}
