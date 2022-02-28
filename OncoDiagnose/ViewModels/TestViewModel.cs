using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OncoDiagnose.Web.ViewModels
{
    public class TestViewModel
    {
        public int Id { get; set; }

        [Required]
        public string TestName { get; set; }

        [Required]
        public int PatientId { get; set; }

        public PatientViewModel Patient { get; set; }

        [Required]
        public DateTime? TestDate { get; set; }

        public int RunId { get; set; }

        public RunViewModel Run { get; set; }
        public List<ResultViewModel> Results { get; set; }
    }
}