using kursinlamning_datalagring.Contexts;
using kursinlamning_datalagring.Models.Entities;
using kursinlamning_datalagring.Models.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;

namespace kursinlamning_datalagring.Services
{
    internal class MenuService
    {
        private readonly DataContext _context = new DataContext();

        private readonly ErrorReportService _errorReportService = new ErrorReportService();


        public async Task StartMenuInterface()
        {
            Console.Clear();
            Console.WriteLine(" -----Välkommen till Hjalles Bil AB-----");
            Console.WriteLine(" ----    En mekaniker nära dig      ----");
            Console.WriteLine(" -------------------------------------- ");
            Console.WriteLine("                                        ");
            Console.WriteLine("      1. Lämna in din bil hos oss       ");
            Console.WriteLine(" -------------------------------------- ");
            Console.WriteLine("      2. Se status på ditt ärende       ");
            Console.WriteLine(" -------------------------------------- ");
            Console.WriteLine("      3. Hantera bil (Personal)         ");
            Console.WriteLine(" -------------------------------------- ");
   
            Console.Write("\nVälj vad du vill göra ( 1-3 ): ");
            var choseMenuInstance = Console.ReadLine();

            switch (choseMenuInstance)
            {
                case "1":
                    await CreateErrorReport();
                    break;

               case "2":
                    await GetSpecificCar();
                    break;

                case "3":
                    await MechanicsMenu();
                    break;
            }

            Console.ReadKey();
            

        }


        private async Task CreateErrorReport()
        {
            var errorForm = new ErrorReport();

            Console.Clear();
            Console.Write("Skriv in ditt förnamn: ");
            errorForm.FirstName = Console.ReadLine() ?? string.Empty;
            Console.Write("Skriv in ditt efternamn: ");
            errorForm.LastName = Console.ReadLine() ?? string.Empty;
            Console.Write("Skriv in din epost: ");
            errorForm.Email = Console.ReadLine() ?? string.Empty;
            Console.Write("Skriv in ditt telefonnummer: ");
            errorForm.PhoneNumber = Console.ReadLine() ?? string.Empty;
            Console.Write("Skriv in ditt registreringsnummer: ");
            errorForm.CarRegistration = Console.ReadLine() ?? string.Empty;
            Console.Write("Skriv in din felbeskrivning: ");
            errorForm.Description = Console.ReadLine() ?? string.Empty;
            errorForm.StatusId = 1;

            await _errorReportService.CreateNewErrorReportIfNotExistsAsync(errorForm);
            Console.Clear();
            Console.WriteLine("Ditt ärende är nu skapat!");
            Console.WriteLine("\n Tryck på enter för att komma tillbaka till menyn.");
            Console.ReadKey();

        }
        
        private async Task GetSpecificCar()
        {
            Console.Clear();
            Console.Write("Skriv in ditt registreringsnummer för att söka efter din bil: ");
            var carRegistration = Console.ReadLine() ?? string.Empty;

            
            var carReport = await _errorReportService.GetSingleCarReportAsync(carRegistration);
           
            Console.Clear();
            Console.WriteLine($"Ditt registreringsnummer: {carReport.CarRegistration}");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine($"Din felbeskrivning: {carReport.Description}");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine($"Din status: {carReport.Status}");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine($"Dina kommentarer: ");
      
            foreach (var comment in carReport.Comments)
            {
                Console.WriteLine($"{comment.RepairComment}");
                Console.WriteLine($"Kommentaren skapades: {comment.CommentWasCreated}");
                Console.WriteLine("--------------------------------------------------------");
            }

            Console.WriteLine("\n Tryck på enter för att komma tillbaka till menyn.");
        }

