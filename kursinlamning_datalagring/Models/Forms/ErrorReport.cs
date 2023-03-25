using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursinlamning_datalagring.Models.Forms
{
    internal class ErrorReport
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string CarRegistration { get; set; } = null!;
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime ExpectedFinished { get; set; } = DateTime.Now.AddDays(10);
        public string Description { get; set; } = null!;
        public int StatusId { get; set; }
        public string Status { get; set; } = null!;
        public ICollection<CommentsForm> Comments { get; set; } = new HashSet<CommentsForm>();
    }

}
