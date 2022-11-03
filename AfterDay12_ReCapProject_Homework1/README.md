# AfterDay12_ReCapProject_Homework1

Projeye Autofac Desteği ekleme : Business katmanına Manage Nuget Manager ile aşağıdaki paketleri yüklüyoruz.

![image](https://user-images.githubusercontent.com/32821105/199773434-72e9bb9b-6e3e-4d58-a06b-aba277f8a8d9.png)

Daha sonra yine Business katmanına
DependencyResolvers klasörünü onun altına da Autofac klasörünü oluşturuyoruz.Autofac klasörünün içine de AutofacBusinessModule.cs classını oluşturuyoruz.

![image](https://user-images.githubusercontent.com/32821105/199773540-e402682c-7415-488a-b6e8-5520c8dc348b.png)

WebAPI Program.cs dosyasına ekle ve çöz :
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacBusinessModule()));

![image](https://user-images.githubusercontent.com/32821105/199773669-347aea16-af7e-434a-b409-55925b78a263.png)


AfterDay12_ReCapProject_Homework1
