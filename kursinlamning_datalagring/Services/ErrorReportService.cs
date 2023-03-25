using kursinlamning_datalagring.Contexts;
using kursinlamning_datalagring.Models.Entities;
using kursinlamning_datalagring.Models.Forms;
using Microsoft.EntityFrameworkCore;


namespace kursinlamning_datalagring.Services
{
    internal class ErrorReportService
    {

        private static DataContext _context = new DataContext();

        public async Task<ErrorReportsEntity> CreateNewErrorReportIfNotExistsAsync(ErrorReport errorReport)
        {
           
            var existingErrorReport = await _context.ErrorReports
                .Include(x => x.Vehicle)
                .ThenInclude(x => x.CarOwner)
                .Include(x => x.ErrorStatus)
                .FirstOrDefaultAsync(x => x.Vehicle.CarRegistration == errorReport.CarRegistration
                 && x.ErrorDescription == errorReport.Description);

            if (existingErrorReport != null)
            {
                return existingErrorReport;
            }

            var carOwner = await _context.CarOwners
                .FirstOrDefaultAsync(x => x.Email == errorReport.Email);

            if (carOwner == null)
            {
                carOwner = new CarOwnersEntity
                {
                    FirstName = errorReport.FirstName,
                    LastName = errorReport.LastName,
                    Email = errorReport.Email,
                    PhoneNumber = errorReport.PhoneNumber
                };

                _context.CarOwners.Add(carOwner);
            }

            var vehicle = await _context.Vehicles
                .FirstOrDefaultAsync(x => x.CarRegistration == errorReport.CarRegistration);

            if (vehicle == null)
            {
                vehicle = new VehiclesEntity
                {
                    CarRegistration = errorReport.CarRegistration,
                    CarOwner = carOwner
                };

                _context.Vehicles.Add(vehicle);
            }

            var errorReportEntity = new ErrorReportsEntity
            {
                Datecreated = errorReport.DateCreated,
                ExpectedFinished = errorReport.ExpectedFinished,
                ErrorDescription = errorReport.Description,
                Vehicle = vehicle,
                StatusId = 1 //All new reports are automatically given a status id of 1, "inte påbörjad"
            };


            _context.ErrorReports.Add(errorReportEntity);
            await _context.SaveChangesAsync();

            return errorReportEntity;
        }

        //Function to fetch all available ErrorReports.
        public async Task<IEnumerable<ErrorReportsEntity>> GetAllErrorReportsAsync()
        {

            return await _context.ErrorReports.Include(x => x.Vehicle).ThenInclude(x => x.CarOwner).Include(x => x.ErrorStatus).Include(x => x.Comments).AsNoTracking().ToListAsync();


        }

        //Function to fetch single ErrorReport based on the car registration.
        public async Task<ErrorReport> GetSingleCarReportAsync(string carRegistration)
        {
            var errorReport =  _context.ErrorReports
                .Include(x => x.Vehicle)
                .ThenInclude(x => x.CarOwner)
                .Include(x => x.ErrorStatus)
                .Include(x => x.Comments)
                .AsNoTracking() 
                .FirstOrDefault(x => x.Vehicle.CarRegistration == carRegistration);

            if (errorReport == null)
            {
                return null;
            }


            return new ErrorReport
            {
                Id = errorReport.Id,
                DateCreated = errorReport.Datecreated,
                ExpectedFinished = errorReport.ExpectedFinished,
                Description = errorReport.ErrorDescription,
                FirstName = errorReport.Vehicle.CarOwner.FirstName,
                LastName = errorReport.Vehicle.CarOwner.LastName,
                Email = errorReport.Vehicle.CarOwner.Email,
                PhoneNumber = errorReport.Vehicle.CarOwner.PhoneNumber,
                CarRegistration = errorReport.Vehicle.CarRegistration,
                StatusId = errorReport.ErrorStatus.Id,
                Status = errorReport.ErrorStatus.Status,
                Comments = errorReport.Comments.Select(x => new CommentsForm
                {
                    Id = x.Id,
                    RepairComment = x.Comment,
                    CommentWasCreated = x.DateCreated
                }).ToList()


            };

        }

        public async Task CreateComment(string comments, int errorReportId)
        {
            var errorReport = await _context.ErrorReports.FindAsync(errorReportId);

            if (errorReport == null)
            {
                Console.WriteLine("Det finns ingen bil med matchande registreringsnummer!");
            }

            if(!string.IsNullOrEmpty (comments) )
            {
                var comment = new CommentsEntity
                {
                    Comment = comments,
                    ErrorReportId = errorReportId,
                };

                _context.Add(comment);
                await _context.SaveChangesAsync();
            }
        }
    }

}
