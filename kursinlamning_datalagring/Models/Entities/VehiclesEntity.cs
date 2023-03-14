using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace kursinlamning_datalagring.Models.Entities
{
    internal class VehiclesEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "char(6)")]
        public string CarRegistration { get; set; } = null!;

        [Required]
        [Column(TypeName = "char(4)")]
        public int YearOfMake { get; set; }

        public int CarOwnerId { get; set; }
        public CarOwnersEntity Owner { get; set; } = null!;

    }
}
