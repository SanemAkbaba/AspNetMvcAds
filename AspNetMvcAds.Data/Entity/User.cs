using AspNetMvcAds.Data.Entity.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetMvcAds.Data.Entity;

public class User : AuditEntity
{
    [Required]
    [Column(TypeName = "nvarchar(100)")]
    public string Name { get; set; }

    public string UserName { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(200)")]
    public string Email { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(100)")]
    public string Password { get; set; }

    [Column(TypeName = "nvarchar (200)")]
    public string? Address { get; set; }

    [Column(TypeName = "varchar(20)")]
    public string? Phone { get; set; }


    public string Roles { get; set; }

 

}