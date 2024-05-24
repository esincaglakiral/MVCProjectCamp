# MVCSÖZLÜK PROJESİ

Bu proje Murat Yücedağ'ın Youtube'da ücretsiz olarak yayınladığı MVC Proje Kampı eğitimi ile oluşturulmuştur. 
Ekşi sözlükten ilham alınarak oluşturulan MVC Sözlük projesinde sisteme giriş yapan kullanıcıların yazar, genel kullanıcı ve admin olarak 3 farklı rolü bulunmaktadır.

Genel kullanıcıların erişebileceği bir Vitrin Paneli mevcuttur. Bu panelden tüm başlıklara ve o başlıklar ile alakalı yazılan tüm entry'lere ulaşabilirler. 
Yazarların bir giriş sayfası mevcuttur. Buradan giriş yapıp kendi panelleri üzerinde çeşitli işlemler yapabilirler.
Admin ise sistemin tamamına hakimdir. Kendi panelinden tüm işlemlere erişim sağlayabilir.

Eğitimin playlistine erişmek için => https://www.youtube.com/playlist?list=PLKnjBHu2xXNNQJehhCg--CzQQMHXTsFAb

## Kullanılan Araçlar & Mimari & Teknolojiler

- N Katmanlı Mimari
  - Business, DataAccess, Entity ve UI katmanlarından oluşmaktadır.
- Nesne Yönelimli(OOP Tabanlı) Programlama
- Generic Repository Tasarım Deseni
- Authentication & Authorization
- Data Annotations ile Front-End Validasyonlar
- Code First Yaklaşımı
- Fluent Validation ile Validasyon Kuralları
- Bootstrap ile Tema Giydirme
- JavaScript
- Context Kullanımı
- ASP.NET Core Identity
- Session ile Kullanıcı Bilgilerini Çekme
- Session Allow Anonymous
- Entity State Komutları
- Add Migrations ile Veri Tabanı Güncelleme
- ErrorPage 404
- SOLİD Prensibine uygun mimari ve kod düzeni
- LINQ
- PagedList
-----------------------------------------------------------------------------------------------
## Linkedin Profilim  => https://www.linkedin.com/in/esincaglakiral/

