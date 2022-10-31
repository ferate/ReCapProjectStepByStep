using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if(car.Description.Length>=2)
            {
                if (car.DailyPrice > 0)
                    _carDal.Add(car);
                else
                    Console.WriteLine("Günlük Kiralama Bedeli O TL den fazla olmalıdır");
            }
            else
            {
                Console.WriteLine("Araba açıklaması 2 karakterden küçük olamaz");
            }            
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public Car GetById(int CarId)
        {
            return _carDal.GetById(p=>p.CarId==CarId);
        }

        public List<Car> GetCarsByBrandId(int BrandId)
        {
            return _carDal.GetAll(c=>c.BrandId==BrandId);
            
        }
        public List<Car> GetCarsByColorId(int ColorId)
        {
            return _carDal.GetAll(c => c.ColorId == ColorId);

        }
        

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
