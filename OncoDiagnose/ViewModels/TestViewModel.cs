using System;
using System.Collections.Generic;

namespace OncoDiagnose.Web.ViewModels
{
    public class TestViewModel
    {
        public int Id { get; set; }

        public string TestName { get; set; }

        public int PatientId { get; set; }

        public PatientViewModel Patient { get; set; }

        public DateTime? TestDate { get; set; }

        public int RunId { get; set; }

        public RunViewModel Run { get; set; }
        public List<ResultViewModel> Results { get; set; }
    }
}