        private async Task UpdateSpecificErrorReportStatus()
        {
          
            
            Console.WriteLine("Skriv in ett registreringnummer för att se/uppdatera statusen");
            
            var carRegistration = Console.ReadLine() ?? string.Empty;
            if (carRegistration == string.Empty)
            {
                Console.WriteLine("Du måste skriva in ett registreringsnummer");
                return;
            }

            

            var carReport = await _errorReportService.GetSingleCarReportAsync(carRegistration);
            Console.Clear();
            if(carReport == null)
            {
                Console.WriteLine("Fordonet finns inte i databasen");
            }
            Console.WriteLine($"Bilens ägare: {carReport.FirstName} {carReport.LastName}");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine($"\nBilens registreringsnummer: {carReport.CarRegistration}");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine($"\nBilens felbeskrivning: {carReport.Description}");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine($"\nBilens status: {carReport.Status}");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine($"\nKommentarer: ");
            foreach (var comment in carReport.Comments)
            {
                Console.WriteLine($"\n{comment.RepairComment} {comment.CommentWasCreated}");
                Console.WriteLine("--------------------------------------------------------");
            }
           
            var updatedStatus = await _context.ErrorReports
                .Include(x => x.ErrorStatus)
                .FirstOrDefaultAsync(x => x.Vehicle.CarRegistration == carRegistration);

            Console.WriteLine("\nVälj en ny status för bilen: ");
            Console.WriteLine("1. Ej påbörjad");
            Console.WriteLine("2. Under Reparation");
            Console.WriteLine("3. Reparationen klar\n");
            
            var statusId = Convert.ToInt32(Console.ReadLine() ?? string.Empty);

            updatedStatus.StatusId = statusId;
            _context.ErrorReports.Update(updatedStatus);
            _context.Entry(updatedStatus).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            Console.Clear();
            Console.WriteLine("\nStatusen är nu uppdaterad!");
            Console.WriteLine("\n Tryck på enter för att komma tillbaka till menyn.");

        }
        
        private async Task CommentOnAnErrorReportAsync()
        {


            Console.WriteLine("Skriv in ett registreringnummer för att lägga till en kommentar");

            var carRegistration = Console.ReadLine() ?? string.Empty;
            if (carRegistration == string.Empty)
            {
                Console.WriteLine("Du måste skriva in ett registreringsnummer");
                return;
            }

            var carReport = await _errorReportService.GetSingleCarReportAsync(carRegistration);
            if (carReport == null)
            {
                Console.WriteLine("Det finns inget ärende med det registreringsnumret");
                return;
            }

            Console.WriteLine("Skriv en kommentar:");
            var repairComment = Console.ReadLine() ?? "";

            var newComment = new CommentsEntity
            {
                Comment = repairComment,
                DateCreated = DateTime.Now,
                ErrorReportId = carReport.Id
            };

            _context.Comments.Add(newComment);
            await _context.SaveChangesAsync();


            Console.Clear();
            Console.WriteLine("Du har nu kommenterat ärendet.");
            Console.WriteLine("\n Tryck på enter för att komma tillbaka till menyn.");
        }


        private async Task GetAllErrorReports()
        {
            Console.Clear();
            
            var fetchReports = await _errorReportService.GetAllErrorReportsAsync();
            Console.WriteLine("Tillgängliga rapporter: ");
            foreach (var fetchReport in fetchReports)
            {
                Console.WriteLine("\n--------------------------------------------------------");
                Console.WriteLine($"Rapport id: {fetchReport.Id}");
                Console.WriteLine($"Ägare: {fetchReport.Vehicle.CarOwner.FirstName} {fetchReport.Vehicle.CarOwner.LastName}");
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine($"Registreringsnummer: {fetchReport.Vehicle.CarRegistration} ");
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine($"Felbeskrivning: {fetchReport.ErrorDescription} ");
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine($"Status: {fetchReport.ErrorStatus.Status} ");
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine($"Kommentarer: " );
                foreach (var comment in fetchReport.Comments) 
                {
                    Console.WriteLine($"\nKommentar skapad: {comment.DateCreated}");
                    Console.WriteLine($"{comment.Comment}");
                }
                Console.WriteLine("\n--------------------------------------------------------");

                

              
            }
            Console.WriteLine("\n Tryck på enter för att komma tillbaka till menyn.");
        }

        private async Task MechanicsMenu()
        {
            
             
            Console.Clear();
            Console.WriteLine(" ----        Hantera ärende         ----");
            Console.WriteLine(" -------------------------------------- ");
            Console.WriteLine("                                        ");
            Console.WriteLine("      1.     Se alla ärenden            ");
            Console.WriteLine(" -------------------------------------- ");
            Console.WriteLine("      2. Uppdatera status på ärende     ");
            Console.WriteLine(" -------------------------------------- ");
            Console.WriteLine("      3.   Kommentera ett ärende        ");
            Console.WriteLine(" -------------------------------------- ");
            Console.WriteLine("      4.   Återgå till förra menyn      ");
            Console.WriteLine(" -------------------------------------- ");

            Console.Write("\nVälj vad du vill göra ( 1-4 ): ");

            var choseMenuInstance = Console.ReadLine();

            switch (choseMenuInstance)
            {
                case "1":
                    await GetAllErrorReports();
                    break;

                case "2":
                    await UpdateSpecificErrorReportStatus();
                    break;

                case "3":
                    await CommentOnAnErrorReportAsync();
                    break;

                case "4":
                    await StartMenuInterface();
                    break;
            }
            Console.ReadKey();
        }


    }
 }



