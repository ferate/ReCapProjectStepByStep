using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
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
        IDataResult<List<Car>> GetAll();

        IDataResult<List<CarDetailDto>> GetCarDetails();

        IDataResult<List<Car>> GetCarsByBrandId(int BrandId);
        IDataResult<Car> GetById(int CarId);        

        IResult Add(Car car);

        IResult Update(Car car);

        IResult Delete(Car car);
        
        IResult TransactionalOperation(Car car);



    }
}
