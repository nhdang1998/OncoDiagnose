using System.Collections.Generic;

namespace OncoDiagnose.Models.AuthenticateAndAuthorize
{
    public class Laboratory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsAuthorized { get; set; }
        public List<TechnicianAdminUser> TechnicianAdminUser { get; set; }
    }
}