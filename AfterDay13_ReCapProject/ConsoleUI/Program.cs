// See https://aka.ms/new-console-template for more information
using Business.Concrete;
using Business.Constants;
using Core.Utilities.Results;
using Core.Utilities.Helpers.FileHelper;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;

Console.WriteLine(" *** Merhaba Katmanlı Mimari Projesine Hoşgeldiniz ***");

//ColorAddAndList();

//BrandAddAndList();

//CarAddAndList();

//UserAddAndList();

//CustomerAddAndList();

//RentalAddAndList();

//CustomerDetailList();


//RentalDetailList();

CarImageManager carImageManager = new CarImageManager(new EfCarImageDal(), new FileHelperManager());
CarImage carImage = new CarImage() { CarId=1006, Date=DateTime.Now, ImagePath= @"C:\Ensar1.jpg" };

//carImageManager.Add(, carImage);

//Console.WriteLine("****************  Sisteme Kayıtlı BrandId=9 Olan Araçlar Listeleniyor **********************");
//foreach (Car car in carManager.GetCarsByBrandId(9))
//{
//    Console.WriteLine("Araç ID:"+car.CarId+", Araç Marka ID:"+car.BrandId + ", Araç Renk ID:" + car.ColorId + ", Araç Model Yılı:" + car.ModelYear + ", Araç Günlük Kiralama Bedeli" + car.DailyPrice + ", Açıklama:" + car.Description);
//}

//Console.WriteLine("****************  Sisteme Kayıtlı ColorID=88 Olan Araçlar Listeleniyor **********************");
//foreach (Car car in carManager.GetCarsByColorId(88))
//{
//    Console.WriteLine("Araç ID:" + car.CarId + ", Araç Marka ID:" + car.BrandId + ", Araç Renk ID:" + car.ColorId + ", Araç Model Yılı:" + car.ModelYear + ", Araç Günlük Kiralama Bedeli" + car.DailyPrice + ", Açıklama:" + car.Description);
//}



static void ColorAddAndList()
{
    Color color1 = new Color() { ColorName = "Mavi" };
    Color color2 = new Color() { ColorName = "Kırmızı" };

    ColorManager colorManager = new ColorManager(new EfColorDal());
    colorManager.Add(color1);
    colorManager.Add(color2);
    IDataResult<List<Color>> colorList = colorManager.GetAll();
    Console.WriteLine("****************  Sisteme Kayıtlı RENKLER Listeleniyor **********************");
    foreach (var color in colorList.Data)
    {
        Console.WriteLine("Color Id : {0} , Color Name : {1} ", color.ColorId, color.ColorName);
    }
    Console.WriteLine(colorList.Message);
}

static void BrandAddAndList()
{
    Brand brand1 = new Brand() { BrandName = "Toyota" };
    Brand brand2 = new Brand() { BrandName = "Ranault" };

    BrandManager brandManager = new BrandManager(new EfBrandDal());
    brandManager.Add(brand1);
    brandManager.Add(brand2);

    Console.WriteLine("****************  Sisteme Kayıtlı MARKALAR Listeleniyor **********************");

    IDataResult<List<Brand>> brandList = brandManager.GetAll();

    foreach (var brand in brandList.Data)
    {
        Console.WriteLine("Marka ID : {0} , Marka Adı : {1}", brand.BrandId, brand.BrandName);
    }

    Console.WriteLine(brandList.Message);
}

static void CarAddAndList()
{
    Car car1 = new Car() { BrandId = 9, ColorId = 99, ModelYear = 2023, DailyPrice = 1453, Description = "Deneme" };
    Car car2 = new Car() { BrandId = 5, ColorId = 88, ModelYear = 2008, DailyPrice = 15, Description = "26 / 10 / 2022 ikinci kayıt" };

    CarManager carManager = new CarManager(new EfCarDal());
    carManager.Add(car1);
    carManager.Add(car2);

    Console.WriteLine("****************  Sisteme Kayıtlı Bütün Araçlar Listeleniyor **********************");

    IDataResult<List<Car>> carList = carManager.GetAll();
    foreach (Car car in carList.Data)
    {
        Console.WriteLine("Araç ID:" + car.CarId + ", Araç Marka ID:" + car.BrandId + ", Araç Renk ID:" + car.ColorId + ", Araç Model Yılı:" + car.ModelYear + ", Araç Günlük Kiralama Bedeli" + car.DailyPrice + ", Açıklama:" + car.Description);
    }
    Console.WriteLine(carList.Message);


    Console.WriteLine("****************  Sisteme Kayıtlı Araçlar Detaylarıyla Listeleniyor **********************");
    IDataResult<List<CarDetailDto>> carDetailList = carManager.GetCarDetails();

    foreach (var carDetail in carDetailList.Data)
    {
        Console.WriteLine("Car Name: {0}, Brand Name: {1}, Color Name: {2}, DailyPrice: {3}", carDetail.CarName, carDetail.BrandName, carDetail.ColorName, Convert.ToInt32(carDetail.DailyPrice));
    }
    Console.WriteLine(carDetailList.Message);
}