-----------------------------------------------------------------------------------------------
## Proje Görselleri ve Açıklamalar
-----------------------------------------------------------------------------------------------
### Admin Paneli
#### Vitrin Tema: Bu kısıma tüm kullanıcılar erişebilmektedir ve görüldüğü gibi yandaki Sidebardan tüm başlıklara erişebilir ve başlıklarla alakalı yazılan yazan tüm yazarların entrylerini görüntüleyebilir.
![vitrin1](https://github.com/esincaglakiral/MVCProjectCamp/assets/68962573/30b396c4-2276-4870-9d53-b8bbbfc367a9)

![vitrin2](https://github.com/esincaglakiral/MVCProjectCamp/assets/68962573/63b5fc66-6573-4bb5-9d75-e0ffc598fc84)

-----------------------------------------------------------------------------------------------

#### Giriş Panelleri : Buradan yazarlar ve Adminler için giriş panelleri belirtirmiştir. Yanlış bilgi girilmesi halinde hata mesajı verir ve tekrar denemeniz gerekir. Doğru girişte ise panele yönlendirilirsiniz.

![admin girişi](https://github.com/esincaglakiral/MVCProjectCamp/assets/68962573/50a687ad-d091-4989-b23b-4417262c1dac)

![yazar girişi](https://github.com/esincaglakiral/MVCProjectCamp/assets/68962573/4b4e3bc8-2ea8-4ca7-945c-1dabbba09baf)

-----------------------------------------------------------------------------------------------
#### Admin Paneli Kategori: Admin kategori sayfasından tüm kategoriler ile alakalı CRUD işlemleri yapabilir ve kategorilere ait ilgili başlıklara yönlendirilebilirsiniz.
![admin kategori](https://github.com/esincaglakiral/MVCProjectCamp/assets/68962573/6a675142-c4d2-410a-b72a-788b0006e444)

-----------------------------------------------------------------------------------------------
#### Admin Paneli Başlıklar: Admin tüm başlıklara erişim sağlayabilir, başlıklara ait yazarları, kategorileri görebilir. Kategoriler kısmı için koşullu renklendirme işlemi yapılmıştır. İçerikler Butonuna tıkladığınızda O başlığa ait tüm içeriklerin bulunduğu sayfaya gidebilirsiniz. Düzenle Butonundan Başlığı düzenleyebilir, Arşivle Butonundan ise Başlığı tamamen silmek yerine ya arşivlersiniz ya da yayınlarsınız. Burada PagedList yapısı kullanılmıştır ve alttaki sayfa numaralarından ilerleyebilirsiniz.

![admin başlıklar](https://github.com/esincaglakiral/MVCProjectCamp/assets/68962573/c3b41b63-f063-4bb4-949e-bd10085d8539)

![Başlık düzenleme](https://github.com/esincaglakiral/MVCProjectCamp/assets/68962573/3e5713e4-90cb-42cd-90c8-296475ddbf07)

![başlıklardan bazıları arşivlendi](https://github.com/esincaglakiral/MVCProjectCamp/assets/68962573/38e8e77d-f557-4598-8a5b-13b2eedc44b8)

![İlgili başlığa tıklayınca](https://github.com/esincaglakiral/MVCProjectCamp/assets/68962573/b0f3e880-943d-494d-9863-7f3df0f9914d)

-----------------------------------------------------------------------------------------------
#### Admin Paneli Yazarlar: Admin buradan tüm yazarları görüntüleyebilir. Yazarın Başlıkları butonuna tıklayınca Yazara ait (yazarın oluşturduğu) başlıklara erişebilirsiniz. Profili düzenle butonundan ise yazarın bilgilerini düzenleyebilirsiniz. Ek olarak tüm CRUD  İşlemlerini yapabilirsiniz. Burada PagedList yapısı kullanılmıştır ve alttaki sayfa numaralarından ilerleyebilirsiniz.

![admin yazarlar](https://github.com/esincaglakiral/MVCProjectCamp/assets/68962573/041ed973-c56e-4f92-a079-6b3068a5f19b)

![yazar bilgilerini düzenleme](https://github.com/esincaglakiral/MVCProjectCamp/assets/68962573/5c9bab93-d1eb-4c38-9fd1-841dd67ed346)

-----------------------------------------------------------------------------------------------
#### Admin Paneli İstatistikler ve Grafikler Kısmı

![istatistik admin](https://github.com/esincaglakiral/MVCProjectCamp/assets/68962573/f2320895-3354-4423-9502-f5422799a460)

![admin chart](https://github.com/esincaglakiral/MVCProjectCamp/assets/68962573/67cada2a-c804-41b0-a4df-a37950a3ed68)

-----------------------------------------------------------------------------------------------
#### Admin Paneli Hakkımızda

![hakkımızda admin](https://github.com/esincaglakiral/MVCProjectCamp/assets/68962573/18349c66-b1cf-4a1d-b389-00e695ff9253)

-----------------------------------------------------------------------------------------------
#### Admin Paneli Mesajlar & İletişim Mail Sayfası: Bence projenin en etkili ve önemli kısımlarından birisi bu sayfadır. Burada tıpkı gerçek bir mailleşme gibi kullanıcılar (Admin Yazarlar ve genel kullanıcılar) arasında mailleşme işlemi yapılabilmektedir. Mesela İletişim mesajları kısmında admine dışarıdan (genel kullanıcı) gelen mailler görüntülenmektedir. Admin mesaj detayına tıklayıp mesajın tam halini görebilir, dilerse silebilir, veya bulunduğu sayfaya geri dönebilir. Aynı şekilde admin Kendisine Yazarlar tarafından gelen mailleri de Gelen mesajlar kısmından görüntüleyebilir. Ya da yazarlara gönderdiği maillere Gönderilen mesajlardan ulaşabilir (yeni mesaj oluştur butonundan yazarlara mail gönderebilir. Böylece aslında iki panel arasında mailleşme sağlanmış olur) ve üzerinde silme (checkbox ile toplu silme) gibi işlemleri yapabilir. Dinamik bir sistemdir. Yapılan işlem hemen ekrana düşmektedir. 

![admin mesaj sayfası iletişim](https://github.com/esincaglakiral/MVCProjectCamp/assets/68962573/e318ce8e-6752-42e2-aba6-7e8e17f95f6d)

![iletişim mesaj detayı](https://github.com/esincaglakiral/MVCProjectCamp/assets/68962573/e5376a6a-79bd-41cd-b06d-aafdac1d29ec)

![Admin gelen mesajlar](https://github.com/esincaglakiral/MVCProjectCamp/assets/68962573/66bb46de-83c1-4505-9518-43ccfed995ae)

![gönderilen mesajlar](https://github.com/esincaglakiral/MVCProjectCamp/assets/68962573/5e1cf20f-2364-4113-9161-09e511160a78)

![toplu silme 1 mesaj](https://github.com/esincaglakiral/MVCProjectCamp/assets/68962573/81e786c7-6570-4acc-b0e7-11dcf7cbe6d9)

![toplu silme sonucu](https://github.com/esincaglakiral/MVCProjectCamp/assets/68962573/745419fd-9c4d-4bb4-bc5d-6432743fc012)

![Yeni mesaj oluşturma admin](https://github.com/esincaglakiral/MVCProjectCamp/assets/68962573/6efb7d4a-7a02-497c-b759-f86af939e112)

![Yeni mesaj gönderildi](https://github.com/esincaglakiral/MVCProjectCamp/assets/68962573/6ceb355b-d293-4b01-9d39-e9edd1f82c7d)

![Gönderilen mesajın detayı](https://github.com/esincaglakiral/MVCProjectCamp/assets/68962573/e318d123-2b6a-49e4-96be-a075c3f43ad7)

-----------------------------------------------------------------------------------------------

#### Admin Paneli Yetkilendirme Sayfası: Burada admin sisteme yeni admin ekleyebilir, kendi bilgilerini güncelleyebilir ve role atayabilir.

![Admin yetkilendirmeler](https://github.com/esincaglakiral/MVCProjectCamp/assets/68962573/110925a4-ee82-47a6-a982-566902574f5b)

-----------------------------------------------------------------------------------------------
#### Admin Paneli Yetenek Kartı

![Yetenek Kartı](https://github.com/esincaglakiral/MVCProjectCamp/assets/68962573/e9e458ef-3828-419a-8a47-de409bde6b71)

-----------------------------------------------------------------------------------------------
#### Admin Paneli Sözlük Galerisi Carousel

![Sözlük Galerisi](https://github.com/esincaglakiral/MVCProjectCamp/assets/68962573/a6b1f00b-93a9-4c5a-85a0-7a30354256a0)

![Sözlük galerisi 2](https://github.com/esincaglakiral/MVCProjectCamp/assets/68962573/f5df9026-9b1d-4d23-bc7c-a27febc9e418)

-----------------------------------------------------------------------------------------------
#### Admin Paneli Hata Sayfası 404: bu sayfa url'e rastgele birşey yazdığınızda karşınıza çıkar.

![Hata Sayfaları](https://github.com/esincaglakiral/MVCProjectCamp/assets/68962573/7c31f424-5627-491a-8321-38d90ea67ef3)

-----------------------------------------------------------------------------------------------
###  Yazar Paneli
-----------------------------------------------------------------------------------------------

#### Yazar Panelinde Başlıklarım: Burada sadece sisteme giren yazara ait olan başlıklar listelenmektedir. Session ile login olan yazarın id'sine göre başlıklar getirilmiştir. Yazar Burda kendi açtığı başlıklar üzerinde tüm CRUD işlemlerini yapabilir. Burada PagedList yapısı kullanılmıştır ve alttaki sayfa numaralarından ilerleyebilirsiniz.

![Yazar paneli bir yazara ait başlıklar](https://github.com/esincaglakiral/MVCProjectCamp/assets/68962573/ec827c94-ecd2-4dc6-bd9d-5a6a1d6731e0)

-----------------------------------------------------------------------------------------------

#### Yazar Panelinde Tüm Başlıklar: Burada sisteme giren yazar tüm başlıkları listelenmektedir. Bu sayfa üzerinden Bu Başlığın Yazıları butonuyla başlığa ait tüm (tüm yazarların) entryleri görüntüleyebilir, ya da Bu başlığa yazı yaz butonuna tıklayıp, ilgili başlığa entry girebilir. Burada PagedList yapısı kullanılmıştır ve alttaki sayfa numaralarından ilerleyebilirsiniz.

![Yazar paneli tüm başlıklar](https://github.com/esincaglakiral/MVCProjectCamp/assets/68962573/b692bc37-952f-4545-a9c6-4212cdefba82)

![İlgili başlığa tıklayınca](https://github.com/esincaglakiral/MVCProjectCamp/assets/68962573/176a4bc0-8432-4d85-bd27-e9dd816352d3)

![Bu başlığa yaz butonu](https://github.com/esincaglakiral/MVCProjectCamp/assets/68962573/31a0e7ff-606f-4431-b55b-0603147dff7b)

-----------------------------------------------------------------------------------------------

#### Yazar Paneli Yazılarım: Burada yazar kendi yazmış olduğu tüm entryleri görebilmektedir.

![Yazara ait yazıların tümü](https://github.com/esincaglakiral/MVCProjectCamp/assets/68962573/c86991d4-2b14-4433-9ab9-01f87b92a9a4)

-----------------------------------------------------------------------------------------------
#### Yazar Paneli Yazara gelen mailler: yazar burdan adminin ve diğer yazarların kendilerine gönderdiği mailleri görüntüleyebilir. Yapı olarak Admin panelindekiyle aynıdır. Session ile sisteme giren yazar, başka bir yazara ya da admine mail de gönderebilir.

![Yazar paneli yazara gelen mailler](https://github.com/esincaglakiral/MVCProjectCamp/assets/68962573/2b61956f-1043-444f-90fc-a1736c39dc6d)

![yazarın gönderdiği mailler](https://github.com/esincaglakiral/MVCProjectCamp/assets/68962573/299e9f8c-b7ad-41d7-9f4f-d5ae572c1dd4)

-----------------------------------------------------------------------------------------------
#### Yazar Paneli Profil Güncelleme: Burada yazar kendisine ait bilgileri güncelleyebilir. Bunu aynı zamanda Admin de yapabiliyordu.

![Yazar profil güncelleme](https://github.com/esincaglakiral/MVCProjectCamp/assets/68962573/24cbcc83-cc21-4104-a5dc-7a9845fd8f1b)


BURAYA KADAR İNCELEDİĞİNİZ İÇİN TEŞEKKÜRLER...
PROJEMİN KODLARINA YUKARIDAN ERİŞEBİLİRSİNİZ :)






