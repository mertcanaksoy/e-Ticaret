USE [master]
GO
/****** Object:  Database [eTicaretDB]    Script Date: 10.12.2017 19:30:21 ******/
CREATE DATABASE [eTicaretDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'eTicaretDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\eTicaretDB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'eTicaretDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\eTicaretDB_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [eTicaretDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [eTicaretDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [eTicaretDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [eTicaretDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [eTicaretDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [eTicaretDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [eTicaretDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [eTicaretDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [eTicaretDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [eTicaretDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [eTicaretDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [eTicaretDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [eTicaretDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [eTicaretDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [eTicaretDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [eTicaretDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [eTicaretDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [eTicaretDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [eTicaretDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [eTicaretDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [eTicaretDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [eTicaretDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [eTicaretDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [eTicaretDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [eTicaretDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [eTicaretDB] SET  MULTI_USER 
GO
ALTER DATABASE [eTicaretDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [eTicaretDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [eTicaretDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [eTicaretDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [eTicaretDB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [eTicaretDB]
GO
/****** Object:  Table [dbo].[Adress]    Script Date: 10.12.2017 19:30:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Adress](
	[AdresID] [int] IDENTITY(1,1) NOT NULL,
	[MusteriID] [int] NOT NULL,
	[AdresAdi] [nvarchar](50) NULL,
	[AdresAlani] [nvarchar](250) NULL,
 CONSTRAINT [PK_Adress] PRIMARY KEY CLUSTERED 
(
	[AdresID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Kargo]    Script Date: 10.12.2017 19:30:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kargo](
	[KargoID] [int] IDENTITY(1,1) NOT NULL,
	[KargoAdi] [nvarchar](50) NULL,
	[KargoAdresi] [nvarchar](50) NULL,
	[KargoTelefon] [nvarchar](50) NULL,
	[KargoWeb] [nvarchar](50) NULL,
	[KargoEmail] [nvarchar](50) NULL,
 CONSTRAINT [PK_Kargo] PRIMARY KEY CLUSTERED 
(
	[KargoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Kategori]    Script Date: 10.12.2017 19:30:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kategori](
	[KategoriID] [int] IDENTITY(1,1) NOT NULL,
	[KategoriAdi] [nvarchar](100) NULL,
 CONSTRAINT [PK_Kategori] PRIMARY KEY CLUSTERED 
(
	[KategoriID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Kisi]    Script Date: 10.12.2017 19:30:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kisi](
	[KisiID] [int] IDENTITY(1,1) NOT NULL,
	[AdSoyad] [nvarchar](50) NOT NULL,
	[TCKN] [nvarchar](11) NOT NULL,
	[DogumTarihi] [smalldatetime] NOT NULL,
	[Telefon] [nvarchar](11) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Kisi] PRIMARY KEY CLUSTERED 
(
	[KisiID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Marka]    Script Date: 10.12.2017 19:30:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marka](
	[MarkaID] [int] IDENTITY(1,1) NOT NULL,
	[MarkaAdi] [nvarchar](100) NULL,
 CONSTRAINT [PK_Marka] PRIMARY KEY CLUSTERED 
(
	[MarkaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Musteri]    Script Date: 10.12.2017 19:30:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Musteri](
	[MusteriID] [int] IDENTITY(1,1) NOT NULL,
	[KisiID] [int] NULL,
	[Aciklama] [nvarchar](250) NULL,
 CONSTRAINT [PK_Musteri] PRIMARY KEY CLUSTERED 
(
	[MusteriID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Personel]    Script Date: 10.12.2017 19:30:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personel](
	[PersonelID] [int] IDENTITY(1,1) NOT NULL,
	[KisiID] [int] NULL,
	[IseBaslamaTarihi] [smalldatetime] NULL,
	[Maas] [money] NULL,
 CONSTRAINT [PK_Personel] PRIMARY KEY CLUSTERED 
(
	[PersonelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Resim]    Script Date: 10.12.2017 19:30:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Resim](
	[ResimID] [int] IDENTITY(1,1) NOT NULL,
	[UrunID] [int] NULL,
	[ResimAdi] [nvarchar](250) NULL,
 CONSTRAINT [PK_Resim] PRIMARY KEY CLUSTERED 
(
	[ResimID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SatinAlma]    Script Date: 10.12.2017 19:30:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SatinAlma](
	[SatinAlmaID] [int] IDENTITY(1,1) NOT NULL,
	[TedarikciID] [int] NULL,
	[SatinAlmaTarihi] [date] NULL,
	[PersonelID] [int] NULL,
 CONSTRAINT [PK_SatinAlma] PRIMARY KEY CLUSTERED 
(
	[SatinAlmaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SatinAlmaDetay]    Script Date: 10.12.2017 19:30:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SatinAlmaDetay](
	[SatinAlmaID] [int] NOT NULL,
	[UrunID] [int] NOT NULL,
	[Adet] [int] NULL,
	[AlisFiyati] [money] NULL,
 CONSTRAINT [PK_SatinAlmaDetay] PRIMARY KEY CLUSTERED 
(
	[SatinAlmaID] ASC,
	[UrunID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Siparis]    Script Date: 10.12.2017 19:30:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Siparis](
	[SiparisID] [int] IDENTITY(1,1) NOT NULL,
	[MusteriID] [int] NULL,
	[SiparisTarihi] [smalldatetime] NULL,
	[SepetteMi] [bit] NULL,
	[SiparisDurumID] [int] NULL,
	[KargoID] [int] NULL,
	[KargoTakipNo] [nvarchar](50) NULL,
	[PersonelID] [int] NULL,
 CONSTRAINT [PK_Siparis] PRIMARY KEY CLUSTERED 
(
	[SiparisID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SiparisDetay]    Script Date: 10.12.2017 19:30:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SiparisDetay](
	[SiparisID] [int] NOT NULL,
	[UrunID] [int] NOT NULL,
	[Adet] [int] NULL,
	[Fiyat] [money] NULL,
 CONSTRAINT [PK_SiparisDetay] PRIMARY KEY CLUSTERED 
(
	[SiparisID] ASC,
	[UrunID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SiparisDurum]    Script Date: 10.12.2017 19:30:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SiparisDurum](
	[SiparisDurumID] [int] IDENTITY(1,1) NOT NULL,
	[SiparisDurumAdi] [nvarchar](50) NULL,
 CONSTRAINT [PK_SiparisDurum] PRIMARY KEY CLUSTERED 
(
	[SiparisDurumID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tedarikci]    Script Date: 10.12.2017 19:30:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tedarikci](
	[TedarikciID] [int] IDENTITY(1,1) NOT NULL,
	[TedarikciAdi] [nvarchar](100) NULL,
	[UrunID] [int] NULL,
	[TedarikciAdres] [nvarchar](500) NULL,
 CONSTRAINT [PK_Tedarikci] PRIMARY KEY CLUSTERED 
(
	[TedarikciID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Urun]    Script Date: 10.12.2017 19:30:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Urun](
	[UrunID] [int] IDENTITY(1,1) NOT NULL,
	[KategoriID] [int] NULL,
	[MarkaID] [int] NULL,
	[UrunAdi] [nvarchar](250) NULL,
	[UrunAciklama] [nvarchar](1000) NULL,
	[UrunFiyat] [money] NULL,
	[UrunStok] [int] NULL,
 CONSTRAINT [PK_Urun] PRIMARY KEY CLUSTERED 
(
	[UrunID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Adress]  WITH CHECK ADD  CONSTRAINT [FK_Adress_Musteri] FOREIGN KEY([MusteriID])
REFERENCES [dbo].[Musteri] ([MusteriID])
GO
ALTER TABLE [dbo].[Adress] CHECK CONSTRAINT [FK_Adress_Musteri]
GO
ALTER TABLE [dbo].[Musteri]  WITH CHECK ADD  CONSTRAINT [FK_Musteri_Kisi] FOREIGN KEY([KisiID])
REFERENCES [dbo].[Kisi] ([KisiID])
GO
ALTER TABLE [dbo].[Musteri] CHECK CONSTRAINT [FK_Musteri_Kisi]
GO
ALTER TABLE [dbo].[Personel]  WITH CHECK ADD  CONSTRAINT [FK_Personel_Kisi] FOREIGN KEY([KisiID])
REFERENCES [dbo].[Kisi] ([KisiID])
GO
ALTER TABLE [dbo].[Personel] CHECK CONSTRAINT [FK_Personel_Kisi]
GO
ALTER TABLE [dbo].[Resim]  WITH CHECK ADD  CONSTRAINT [FK_Resim_Urun] FOREIGN KEY([UrunID])
REFERENCES [dbo].[Urun] ([UrunID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Resim] CHECK CONSTRAINT [FK_Resim_Urun]
GO
ALTER TABLE [dbo].[SatinAlma]  WITH CHECK ADD  CONSTRAINT [FK_SatinAlma_Personel] FOREIGN KEY([PersonelID])
REFERENCES [dbo].[Personel] ([PersonelID])
GO
ALTER TABLE [dbo].[SatinAlma] CHECK CONSTRAINT [FK_SatinAlma_Personel]
GO
ALTER TABLE [dbo].[SatinAlma]  WITH CHECK ADD  CONSTRAINT [FK_SatinAlma_Tedarikci] FOREIGN KEY([TedarikciID])
REFERENCES [dbo].[Tedarikci] ([TedarikciID])
GO
ALTER TABLE [dbo].[SatinAlma] CHECK CONSTRAINT [FK_SatinAlma_Tedarikci]
GO
ALTER TABLE [dbo].[SatinAlmaDetay]  WITH CHECK ADD  CONSTRAINT [FK_SatinAlmaDetay_SatinAlma] FOREIGN KEY([SatinAlmaID])
REFERENCES [dbo].[SatinAlma] ([SatinAlmaID])
GO
ALTER TABLE [dbo].[SatinAlmaDetay] CHECK CONSTRAINT [FK_SatinAlmaDetay_SatinAlma]
GO
ALTER TABLE [dbo].[SatinAlmaDetay]  WITH CHECK ADD  CONSTRAINT [FK_SatinAlmaDetay_Urun] FOREIGN KEY([UrunID])
REFERENCES [dbo].[Urun] ([UrunID])
GO
ALTER TABLE [dbo].[SatinAlmaDetay] CHECK CONSTRAINT [FK_SatinAlmaDetay_Urun]
GO
ALTER TABLE [dbo].[Siparis]  WITH CHECK ADD  CONSTRAINT [FK_Siparis_Kargo] FOREIGN KEY([KargoID])
REFERENCES [dbo].[Kargo] ([KargoID])
GO
ALTER TABLE [dbo].[Siparis] CHECK CONSTRAINT [FK_Siparis_Kargo]
GO
ALTER TABLE [dbo].[Siparis]  WITH CHECK ADD  CONSTRAINT [FK_Siparis_Musteri] FOREIGN KEY([MusteriID])
REFERENCES [dbo].[Musteri] ([MusteriID])
GO
ALTER TABLE [dbo].[Siparis] CHECK CONSTRAINT [FK_Siparis_Musteri]
GO
ALTER TABLE [dbo].[Siparis]  WITH CHECK ADD  CONSTRAINT [FK_Siparis_Personel] FOREIGN KEY([PersonelID])
REFERENCES [dbo].[Personel] ([PersonelID])
GO
ALTER TABLE [dbo].[Siparis] CHECK CONSTRAINT [FK_Siparis_Personel]
GO
ALTER TABLE [dbo].[Siparis]  WITH CHECK ADD  CONSTRAINT [FK_Siparis_SiparisDurum] FOREIGN KEY([SiparisDurumID])
REFERENCES [dbo].[SiparisDurum] ([SiparisDurumID])
GO
ALTER TABLE [dbo].[Siparis] CHECK CONSTRAINT [FK_Siparis_SiparisDurum]
GO
ALTER TABLE [dbo].[SiparisDetay]  WITH CHECK ADD  CONSTRAINT [FK_SiparisDetay_Siparis] FOREIGN KEY([SiparisID])
REFERENCES [dbo].[Siparis] ([SiparisID])
GO
ALTER TABLE [dbo].[SiparisDetay] CHECK CONSTRAINT [FK_SiparisDetay_Siparis]
GO
ALTER TABLE [dbo].[SiparisDetay]  WITH CHECK ADD  CONSTRAINT [FK_SiparisDetay_Urun] FOREIGN KEY([UrunID])
REFERENCES [dbo].[Urun] ([UrunID])
GO
ALTER TABLE [dbo].[SiparisDetay] CHECK CONSTRAINT [FK_SiparisDetay_Urun]
GO
ALTER TABLE [dbo].[Tedarikci]  WITH CHECK ADD  CONSTRAINT [FK_Tedarikci_Urun] FOREIGN KEY([UrunID])
REFERENCES [dbo].[Urun] ([UrunID])
GO
ALTER TABLE [dbo].[Tedarikci] CHECK CONSTRAINT [FK_Tedarikci_Urun]
GO
ALTER TABLE [dbo].[Urun]  WITH CHECK ADD  CONSTRAINT [FK_Urun_Kategori] FOREIGN KEY([KategoriID])
REFERENCES [dbo].[Kategori] ([KategoriID])
GO
ALTER TABLE [dbo].[Urun] CHECK CONSTRAINT [FK_Urun_Kategori]
GO
ALTER TABLE [dbo].[Urun]  WITH CHECK ADD  CONSTRAINT [FK_Urun_Marka] FOREIGN KEY([MarkaID])
REFERENCES [dbo].[Marka] ([MarkaID])
GO
ALTER TABLE [dbo].[Urun] CHECK CONSTRAINT [FK_Urun_Marka]
GO
/****** Object:  StoredProcedure [dbo].[UrunEkle]    Script Date: 10.12.2017 19:30:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[UrunEkle]
@urunAdi nvarchar(50),
@fiyat money,
@stok smallint
as
insert Urun(UrunAdi,UrunFiyat,UrunStok) values(@urunAdi,@fiyat,@stok)
GO
/****** Object:  StoredProcedure [dbo].[UrunListele]    Script Date: 10.12.2017 19:30:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[UrunListele]
as
select * from Urun
GO
USE [master]
GO
ALTER DATABASE [eTicaretDB] SET  READ_WRITE 
GO

--NOT: Hocam trigger komutlarını da projeye dahil ettiğim halde buraya gelmemiş. Projede Sorunsuz çalışıyorlar
--O komutları da aşağıya bütünlüğü bozmaması için yorum satırı olarak ekliyorum



/*Satış yapıldığı zaman ürünün stoğunu satış adedi kadar düşüren trigger
go
create trigger trg_StokDus
on SiparisDetay
after
insert
as
	declare @id int, @adet int
	select @id=UrunID,@adet=Adet from inserted --inserted tablosuna eklenmeye çalışılan kaydın
	--Adet'ini @adet, UrunID değerini @id'ye at
	update Urun set UrunStok-=@adet where UrunID=@id --Ürünler tablosunda güncelleme, UrunID'si
	--@id olan ürünün Stok'unu @adet kadar azalt

--Ürün tedarik edildiğinde o ürünün stoğunu tedarik adedi kadar arttıran trigger
go
create trigger trg_StokArttir
on SatinAlmaDetay
after
insert
as
	declare @id int, @adet int
	select @id=UrunID,@adet=Adet from inserted --inserted tablosuna eklenmeye çalışılan kaydın
	--Adet'ini @adet, UrunID değerini @id'ye at
	update Urun set UrunStok-=@adet where UrunID=@id --Ürünler tablosunda güncelleme, UrunID'si
	--@id olan ürünün Stok'unu @adet kadar azalt


--SiparisDetay tablosundan kayıt silindiğinde o ürünün stoğunu satış adedi kadar 
--arttıran trigger
go
create trigger trg_SiparisSil
on SiparisDetay --SiparisDetay tablosunda
after         --Delete işleminden
delete        --Sonra çalışacak
as
	declare @id int, @adet int --Değişken tanımlama
	select @id=UrunID, @adet=Adet from deleted --deleted tablosundan silinmeye çalışılan 
	--Adet'i @adet'e, UrunID'yi @id'ye ata
	update Urun set UrunStok+=@adet where UrunID=@id --Urunler tablosunda güncelleme yap
	--Stok değerini @adet kadar arttır, UrunID'si @id olan ürünün.

drop trigger trg_SiparisSil
*/