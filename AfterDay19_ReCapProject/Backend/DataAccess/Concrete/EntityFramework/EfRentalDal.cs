using Core.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentContext>, IRentalDal
    {
        public List<Rental> GetRentalCarbyRentReturnDate(int carId, DateTime rentDate, DateTime returnDate)
        {
            using (CarRentContext context = new CarRentContext())
            {
                var result = from r in context.Rentals
                             where r.CarId == carId && ((rentDate >= r.RentDate && rentDate <= r.ReturnDate) || (returnDate >= r.RentDate && returnDate <= r.ReturnDate))                                      
                             select new Rental
                             {
                                 Id = r.Id,
                                 CarId= r.CarId,
                                 RentDate = (DateTime)r.RentDate,
                                 ReturnDate = (DateTime)r.ReturnDate
                             };

                return result.ToList();
            }
        }

        public List<RentalDetailDto> GetRentalDetails()
        {
            using (CarRentContext context = new CarRentContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars on r.CarId equals c.CarId
                             join cu in context.Customers on r.CustomerId equals cu.Id
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join cl in context.Colors on c.ColorId equals cl.ColorId
                             join u in context.Users on cu.UserId equals u.Id
                             select new RentalDetailDto
                             {
                                 Id = r.Id,
                                 CarBrandName = b.BrandName,
                                 CarColorName = cl.ColorName,
                                 CarDescription = c.Description,
                                 CarModelYear = c.ModelYear,
                                 CustomerFirstName = u.FirstName,
                                 CustomerLastName = u.LastName,
                                 CustomerEmail = u.Email,
                                 RentDate = (DateTime)r.RentDate,
                                 ReturnDate = (DateTime)r.ReturnDate
                             };
                
                return result.ToList();
            }
        }

       
    }
}
