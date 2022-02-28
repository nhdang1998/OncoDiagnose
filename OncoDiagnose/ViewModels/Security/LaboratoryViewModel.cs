using System.ComponentModel.DataAnnotations;

namespace OncoDiagnose.Web.ViewModels.Security
{
    public class LaboratoryViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public bool IsAuthorized { get; set; }
    }
}