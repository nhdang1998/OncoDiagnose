using System.Collections.Generic;

namespace OncoDiagnose.Models
{
    public class CancerType : BaseEntity
    {
        public List<Mutation> Mutations { get; set; }
        public string Subtype { get; set; }
        public string Code { get; set; }
        public string Color { get; set; }
        public string MainType { get; set; }
        public int Level { get; set; }
        public string Tissue { get; set; }
        public string TumorForm { get; set; }
    }
}