using System;
using System.Collections.Generic;

namespace OncoDiagnose.Web.ViewModels
{
    public class AliaseViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<GeneAliaseViewModel> GeneAliases { get; set; }

        public static implicit operator AliaseViewModel(AlterationViewModel v)
        {
            throw new NotImplementedException();
        }
    }
}