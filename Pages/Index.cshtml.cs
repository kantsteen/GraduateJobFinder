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

    public string NextDateSort { get; set; }

    public IList<JobPosting> JobPostings { get; set; } = default!;

    public async Task OnGetAsync(string sortOrder)
    {
        NextDateSort = sortOrder == "date_asc" ? "date_desc" : "date_asc";

        IQueryable<JobPosting> jobPostsIQ = _context.JobPosting;

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
