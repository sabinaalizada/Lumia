using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lumia.Models
{
    public class Team
    {
        public int Id { get; set; }
        [StringLength(maximumLength:50,MinimumLength =3)]
        public string Name { get; set; }
        [StringLength(maximumLength:150,MinimumLength =3)]
        public string? Desc { get; set; }
        [StringLength(maximumLength:150,MinimumLength =3)]
        public string? Twitter { get; set; }
        [StringLength(maximumLength:150,MinimumLength =3)]
        public string? Insta { get; set; }
        [StringLength(maximumLength:150,MinimumLength =3)]
        public string? Face { get; set; }
        [StringLength(maximumLength:150,MinimumLength =3)]
        public string? ImageUrl { get; set; }
        [Required]
        public int PositionId { get; set; }
        public Position? Position { get; set; }
        [NotMapped]
        public IFormFile? formFile { get; set; }

    }
}