static void UserAddAndList()
{
    User newUser = new User() { FirstName = "Ferat", LastName = "EFİL", Email = "efilferat@hotmail.com", Password = "12345" };

    UserManager userManager = new UserManager(new EfUserDal());

    var firstList = userManager.GetAll();
    if (firstList.Data.Count == 0)
        Console.WriteLine(Messages.ListedFailed);

    userManager.Add(newUser);
    Console.WriteLine(Messages.SaveSuccessful);

    var userList = userManager.GetAll();
    foreach (var user in userList.Data)
    {
        Console.WriteLine("First Name: {0}, Last Name: {1}, Email: {2}", user.FirstName, user.LastName, user.Email);
    }
    Console.WriteLine(userList.Message);
}

static void CustomerAddAndList()
{
    CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

    Customer newCustomer = new Customer() { UserId = 1, CompanyName = "EFİL Yazılım" };
    var result = customerManager.Add(newCustomer);
    Console.WriteLine(result.Message);

    var customerList = customerManager.GetAll();

    foreach (var customer in customerList.Data)
    {
        Console.WriteLine("Customer UserId: {0}, Company Name: {1}", customer.UserId, customer.CompanyName);
    }
    Console.WriteLine(customerList.Message);
}

static void RentalAddAndList()
{
    RentalManager rentalManager = new RentalManager(new EfRentalDal());

    Rental newRentalforError = new Rental() { CarId = 1006, CustomerId = 1, RentDate = DateTime.Now, ReturnDate = (DateTime?)null };

    var resultSave = rentalManager.Add(newRentalforError);
    Console.WriteLine(resultSave.Message);

    Rental newRental = new Rental() { CarId = 1006, CustomerId = 1, RentDate = DateTime.Now, ReturnDate = DateTime.Now.AddDays(10) };

    var resultNewSave = rentalManager.Add(newRental);
    Console.WriteLine(resultNewSave.Message);

    var rentalList = rentalManager.GetAll();

    foreach (var rental in rentalList.Data)
    {
        Console.WriteLine("Rental Id: {0}, Car Id: {1}, Customer Id: {2}, Rent Date: {3}, ReturnDate: {4}", rental.Id, rental.CarId, rental.CustomerId, rental.RentDate, rental.ReturnDate);
    }
    Console.WriteLine(rentalList.Message);
}

static void CustomerDetailList()
{
    CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

    var resultCustomerDetailList = customerManager.GetCustomerDetails();

    foreach (var customer in resultCustomerDetailList.Data)
    {
        Console.WriteLine("Customer Id: {0}, User First Name: {1}, User Last Name: {2}, User Email: {3}, Company Name: {4}", customer.Id, customer.UserFirstName, customer.UserLastName, customer.UserEmail, customer.CompanyName);
    }
    Console.WriteLine(resultCustomerDetailList.Message);
}

static void RentalDetailList()
{
    RentalManager rentalManager = new RentalManager(new EfRentalDal());

    var resultRentalDetailList = rentalManager.GetRentalDetails();

    foreach (var rental in resultRentalDetailList.Data)
    {
        Console.WriteLine("Rental Id:{0},Car Brand:{1},Car Color:{2}, Car Description:{3}, Car Model Year:{4}, Custumor FirstName:{5}, Customer LastName:{6}, Customer Email:{7}, Rent Date:{8}, Return Date:{9}", rental.Id, rental.CarBrandName, rental.CarColorName, rental.CarDescription, rental.CarModelYear, rental.CustomerFirstName, rental.CustomerLastName, rental.CustomerEmail, rental.RentDate, rental.ReturnDate);
    }
    Console.WriteLine(resultRentalDetailList.Message);
}