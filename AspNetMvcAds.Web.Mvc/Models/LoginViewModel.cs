using System.ComponentModel.DataAnnotations;

namespace AspNetMvcAds.Web.Mvc.Models
{
    public class LoginViewModel    //Login işlemi için eklendi
    {
        [Required]
        public string? EmailAddressOrUsername { get; set; }

        [Required]
        public string? Password { get; set; }

        public bool RememberMe { get; set; }
      
    }
}
