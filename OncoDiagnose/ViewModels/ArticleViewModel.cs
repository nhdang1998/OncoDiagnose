using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OncoDiagnose.Web.ViewModels
{
    public class ArticleViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Pmid { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Journal { get; set; }

        public string PubDate { get; set; }

        public string Volume { get; set; }

        public string Issue { get; set; }

        public string Pages { get; set; }

        [Required]
        public string Authors { get; set; }

        public string ElocationId { get; set; }
        public string Link { get; set; }

        [Required]
        public string Reference { get; set; }

        public string Abstract { get; set; }
        public List<MutationArticleViewModel> MutationArticleViewModels { get; set; }
    }
}