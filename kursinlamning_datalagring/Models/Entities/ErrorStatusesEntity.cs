using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace kursinlamning_datalagring.Models.Entities
{
    internal class ErrorStatusesEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(40)")]
        public string Status { get; set; } = null!;

        public ICollection<ErrorReportsEntity> ErrorReports { get; set; } = new HashSet<ErrorReportsEntity>();

    }

}
