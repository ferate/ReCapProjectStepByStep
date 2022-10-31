using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>()
            {
                new Car() { CarId = 1, BrandId = 1, ColorId=1, ModelYear=2020, DailyPrice=250, Description="İlk araba"},
                new Car() { CarId = 2, BrandId = 1, ColorId=2, ModelYear=2021, DailyPrice=350, Description="İkinci araba"},
                new Car() { CarId = 3, BrandId = 1, ColorId=3, ModelYear=2022, DailyPrice=450, Description="Üçüncü araba"},
                new Car() { CarId = 4, BrandId = 1, ColorId=4, ModelYear=2020, DailyPrice=280, Description="Dördüncü araba"},
                new Car() { CarId = 5, BrandId = 1, ColorId=5, ModelYear=2021, DailyPrice=370, Description=""},
                new Car() { CarId = 6, BrandId = 2, ColorId=1, ModelYear=2022, DailyPrice=260, Description=""},
                new Car() { CarId = 7, BrandId = 2, ColorId=2, ModelYear=2020, DailyPrice=345, Description=""},
                new Car() { CarId = 8, BrandId = 2, ColorId=3, ModelYear=2021, DailyPrice=450, Description=""},
                new Car() { CarId = 9, BrandId = 2, ColorId=4, ModelYear=2022, DailyPrice=560, Description=""},
                new Car() { CarId = 10, BrandId = 2, ColorId=5, ModelYear=2020, DailyPrice=350, Description=""}                
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carDelete = _cars.FirstOrDefault(c=>c.CarId == car.CarId);
            if (carDelete != null)
                _cars.Remove(carDelete);
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }

        public Car GetById(int carId)
        {
            return _cars.FirstOrDefault(c => c.CarId == carId);
        }

        public Car GetById(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.FirstOrDefault(c => c.CarId == car.CarId);
            if (carToUpdate != null)
            {
                carToUpdate.BrandId = car.BrandId;
                carToUpdate.ColorId = car.ColorId;
                carToUpdate.ModelYear = car.ModelYear;
                carToUpdate.DailyPrice = car.DailyPrice;
                carToUpdate.Description = car.Description;
            }
        }
    }
}
