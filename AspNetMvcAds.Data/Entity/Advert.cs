using AspNetMvcAds.Data.Entity.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetMvcAds.Data.Entity
{
    public class Advert : AuditEntity
    {
        [Required]
        public int? UserId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string? Title { get; set; }

        [Column(TypeName = "ntext")]
        public string? Description { get; set; }

        public bool IsTrend { get; set; } = false;

        public string? Location { get; set; }


        // Navigation Properties

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public List<AdvertComment> AdvertComments { get; set; } = new List<AdvertComment>();

        public List<AdvertImage> AdvertImages { get; set; } = new List<AdvertImage>();
    }
}