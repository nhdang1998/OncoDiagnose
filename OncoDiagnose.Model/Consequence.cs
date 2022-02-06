using System.Collections.Generic;

namespace OncoDiagnose.Models
{
    public class Consequence : BaseEntity
    {
        public string Term { get; set; }
        public bool IsGenerallyTruncating { get; set; }
        public string Description { get; set; }
        public List<Alteration> Alterations { get; set; }
    }
}