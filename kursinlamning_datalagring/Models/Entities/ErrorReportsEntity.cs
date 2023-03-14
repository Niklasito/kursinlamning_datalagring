using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace kursinlamning_datalagring.Models.Entities
{
    internal class ErrorReportsEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime Datecreated { get; set; } = DateTime.Now;

        public DateTime ExpectedFinished { get; set; } = DateTime.Now.Add(14);

        [Required]
        [Column(TypeName = "nvarchar(30)")]

        public string ErrorDescription { get; set; } = null!;

        public VehiclesEntity VehicleId { get; set; } = null!;

        public ErrorStatusesEntity ErrorStatusId { get; set; } = null!;
    }

}
