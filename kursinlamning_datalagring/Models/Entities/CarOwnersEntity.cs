using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kursinlamning_datalagring.Models.Entities
{
    internal class CarOwnersEntity
    {
        [Key]
        public int Id { get; set; }

        [StringLength(40)]
        public string FirstName { get; set; } = null!;
        [Required]
        public int LastName { get; set; }

        [StringLength(30)]
        public string Email { get; set; } = null!;

        [Required]
        [Column(TypeName = "char(13)")]
        public string PhoneNumber { get; set; } = null!;

        public int VehicleId { get; set; }
        public VehiclesEntity Vehicle { get; set; } = null!;

        public ICollection<VehiclesEntity> Vehicles = new HashSet<VehiclesEntity>();
    }

}




