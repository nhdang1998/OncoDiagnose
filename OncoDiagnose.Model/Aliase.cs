using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OncoDiagnose.Models
{
    public class Aliase : BaseEntity
    {
        [Display(Name = "Tên aliases")]
        public string Name { get; set; }
        public List<GeneAliase> GeneAliases { get; set; }
    }
}