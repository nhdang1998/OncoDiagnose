using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OncoDiagnose.Models
{
    public class AssignedSynonyms
    {
        public int SynonymId { get; set; }
        public string SynonymName { get; set; }
        public bool IsAssigned { get; set; }
    }
}
