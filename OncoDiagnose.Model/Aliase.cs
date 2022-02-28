using System.Collections.Generic;

namespace OncoDiagnose.Models
{
    public class Aliase : BaseEntity
    {
        public string Name { get; set; }
        public List<GeneAliase> GeneAliases { get; set; }
    }
}