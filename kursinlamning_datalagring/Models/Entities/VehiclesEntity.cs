using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace kursinlamning_datalagring.Models.Entities
{
    [Index(nameof(CarRegistration), IsUnique = true)]
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

        [Required]
        public int CarOwnerId { get; set; }
        public CarOwnersEntity CarOwner{ get; set; } = null!;

    }
}
