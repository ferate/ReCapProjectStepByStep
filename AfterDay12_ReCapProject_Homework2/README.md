# AfterDay12_ReCapProject_Homework2

FluentValidation Desteği Ekleme :
Business Katmanına ValidationRules Klasörü oluştur, bunun altına FluentValidation klasörü oluştur daha sonra da bu klasörün içine CarValidator.cs dosyası oluşturup aşağıdaki şekildeki gibi yapılandıralım.

![image](https://user-images.githubusercontent.com/32821105/199797235-d4e1e1d8-6cab-4ea0-a8cf-51c6e75ebc42.png)


Eklediğimiz classa aşağıdaki örnekteki gibi kontroller yazıyoruz :

![image](https://user-images.githubusercontent.com/32821105/199797514-e9a9e287-9c6c-4d11-bfd4-d0bbe80d925c.png)


Validation’ı çalıştırmak için Manager’a giderek kontrole yönlendirme yapacağımız kodlarımızı şu şekilde yazıyoruz.

![image](https://user-images.githubusercontent.com/32821105/199797574-df869326-48b8-49c4-92c4-8b88b7eafa3a.png)


Bu yapı yani validation işlemi bütün katmanlarda yapılacağı için bunu Core Katmanına taşıyoruz.

Core katmanına bu paketleri yüklüyoruz.

![image](https://user-images.githubusercontent.com/32821105/199797638-2878914b-06fb-4848-9327-cc5b0374c7bb.png)

    Daha sonra Core projesine CrossCuttingConcers klasörünü ve onun altına Validation klasörünü oluşturuyoruz. 
Bunun altında da ValidationTool.cs dosyamızı oluşturup aşağıdaki gibi yapılandırıyoruz :

![image](https://user-images.githubusercontent.com/32821105/199797692-9f444ce7-a677-4cf0-990a-09da2d00192c.png)

![image](https://user-images.githubusercontent.com/32821105/199797730-6163fd64-ae88-467c-b0e4-2a0241286747.png)

İlgili Manager’a giderek eski yazdığımız kodu refactor ederek yeniden şu şekilde düzenliyoruz.

![image](https://user-images.githubusercontent.com/32821105/199797784-e5e36790-1f9a-4ef6-af59-e394154689d8.png)


AfterDay12_ReCapProject_Homework2
