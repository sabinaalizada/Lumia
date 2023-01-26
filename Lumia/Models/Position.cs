using System.ComponentModel.DataAnnotations;
namespace Lumia.Models
{
    public class Position
    {
        public int Id { get; set; }
        [StringLength(maximumLength:50,MinimumLength =3)]
        public string Name { get; set; }
    }
}
