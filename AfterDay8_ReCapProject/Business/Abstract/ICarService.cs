using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();

        List<Car> GetCarsByBrandId(int BrandId);
        Car GetById(int CarId);        

        void Add(Car car);

        void Update(Car car);

        void Delete(Car car);

        

    }
}
