using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduateJobFinder.Dtos
{
    public record JobPostingDto(
        int Id,
        string CompanyName,
        string Title,
        string Description,
        string Location,
        DateTime Date,
        string Url,
        List<JobPostingLanguageDto> programmingLanguages
    );
}