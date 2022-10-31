// See https://aka.ms/new-console-template for more information
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

Console.WriteLine(" *** Merhaba Katmanlı Mimari Projesine Hoşgeldiniz ***");


Color color1 = new Color() { ColorName = "Mavi" };
Color color2 = new Color() { ColorName = "Kırmızı" };

ColorManager colorManager = new ColorManager(new EfColorDal());
colorManager.Add(color1);
colorManager.Add(color2);
List<Color> colorList = colorManager.GetAll();
Console.WriteLine("****************  Sisteme Kayıtlı RENKLER Listeleniyor **********************");
foreach (var color in colorList)
{
    Console.WriteLine("Color Id : {0} , Color Name : {1} ", color.ColorId, color.ColorName);
}


Brand brand1 = new Brand() { BrandName="Toyota"};
Brand brand2 = new Brand() { BrandName = "Ranault" };

BrandManager brandManager = new BrandManager(new EfBrandDal());
brandManager.Add(brand1);
brandManager.Add(brand2);

Console.WriteLine("****************  Sisteme Kayıtlı MARKALAR Listeleniyor **********************");
foreach (var brand in brandManager.GetAll())
{
    Console.WriteLine("Marka ID : {0} , Marka Adı : {1}",brand.BrandId,brand.BrandName);
}


CarManager carManager = new CarManager(new EfCarDal());
Car car1 = new Car() { BrandId = 9, ColorId = 99, ModelYear = 2023, DailyPrice = 1453, Description = "Test " };
Car car2 = new Car() { BrandId = 5, ColorId = 88, ModelYear = 2008, DailyPrice = 15, Description = "26 / 10 / 2022 ikinci kayıt" };
carManager.Add(car1);
carManager.Add(car2);

Console.WriteLine("****************  Sisteme Kayıtlı Bütün Araçlar Listeleniyor **********************");

foreach (Car car in carManager.GetAll())
{
    Console.WriteLine("Araç ID:" + car.CarId + ", Araç Marka ID:" + car.BrandId + ", Araç Renk ID:" + car.ColorId + ", Araç Model Yılı:" + car.ModelYear + ", Araç Günlük Kiralama Bedeli" + car.DailyPrice + ", Açıklama:" + car.Description);
}

Console.WriteLine("****************  Sisteme Kayıtlı BrandId=9 Olan Araçlar Listeleniyor **********************");
foreach (Car car in carManager.GetCarsByBrandId(9))
{
    Console.WriteLine("Araç ID:"+car.CarId+", Araç Marka ID:"+car.BrandId + ", Araç Renk ID:" + car.ColorId + ", Araç Model Yılı:" + car.ModelYear + ", Araç Günlük Kiralama Bedeli" + car.DailyPrice + ", Açıklama:" + car.Description);
}

Console.WriteLine("****************  Sisteme Kayıtlı ColorID=88 Olan Araçlar Listeleniyor **********************");
foreach (Car car in carManager.GetCarsByColorId(88))
{
    Console.WriteLine("Araç ID:" + car.CarId + ", Araç Marka ID:" + car.BrandId + ", Araç Renk ID:" + car.ColorId + ", Araç Model Yılı:" + car.ModelYear + ", Araç Günlük Kiralama Bedeli" + car.DailyPrice + ", Açıklama:" + car.Description);
}


