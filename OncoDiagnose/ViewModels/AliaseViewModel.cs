using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OncoDiagnose.Web.ViewModels
{
    public class AliaseViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<GeneAliaseViewModel> GeneAliases { get; set; }
    }
}