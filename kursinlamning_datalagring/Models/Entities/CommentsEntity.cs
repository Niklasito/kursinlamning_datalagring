using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace kursinlamning_datalagring.Models.Entities
{
    internal class CommentsEntity
    {
            [Key]
            public int Id { get; set; }

            [Required]
            [Column(TypeName = "nvarchar(200)")]
            public string Comment { get; set; } = null!;
            public DateTime DateCreated { get; set; } = DateTime.Now;

            public ErrorReportsEntity ErrorReportId { get; set; } = null!;
            public MechanicsEntity MechanicId { get; set; } = null!;

    }
}
