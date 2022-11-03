# AfterDay12_ReCapProject_Homework2

          FluentValidation Desteği Ekleme 
          Business Katmanına ValidationRules Klasörü oluştur, bunun altına FluentValidation klasörü oluştur daha sonra da bu klasörün içine CarValidator.cs dosyası 
oluşturup aşağıdaki şekildeki gibi yapılandıralım.


    ![image](https://user-images.githubusercontent.com/32821105/199796168-02b56618-858e-4c5d-9c0c-9fd17f323cb4.png)

Eklediğimiz classa aşağıdaki örnekteki gibi kontroller yazıyoruz :

    ![image](https://user-images.githubusercontent.com/32821105/199796242-6b2c4c10-8bb7-4b22-a06d-de62642d7bc3.png)

Validation’ı çalıştırmak için Manager’a giderek kontrole yönlendirme yapacağımız kodlarımızı şu şekilde yazıyoruz.

     ![image](https://user-images.githubusercontent.com/32821105/199796314-8e919023-3bd9-4343-a08b-9855023a2ca1.png)

Bu yapı yani validation işlemi bütün katmanlarda yapılacağı için bunu Core Katmanına taşıyoruz.

Core katmanına bu paketleri yüklüyoruz.

     ![image](https://user-images.githubusercontent.com/32821105/199796417-84041a2a-cf58-464b-ada6-9dfe3dcb9369.png)

        Daha sonra Core projesine CrossCuttingConcers klasörünü ve onun altına Validation klasörünü oluşturuyoruz. 
Bunun altında da ValidationTool.cs dosyamızı oluşturup aşağıdaki gibi yapılandırıyoruz :

     ![image](https://user-images.githubusercontent.com/32821105/199796550-f90c3bf8-bdcb-408e-9dc3-161d454becb6.png)

     ![image](https://user-images.githubusercontent.com/32821105/199796599-f9e652e8-2e51-4ad4-a105-f75990032b17.png)

İlgili Manager’a giderek eski yazdığımız kodu refactor ederek yeniden şu şekilde düzenliyoruz.

     ![image](https://user-images.githubusercontent.com/32821105/199796702-3fe77b05-3f2e-4801-95f8-67774bde3130.png)




AfterDay12_ReCapProject_Homework2
