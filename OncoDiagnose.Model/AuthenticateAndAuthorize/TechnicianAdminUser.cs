using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace OncoDiagnose.Models.AuthenticateAndAuthorize
{
    public class TechnicianAdminUser : IdentityUser
    {
        [Required]
        public string Name { get; set; }

        public int? LaboratoryId { get; set; }

        public Laboratory Laboratory { get; set; }

        [NotMapped]
        public string Role { get; set; }
    }
}