## Rovers.Dal katmanında RoversContext classında bulunan DB bağlantı cümleciğini kendi local DB bağlantımızı yazacak şekilde güncelleyelim.
## Rovers.Dal katmanı içerisinde Package Manager Console üzerinden Local DB'mizde database'imizi oluşturacak update-database komutunu çalıştıralım.
## Rovers.WebService ve Rovers.UI projeleri ayrı ayrı çalıştırılmalı ve Rovers.UI arayüzü ile devam edebilir.

## Rovers.UI katmanında proje çalıştırıldığında Arayüzümüzde 4 input içerinde bilgiler istenmektedir ve Her inputun içerisi doldurulmak zorundadır.

##  X: Bulunduğu x koordinatı
##  Y: Bulunduğu y koordinatı
##  YÖN : Başlangıçta Rover'ın hangi yöne doğru hareket halinde olduğunu belirtiyoruz.(S:Güney,N:Kuzey,W:Batı,E:Doğu)
##  Komutlar : Hangi yönlere doğru hareket edeceğini belirtiyoruz.

##  Kaydetdikten sonra dönen sonuçta 3 değer dönecektir.
##  X: En son bulunduğu x koordinatı
##  Y: En son bulunduğu y koordinatı
##  YÖN: işlem sonucundaki yönü