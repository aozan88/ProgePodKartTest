USE [ProgePodKartTest]
GO

/****** Object:  Table [dbo].[TestVerileri]    Script Date: 13.02.2022 23:06:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TestVerileri](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirmaKodu] [nchar](10) NULL,
	[UrunStokKodu] [nvarchar](50) NULL,
	[UrunGrupKodu] [nvarchar](50) NULL,
	[UrunKodu] [nvarchar](50) NULL,
	[UrunUretimTarihi] [datetime] NULL,
	[Status] [bit] NULL,
	[UrunTestModu] [bit] NULL,
	[UrunTestTipAdi] [nchar](10) NULL,
	[UrunTestEdenKullanici] [nvarchar](50) NULL,
	[UrunTestTarihi] [datetime] NULL,
	[Deger1] [decimal](12, 0) NULL,
	[Deger2] [decimal](12, 0) NULL,
	[Deger3] [decimal](12, 0) NULL,
	[Deger4] [decimal](12, 0) NULL,
	[Deger5] [decimal](12, 0) NULL,
	[Deger6] [decimal](12, 0) NULL,
	[Deger7] [decimal](12, 0) NULL,
	[Deger8] [decimal](12, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


