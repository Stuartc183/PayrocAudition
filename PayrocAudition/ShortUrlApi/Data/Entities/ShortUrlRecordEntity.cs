using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShortUrlApi.Data.Entities
{
    public class ShortUrlRecordEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShortUrlRecordId { get; set; }
        [Required]
        [MaxLength(6)]
        public string UrlUniqueCode { get; set; } = string.Empty;
        [Required]
        [MaxLength(2048)]
        public string Url { get; set; } = string.Empty;
    }
}
