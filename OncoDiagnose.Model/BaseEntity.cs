using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace OncoDiagnose.Models
{
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [System.Text.Json.Serialization.JsonIgnore]
        [JsonIgnore]
        public int Id { get; set; }
    }
}
