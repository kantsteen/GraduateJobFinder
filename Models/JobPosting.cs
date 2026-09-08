using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraduateJobFinder.Models
{
    public class JobPosting
    {
        public int Id { get; set; }
        public required string CompanyName { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Location { get; set; }

        [DataType(DataType.Date)]
        public required DateTime Date { get; set; }

        [Url]
        [DataType(DataType.Url)]
        public required string URL { get; set; }
    }
}