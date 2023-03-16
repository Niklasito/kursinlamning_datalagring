using kursinlamning_datalagring.Contexts;
using kursinlamning_datalagring.Models.Entities;
using kursinlamning_datalagring.Models.Forms;
using Microsoft.EntityFrameworkCore;


namespace kursinlamning_datalagring.Services
{
    internal class ErrorReportService
    {

        private static DataContext _context = new DataContext();

        public async Task GetOrCreateIfNotExistsRepportAsync(ErrorReport errorReport)
        {

            var errorReportsEntity = await _context.ErrorReports.FirstOrDefaultAsync(x => x.Id == errorReport.Id);
            if
            {
                Datecreated = errorReport.DateCreated,
                ExpectedFinished = errorReport.ExpectedFinished,
                ErrorDescription = errorReport.Description,
            };

            var vehiclesEntity = await _context.Vehicles.FirstOrDefaultAsync(x => x.CarRegistration == errorReport.CarRegistration);
            if (vehiclesEntity != null)
                
            else
                veniclesEntity = new VehiclesEntity()
                {
                    CarRegistration = errorReport.CarRegistration,
                    YearOfMake = errorReport.YearOfMake,
                };
            }


            var vehiclesEntity = new VehiclesEntity
            {
                CarRegistration = errorReport.CarRegistration,
                YearOfMake = errorReport.YearOfMake,

            };
            if()
            vehiclesEntity.CarOwner = new CarOwnersEntity
            {
                FirstName = errorReport.FirstName,
                LastName = errorReport.LastName,
                Email = errorReport.Email,
                PhoneNumber = errorReport.PhoneNumber
            };
            var errorReportsEntity = new ErrorReportsEntity
            {
                Datecreated = errorReport.DateCreated,
                ExpectedFinished = errorReport.ExpectedFinished,
                ErrorDescription = errorReport.Description,
            };
            


          
        }
            


        }

        }
        

    }
}
