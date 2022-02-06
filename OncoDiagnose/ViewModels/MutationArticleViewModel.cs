namespace OncoDiagnose.Web.ViewModels
{
    public class MutationArticleViewModel
    {
        public int? ArticleId { get; set; }
        public ArticleViewModel Article { get; set; }
        public int? MutationId { get; set; }
        public MutationViewModel Mutation { get; set; }
    }
}
