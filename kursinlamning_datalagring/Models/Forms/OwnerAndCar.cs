
using kursinlamning_datalagring.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace kursinlamning_datalagring.Models.Forms
{
    internal class OwnerAndCar
    {

            public string FirstName { get; set; } = null!;
    
            public int LastName { get; set; }
        
            public string Email { get; set; } = null!;

            public string PhoneNumber { get; set; } = null!;

            public string CarRegistration { get; set; } = null!;

            public int YearOfMake { get; set; }

        
    }
}
