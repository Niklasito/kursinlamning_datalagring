using kursinlamning_datalagring.Contexts;
using kursinlamning_datalagring.Models.Entities;
using Microsoft.EntityFrameworkCore;
using kursinlamning_datalagring.Models.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursinlamning_datalagring.Services
{
    internal class CarOwnerService
    {
        private readonly DataContext _context = new DataContext();
        public async Task GetOrCreateCarOwnerIfNotExistsAsync(OwnerAndCar ownerAndCar)
        {
            var vehicleEntity = await _context.Vehicles.FirstOrDefaultAsync(x => x.CarRegistration == ownerAndCar.CarRegistration);
            var carOwnersEntity = await _context.CarOwners.FirstOrDefaultAsync(x => x.Email == ownerAndCar.Email);
            if (carOwnersEntity == null)
            {
                carOwnersEntity = new CarOwnersEntity()
                {
                    FirstName = ownerAndCar.FirstName,
                    
                    Email = ownerAndCar.Email,
                    PhoneNumber = ownerAndCar.PhoneNumber
                };

                _context.Add(carOwnersEntity);
                await _context.SaveChangesAsync();
            }

            if (vehicleEntity == null)
            {
                vehicleEntity = new VehiclesEntity()
                {
                    CarRegistration = ownerAndCar.CarRegistration,
                    YearOfMake = ownerAndCar.YearOfMake,
                };
            }
        }
        
        
    }
}

