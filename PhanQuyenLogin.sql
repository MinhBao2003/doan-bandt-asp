create database PhanQuyenLogin
go
use PhanQuyenLogin
go 
create table KhachHang
(
	HoTenKH nvarchar(30),
	TaiKhoan nvarchar(39),
	MatKhau nvarChar(20),
	Id_Quyen int,
	Email nvarchar(100),
	Id_KhachHang int IDENTITY(1,1) NOT NULL primary key
)
go
create table NhanVien
(
	HoTenNV nvarchar(30),
	TaiKhoan nvarchar(39),
	MatKhau nvarChar(20),
	Id_Quyen int,
	Email nvarchar(100),
	Id_NhanVien int primary key
)
go
create table Admin
(
	HoTenAD nvarchar(30),
	TaiKhoan nvarchar(39),
	MatKhau nvarChar(20),
	Id_Quyen int,
	Email nvarchar(100),
	Id_Admin int primary key
)
go
create table Quyen
(
	Id_Quyen int primary key,
	Quyen_Ten nvarchar(100)
)
go
CREATE TABLE ProductC(
	Id int Primary Key,
	[Name] nvarchar(50),
	Price Decimal(18) ,
	Photo nvarchar(50) 
 )
 go
 create table Giohang
 (
	id int,
	TongTien int primary key,
 )
 go
 create table DonHang
 ( 
 TenKhach nvarchar(30)primary key,
 Diachi nvarchar (100),
 SDT varchar(11),
 id int,
 TongTien int  
 )
 go
 create table ChiTietHang
 (
	id  INT IDENTITY(1,1) NOT NULL ,
	hinh nvarchar(50) ,
	hinh1 nvarchar(50),
	hinh2 nvarchar(50),
	hinh3 nvarchar(50),
	TenSP nvarchar(1000),
	Price nvarchar(1000)primary key,
	About nvarchar(1000),
	kichthuoc nvarchar(1000),
	vatlieu nvarchar(1000),
	ma nvarchar(100),
	danhmuc nvarchar(1000),
	Tags nvarchar(1000),
	noidung nvarchar(1000),
 )
 go
 create table ThongTin
 (
	Ten nvarchar(300),
	noidung nvarchar(1000)primary key,
	Hinh nvarchar(1300),
	Hinh2 nvarchar(1300),
	Hinh3 nvarchar(1300),
	NoiDung2 nvarchar(300)
 )
 /*create table BinhLuan
 (
	NoiDungbl nvarchar(300) ,
	Tenbl nvarchar(300)primary key
 )
 create table LienHe
 (
	Tenlienhe nvarchar(100)primary key,
	Email nvarchar(100),
	NoiDung nvarchar(500),
 )*/
 go
 --khóa ngoại
