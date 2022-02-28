using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace OncoDiagnose.Web.ViewModels
{
    public class RunViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Status { get; set; }

        [BindProperty]
        [Required]
        public DateTime FinishDate { get; set; }

        public string TotalBase { get; set; }

        public string KeySignal { get; set; }

        public int TotalRead { get; set; }

        public double UsableRead { get; set; }

        public double MeanLength { get; set; }

        public int MedianLength { get; set; }

        public int ModeLength { get; set; }
        public string ISPLoading { get; set; }

        public string PolyClonal { get; set; }

        public int LowQuality { get; set; }

        [Required]
        public int Score { get; set; }

        public string ISPLoadingPic { get; set; }

        public string QualityPic { get; set; }

        public string LengthPic { get; set; }

        public TestViewModel Test { get; set; }
    }
}