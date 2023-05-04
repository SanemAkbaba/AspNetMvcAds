using AspNetMvcAds.Data.Entity.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetMvcAds.Data.Entity;

public class Page : AuditEntity
{
    [Column(TypeName = "nvarchar(200)")]
    public string? Title { get; set; }

    [Column(TypeName = "ntext")]
    public string? Content { get; set; }

    public bool IsActive { get; set; }
}