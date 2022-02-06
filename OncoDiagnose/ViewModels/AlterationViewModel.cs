namespace OncoDiagnose.Web.ViewModels
{
    public class AlterationViewModel
    {
        public int Id { get; set; }


        public int? MutationId { get; set; }

        public MutationViewModel Mutation { get; set; }

        public string AlterationInformation { get; set; }


        public string Name { get; set; }


        public string RefResidues { get; set; }


        public int ProteinStart { get; set; }


        public int ProteinEnd { get; set; }


        public string VariantResidues { get; set; }

        public int? GeneId { get; set; }

        public GeneViewModel Gene { get; set; }

        public int? ConsequenceId { get; set; }

        public ConsequenceViewModel Consequence { get; set; }
    }
}