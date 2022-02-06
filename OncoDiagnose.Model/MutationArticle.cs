namespace OncoDiagnose.Models
{
    public class MutationArticle
    {
        public int? ArticleId { get; set; }
        public Article Article { get; set; }
        public int? MutationId { get; set; }
        public Mutation Mutation { get; set; }
    }
}