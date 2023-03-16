using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kursinlamning_datalagring.Models.Entities
{
    [Index(nameof(Email), IsUnique = true)]
    internal class CarOwnersEntity
    {
        [Key]
        public int Id { get; set; }

        [StringLength(40)]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;

        [StringLength(50)]
        public string Email { get; set; } = null!;

        [Required]
        [Column(TypeName = "char(13)")]
        public string PhoneNumber { get; set; } = null!;


        public ICollection<VehiclesEntity> Vehicles = new HashSet<VehiclesEntity>();

    }

}




