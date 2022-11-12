using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcers.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
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

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            /* Bu yapı yani validation işlemi bütün katmanlarda yapılacağı için 
             * bunu Core Katmanına taşıyoruz.
            var context = new ValidationContext<Car>(car);
            CarValidator carValidator = new CarValidator();
            var result = carValidator.Validate(context);
            if(!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            */

            //Yukarıdaki kodu kaldırıp Core katmanına taşıyarak tek satır haline getiriyoruz.
            // ValidationTool.Validate(new CarValidator(),car);
            // Yukarıdaki kod Core katmanına eklediğimiz
            // Aspect\Autofac\Validation\ValidationAspect kodunda sonra kaldırılmıştır.Refactor edilmiştir.


            _carDal.Add(car);
            return new SuccessResult(Messages.SaveSuccessful);

            /* Validation Desteği Eklendiği İçin Bu Kısım Kaldırılmıştır.
            if(car.Description.Length>=2)
            {
                if (car.DailyPrice > 0)
                {
                    _carDal.Add(car);
                    return new SuccessResult(Messages.SaveSuccessful);
                }                    
                else
                {
                    Console.WriteLine("Günlük Kiralama Bedeli O TL den fazla olmalıdır");
                    Console.WriteLine(Messages.SaveFailed);
                    return new ErrorResult(Messages.SaveFailed);
                }
                    
            }
            else
            {
                Console.WriteLine(Messages.SaveFailed);
                Console.WriteLine("Araba açıklaması 2 karakterden küçük olamaz");
                return new ErrorResult(Messages.SaveFailed);
            }     
            */

        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.DeleteSuccessful);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.ListedSuccessful);
        }

        public IDataResult<Car> GetById(int CarId)
        {
            return new SuccessDataResult<Car>(_carDal.GetById(p=>p.CarId==CarId),Messages.ListedSuccessful);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),Messages.ListedSuccessful);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int BrandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=>c.BrandId==BrandId),Messages.ListedSuccessful);
            
        }
        public IDataResult<List<Car>> GetCarsByColorId(int ColorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == ColorId),Messages.ListedSuccessful);

        }
        

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.UpdateSuccessful);
        }
    }
}
