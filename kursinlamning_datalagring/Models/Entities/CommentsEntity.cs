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
            [Column(TypeName = "nvarchar(max)")]
            public string Comment { get; set; } = null!;
            public DateTime DateCreated { get; set; }

            [Required]
            public int ErrorReportId { get; set; }
            public ErrorReportsEntity ErrorReport { get; set; } = null!;
            
        

    }
}
