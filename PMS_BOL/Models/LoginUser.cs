using System.ComponentModel.DataAnnotations;

namespace PMS_BOL.Models
{
    public class LoginUser
    {
        [Required]
        public string userName { get; set; }
        [Required]
        public string password { get; set; }
        public string AccessToken { get; set; }
        public int companyID { get; set; }
        public string CompanyName { get; set; }
        public string nUgroup { get; set; }
    }
}