using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcers.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        //[ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
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

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.DeleteSuccessful);
        }

        [CacheAspect(duration:10,Priority =1)]       
        [PerformanceAspect(5)]
        public IDataResult<List<Car>> GetAll()
        {
            // PerformanceAspect'i test etmek için fonksiyonu 500sn uyutuyoruz.
            //Thread.Sleep(5000);

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

        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int BrandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailsByBrandId(BrandId), Messages.ListedSuccessful);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int ColorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailsByColorId(ColorId), Messages.ListedSuccessful);
        }


        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandAndColorId(int brandId, int colorId)
        {
            if(brandId!=0 && colorId!=0)
            {
                return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailsByBrandAndColorId(brandId, colorId), Messages.ListedSuccessful);
            }
            else if(brandId != 0 && colorId == 0)
            {
                return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailsByBrandId(brandId), Messages.ListedSuccessful);
            }
            else if(brandId == 0 && colorId != 0)
            {
                return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailsByColorId(colorId), Messages.ListedSuccessful);
            }
            else
            {
                return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.ListedSuccessful);
            }
            
        }


        public IDataResult<List<CarDetailDto>> GetCarDetailsByCarId(int CarId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailsByCarId(CarId), Messages.ListedSuccessful);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int BrandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=>c.BrandId==BrandId),Messages.ListedSuccessful);
            
        }
        public IDataResult<List<Car>> GetCarsByColorId(int ColorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == ColorId),Messages.ListedSuccessful);

        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.UpdateSuccessful);
        }


        [TransactionScopeAspect]
        public IResult TransactionalOperation(Car car)
        {
            _carDal.Update(car);            
            // Add işleminde CarId gönderdiğimiz için hata veriyor
            // transactionı geri alıyor.
            //_carDal.Add(car);
            // Silme işlemi yapıldığında transaction başarılı oluyor.
            _carDal.Delete(car);
            return new SuccessResult(Messages.UpdateSuccessful);
        }

       
    }
}
