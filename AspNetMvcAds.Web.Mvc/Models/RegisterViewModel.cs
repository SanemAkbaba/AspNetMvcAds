using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetMvcAds.Web.Mvc.Models
{
    public class RegisterViewModel
    {      
        

        [Required]
        public string UserName { get; set; }


        [Required]
        public string Email { get; set; }   

        [Required]
        [Column(TypeName = "Nvarchar(8)")]
        public string Password { get; set; }    

        [Required]
        [Compare("Password")]
        [Column(TypeName ="Nvarchar(8)")]
        public string Password2 { get; set; }   


    }
}