Alter Table KhachHang add Constraint KN_Id_Quyen foreign key (Id_Quyen)  references Quyen (Id_Quyen)
Alter Table NhanVien add Constraint KN1_Id_Quyen foreign key (Id_Quyen)  references Quyen (Id_Quyen)
Alter Table Admin add Constraint KN2_Id_Quyen foreign key (Id_Quyen)  references Quyen (Id_Quyen)
Alter Table DonHang add Constraint KN_DonHang foreign key (id)  references ProductC (id)
Alter Table Giohang add Constraint KN_Giohang foreign key (id)  references ProductC (id)
Alter Table DonHang add Constraint KN_1DonHang foreign key (TongTien)  references Giohang (TongTien)
--Alter Table ProductC add Constraint KN_Price foreign key (Price)  references ChiTietHang (Price)
--Alter Table ChiTietHang add Constraint KN_noidung foreign key (noidung)  references ThongTin (noidung)
--Alter Table ThongTin add Constraint KN_Ten foreign key (Ten)  references BinhLuan (Ten)
--Alter Table ProductC add Constraint KN_price foreign key (price)  references DonHang  (price)
--Alter Table KhachHang add Constraint KN_Id_Quyen foreign key (Id_Quyen)  references Quyen (Id_Quyen)
go
 --loat chi tiết sản phẩm dữ liệu sql xem code ở Controller/SofaController và Views/sofa/sofa1,sofa2,sofa3,sofa4 file hình thì đường dẫn trong database có
 Insert ChiTietHang Values (
 N'~/images/sofa1/i1.jpg', 
 N'~/images/sofa1/i2.jpg', 
 N'~/images/sofa1/i3.jpg' ,
 N'~/images/sofa1/i4.jpg', 
 N'Sofa Gỗ Tràm Tự Nhiên MOHO VLINE ', 
 N'Price: 8,710,000 VND', 
 N'About This Item:', 
 N'Kích thước: D2100 - R880 - C850 mm',
 N'Vật liệu: Chân kim loại sơn đen, nệm bọc vải xanh dương, nệm ngồi & lưng rời',
 N'Mã: 3*109632', 
 N'Danh mục: Sofa, Phòng khách',
 N'Tags: 3 chỗ, Kim loại, Vải',
 N'Sự đơn giản, tinh tế, sang trọng và không kém phần nổi bật của chiếc Sofa mang 
 dòng máu bất diệt Scandinavian này với lần lượt các phiên bản màu từ tối tới sáng bật Pastel sẽ mang lại các 
 sắc màu không thể lẫn vào đâu và đa dạng cho từng không gian sống nhà bạn. Thiết kế vuông vức, thanh mảnh nhẹ 
 nhàng là sự pha trộn giữa vững chãi và nhẹ nhàng là tất cả những yếu tố thiết yếu hội tụ ở chiếc sofa này.')
 Insert ChiTietHang Values (
 N'~/images/sofa2/sofa2.jpg', 
 N'~/images/sofa2/i2.jpg', 
 N'~/images/sofa2/i3.jpg' ,
 N'~/images/sofa2/i4.jpg', 
 N'Sofa 3 Chỗ PENNY Vải Xanh 2m1 MB-22 ', 
 N'Price: 65,340,000 VND', 
 N'About This Item:', 
 N'Kích thước: D2100 - R880 - C850 mm',
 N'Vật liệu: Chân kim loại sơn đen, nệm bọc vải xanh dương, nệm ngồi & lưng rời',
 N'Mã: 3*109632', 
 N'Danh mục: Sofa, Phòng khách',
 N'Tags: 3 chỗ, Kim loại, Vải',
 N'Sự đơn giản, tinh tế, sang trọng và không kém phần nổi bật của chiếc Sofa mang 
 dòng máu bất diệt Scandinavian này với lần lượt các phiên bản màu từ tối tới sáng bật Pastel sẽ mang lại các 
 sắc màu không thể lẫn vào đâu và đa dạng cho từng không gian sống nhà bạn. Thiết kế vuông vức, thanh mảnh nhẹ 
 nhàng là sự pha trộn giữa vững chãi và nhẹ nhàng là tất cả những yếu tố thiết yếu hội tụ ở chiếc sofa này.')
 go
  Insert ChiTietHang Values (
 N'~/images/sofa3/i1.jpg', 
 N'~/images/sofa3/i2.jpg', 
 N'~/images/sofa3/i3.jpg' ,
 N'~/images/sofa3/i4.jpg', 
 N'Sofa Jazz 3 Chỗ Hiện Đại Da Cognac ', 
 N'Price: 11,940,000 VND', 
 N'About This Item:', 
 N'Kích thước: D2100 - R880 - C850 mm',
 N'Vật liệu: Chân kim loại sơn đen, nệm bọc vải xanh dương, nệm ngồi & lưng rời',
 N'Mã: 3*109632', 
 N'Danh mục: Sofa, Phòng khách',
 N'Tags: 3 chỗ, Kim loại, Vải',
 N'Sự đơn giản, tinh tế, sang trọng và không kém phần nổi bật của chiếc Sofa mang 
 dòng máu bất diệt Scandinavian này với lần lượt các phiên bản màu từ tối tới sáng bật Pastel sẽ mang lại các 
 sắc màu không thể lẫn vào đâu và đa dạng cho từng không gian sống nhà bạn. Thiết kế vuông vức, thanh mảnh nhẹ 
 nhàng là sự pha trộn giữa vững chãi và nhẹ nhàng là tất cả những yếu tố thiết yếu hội tụ ở chiếc sofa này.')
 go
 Insert ChiTietHang Values (
 N'~/images/sofa4/i1.jpg', 
 N'~/images/sofa4/i2.jpg', 
 N'~/images/sofa4/i3.jpg' ,
 N'~/images/sofa4/i4.jpg', 
 N'Sofa Bridge 3 Chỗ Hiện Đại Da Đen ', 
 N'Price: 30,870,000', 
 N'About This Item:', 
 N'Kích thước: D2100 - R880 - C850 mm',
 N'Vật liệu: Chân kim loại sơn đen, nệm bọc vải xanh dương, nệm ngồi & lưng rời',
 N'Mã: 3*109632', 
 N'Danh mục: Sofa, Phòng khách',
 N'Tags: 3 chỗ, Kim loại, Vải',
 N'Sự đơn giản, tinh tế, sang trọng và không kém phần nổi bật của chiếc Sofa mang 
 dòng máu bất diệt Scandinavian này với lần lượt các phiên bản màu từ tối tới sáng bật Pastel sẽ mang lại các 
 sắc màu không thể lẫn vào đâu và đa dạng cho từng không gian sống nhà bạn. Thiết kế vuông vức, thanh mảnh nhẹ 
 nhàng là sự pha trộn giữa vững chãi và nhẹ nhàng là tất cả những yếu tố thiết yếu hội tụ ở chiếc sofa này.')
 go
  --loat chi tiết sản phẩm dữ liệu sql xem code ở Controller/TrangChusController và Views/Trangchus/Trangchu file hình thì đường dẫn trong trong database có
Insert ProductC Values (1,'Sofa Gỗ Tràm Tự Nhiên MOHO VLINE 601 Màu Xám Đậm',CAST(8710000 AS Decimal(18, 0)),N'~/Content/Image/sofa1/i1.jpg')
Insert ProductC Values (2,'Sofa 3 chỗ PENNY vải xanh 2m1 MB-22', CAST(65340000  AS Decimal(18, 0)) ,N'~/Content/Image/sofa2/sofa2.jpg')
Insert ProductC Values (3,'Sofa Jazz 3 chỗ hiện đại da cognac', CAST(11940000 AS Decimal(18, 0)) ,N'~/Content/Image/sofa3/i1.jpg')
Insert ProductC Values (5,N'Sofa Bridge 3 chỗ hiện đại da đen', CAST(30870000 AS Decimal(18, 0)) ,N'~/Content/Image/sofa4/i1.jpg')
Insert ProductC Values (6,N'Bàn nước Elegance', CAST(5680000 AS Decimal(18, 0)),N'~/Content/Image/table1/i1.jpg')
Insert ProductC Values (7,N'Bàn nước Pop', CAST(5695000 AS Decimal(18, 0)),N'~/Content/Image/table2/i1.jpg')
Insert ProductC Values (8,N'Bàn nước Osaka', CAST(5270000 AS Decimal(18, 0)),N'~/Content/Image/table3/i1.jpg')
Insert ProductC Values (9,N'Bàn nước Around', CAST(9680000 AS Decimal(18, 0)),N'~/Content/Image/table4/i1.jpg')
Insert ProductC Values (10,N'Giường ngủ Miami 1m6 bọc vải Dolce 150', CAST(15470000 AS Decimal(18, 0)),N'~/Content/Image/bed1/i1.jpg')
Insert ProductC Values (11,N'Giường ngủ bọc da Mây 1m8 Fango', CAST(14040000 AS Decimal(18, 0)),N'~/Content/Image/bed2/i1.jpg')
Insert ProductC Values (12,N'Giường Dubai 1.6M vải MB LA141/28D', CAST(12665000 AS Decimal(18, 0)),N'~/Content/Image/bed3/i1.jpg')
Insert ProductC Values (13,N'Giường ngủ gỗ Victoria 1m6', CAST(15980000 AS Decimal(18, 0)),N'~/Content/Image/bed4/i1.jpg')
Insert ProductC Values (14,N'Armchair Hantz màu xanh', CAST(2200000 AS Decimal(18, 0)),N'~/Content/Image/chair1/i1.jpg')
Insert ProductC Values (15,N'Armchair Arch PMA170044F1 KD1085-11', CAST(1680000 AS Decimal(18, 0)),N'~/Content/Image/chair2/i1.jpg')
Insert ProductC Values (16,N'Armchair Bridge Gỗ Tự nhiên Da đen', CAST(2805000 AS Decimal(18, 0)),N'~/Content/Image/chair3/i1.jpg')
Insert ProductC Values (17,N'Armchair Arch PMA170044F1', CAST(3100000 AS Decimal(18, 0)),N'~/Content/Image/chair4/i4.jpg')
go
 --loat thông tin dữ liệu sql xem code ở Controller/TTController và Views/TT/ThongTin file hình lấy link trực tiếp trên mang
Insert ThongTin Values(N'Sofa',
N'Chúng tôi cung cấp các loại sofa chất lượng cao với nhiều mẫu mã và kiểu dáng đa dạng. Sofa của chúng tôi 
được làm từ chất liệu cao cấp và có độ bền cao. Dưới đây là một số hình ảnh minh họa về các sản phẩm sofa của 
chúng tôi:',
N'https://pula.vn/storage/images/2021/10/28/sofa-vang-v51.jpg',
N'https://sofavila.vn/wp-content/uploads/2022/08/GDF172-4-mau-sofa-phong-khach-rong-3m9-mau-ghi-sang.jpg',
N'https://zsofa.vn/wp-content/uploads/2022/10/sofa-bang-zb1816.jpeg',
N'Quý khách có thể đến cửa hàng của chúng tôi để xem và trải nghiệm các sản phẩm sofa của chúng tôi trực tiếp.')
Insert ThongTin Values(N'Bàn & Ghế',
N'Chúng tôi cung cấp các loại Bàn & Ghế chất lượng cao với nhiều mẫu mã và kiểu dáng đa dạng. Bàn & Ghế của chúng tôi 
được làm từ chất liệu cao cấp và có độ bền cao. Dưới đây là một số hình ảnh minh họa về các sản phẩm sofa của 
chúng tôi:',
N'https://bepabig.com/wp-content/uploads/z3759170422297_a1a3bdd832f1b70a83148f87ed98c0fd-768x768.jpg',
N'https://bepabig.com/wp-content/uploads/O1CN015kjic71hGY3OrCPFJ_2213981434250-0-cib-768x768.jpg',
N'https://bizweb.dktcdn.net/thumb/large/100/429/325/products/bo-ban-cafe-ghe-tho-cam-dep1.jpg?v=1666235101443',
N'Quý khách có thể đến cửa hàng của chúng tôi để xem và trải nghiệm các sản phẩm Bàn & Ghế của chúng tôi trực tiếp.')
Insert ThongTin Values(N'Giường',
N'Chúng tôi cung cấp các loại Giường chất lượng cao với nhiều mẫu mã và kiểu dáng đa dạng. Giường của chúng tôi 
được làm từ chất liệu cao cấp và có độ bền cao. Dưới đây là một số hình ảnh minh họa về các sản phẩm sofa của 
chúng tôi:',
N'https://noithatcauvong.com/image/catalog/san_pham/giuong-ngu/95/giuong-ngu-co-ngan-keo-de-do-95.jpg',
N'https://noithatthanhhai.net/wp-content/uploads/2023/05/giuong-luxury-boc-da-nhap-khau-GN070-1.jpg',
N'https://amia.vn/wp-content/uploads/2021/11/mau-giuong-ngu-dem-da-co-ke-dau-giuong-go-cn-mdf-amia-gn217.jpg',
N'Quý khách có thể đến cửa hàng của chúng tôi để xem và trải nghiệm các sản phẩm Giường của chúng tôi trực tiếp.')
go
Insert Quyen Values ('1',N'Admin')
Insert Quyen Values ('2',N'NhanVien')
Insert Quyen Values ('3',N'KhachHang')
go
Insert Admin Values (N'minhbao',N'minh123', N'12345' ,'1',N'minh@gmail.com','1')
go
Insert NhanVien Values (N'baovinh',N'vinh123', N'12345' ,'2',N'vinh@gmail.com','1')
go
Insert KhachHang Values (N'minhvinh',N'bao123', N'12345' ,'3',N'bao@gmail.com')
go

