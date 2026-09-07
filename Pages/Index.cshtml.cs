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

    public IList<JobPosting> JobPostings { get; set; } = default!;

    public async Task OnGetAsync()
    {
        JobPostings = await _context.JobPosting.ToListAsync();
    }
}
