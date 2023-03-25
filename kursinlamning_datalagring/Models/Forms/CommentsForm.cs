
namespace kursinlamning_datalagring.Models.Forms
{
    internal class CommentsForm
    {
        public int Id { get; set; }

        public string RepairComment { get; set; } = null!;

        public DateTime CommentWasCreated { get; set; } = DateTime.Now;

        public int ErrorReportId { get; set; }

        public string CarRegistrationNumber { get; set; } = null!;
    }
}
