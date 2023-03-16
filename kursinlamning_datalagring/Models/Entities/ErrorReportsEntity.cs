using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace kursinlamning_datalagring.Models.Entities
{
    internal class ErrorReportsEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime Datecreated { get; set; }

        public DateTime ExpectedFinished { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(30)")]

        public string ErrorDescription { get; set; } = null!;

        public ICollection<CommentsEntity> Comments { get; set; } = new HashSet<CommentsEntity>();
        public VehiclesEntity Vehicle { get; set; } = null!;
        public int StatusId { get; set; }
        public ErrorStatusesEntity ErrorStatus { get; set; } = null!;
    }

}
