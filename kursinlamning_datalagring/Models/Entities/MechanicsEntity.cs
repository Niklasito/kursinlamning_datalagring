using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace kursinlamning_datalagring.Models.Entities
{
    [Index(nameof(Email), IsUnique = true)]
    internal class MechanicsEntity
        
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public string FirstName { get; set; } = null!;
        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public string LastName { get; set; } = null!;

        [Required]
        [Column(TypeName = "char(13)")]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Email { get; set; } = null!;
    }
}
