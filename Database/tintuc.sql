USE [tintuc]
GO
/****** Object:  Table [dbo].[tblNguoiDung]    Script Date: 11/15/2015 19:12:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblNguoiDung](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tenDN] [varchar](50) NOT NULL,
	[matKhau] [varchar](32) NOT NULL,
	[hoTen] [nvarchar](100) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[ngayTao] [datetime] NOT NULL,
	[quyen] [int] NOT NULL,
	[trangThai] [int] NOT NULL,
 CONSTRAINT [PK_tblNguoiDung] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblChuyenMuc]    Script Date: 11/15/2015 19:12:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblChuyenMuc](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tenCM] [nvarchar](200) NOT NULL,
	[moTa] [text] NOT NULL,
	[tuKhoa] [text] NULL,
	[idCha] [int] NOT NULL,
 CONSTRAINT [PK_tblChuyenMuc] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCauHinh]    Script Date: 11/15/2015 19:12:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCauHinh](
	[tieuDe] [text] NULL,
	[moTa] [text] NULL,
	[tuKhoa] [text] NULL,
	[logo] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblThanhVien]    Script Date: 11/15/2015 19:12:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblThanhVien](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tenDN] [varchar](50) NOT NULL,
	[matKhau] [varchar](32) NOT NULL,
	[hoTen] [nvarchar](100) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[ngaySinh] [datetime] NULL,
	[gioiTinh] [int] NULL,
	[diaChi] [text] NULL,
	[ngayTao] [datetime] NOT NULL,
	[anhDaiDien] [varchar](100) NULL,
	[trangThai] [int] NOT NULL,
 CONSTRAINT [PK_tblThanhVien] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblBaiViet]    Script Date: 11/15/2015 19:12:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblBaiViet](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_CM] [int] NOT NULL,
	[id_ND] [int] NOT NULL,
	[tieuDe] [text] NOT NULL,
	[noiDung] [text] NOT NULL,
	[moTa] [text] NULL,
	[tuKhoa] [text] NULL,
	[hinhAnh] [varchar](100) NOT NULL,
	[ngayTao] [datetime] NOT NULL,
	[luotXem] [int] NOT NULL,
	[trangThai] [int] NOT NULL,
 CONSTRAINT [PK_tblBaiViet] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblPhanHoi]    Script Date: 11/15/2015 19:12:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPhanHoi](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_TV] [int] NULL,
	[noiDung] [text] NULL,
	[ngayGui] [datetime] NULL,
 CONSTRAINT [PK_tblPhanHoi] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblBinhLuan]    Script Date: 11/15/2015 19:12:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblBinhLuan](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_TV] [int] NULL,
	[id_BV] [int] NULL,
	[noiDung] [text] NULL,
	[trangThai] [int] NULL,
 CONSTRAINT [PK_tblBinhLuan] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Default [DF_tblBaiViet_luotXem]    Script Date: 11/15/2015 19:12:22 ******/
ALTER TABLE [dbo].[tblBaiViet] ADD  CONSTRAINT [DF_tblBaiViet_luotXem]  DEFAULT ((0)) FOR [luotXem]
GO
/****** Object:  Default [DF_tblBaiViet_trangThai]    Script Date: 11/15/2015 19:12:22 ******/
ALTER TABLE [dbo].[tblBaiViet] ADD  CONSTRAINT [DF_tblBaiViet_trangThai]  DEFAULT ((1)) FOR [trangThai]
GO
/****** Object:  Default [DF_tblBinhLuan_trangThai]    Script Date: 11/15/2015 19:12:22 ******/
ALTER TABLE [dbo].[tblBinhLuan] ADD  CONSTRAINT [DF_tblBinhLuan_trangThai]  DEFAULT ((1)) FOR [trangThai]
GO
/****** Object:  Default [DF_tblChuyenMuc_idCha]    Script Date: 11/15/2015 19:12:22 ******/
ALTER TABLE [dbo].[tblChuyenMuc] ADD  CONSTRAINT [DF_tblChuyenMuc_idCha]  DEFAULT ((0)) FOR [idCha]
GO
/****** Object:  Default [DF_tblThanhVien_tinhTrang]    Script Date: 11/15/2015 19:12:22 ******/
ALTER TABLE [dbo].[tblThanhVien] ADD  CONSTRAINT [DF_tblThanhVien_tinhTrang]  DEFAULT ((1)) FOR [trangThai]
GO
/****** Object:  ForeignKey [FK_tblBaiViet_tblChuyenMuc]    Script Date: 11/15/2015 19:12:22 ******/
ALTER TABLE [dbo].[tblBaiViet]  WITH CHECK ADD  CONSTRAINT [FK_tblBaiViet_tblChuyenMuc] FOREIGN KEY([id_CM])
REFERENCES [dbo].[tblChuyenMuc] ([id])
GO
ALTER TABLE [dbo].[tblBaiViet] CHECK CONSTRAINT [FK_tblBaiViet_tblChuyenMuc]
GO
/****** Object:  ForeignKey [FK_tblBaiViet_tblNguoiDung]    Script Date: 11/15/2015 19:12:22 ******/
ALTER TABLE [dbo].[tblBaiViet]  WITH CHECK ADD  CONSTRAINT [FK_tblBaiViet_tblNguoiDung] FOREIGN KEY([id_ND])
REFERENCES [dbo].[tblNguoiDung] ([id])
GO
ALTER TABLE [dbo].[tblBaiViet] CHECK CONSTRAINT [FK_tblBaiViet_tblNguoiDung]
GO
/****** Object:  ForeignKey [FK_tblBinhLuan_tblBaiViet]    Script Date: 11/15/2015 19:12:22 ******/
ALTER TABLE [dbo].[tblBinhLuan]  WITH CHECK ADD  CONSTRAINT [FK_tblBinhLuan_tblBaiViet] FOREIGN KEY([id_BV])
REFERENCES [dbo].[tblBaiViet] ([id])
GO
ALTER TABLE [dbo].[tblBinhLuan] CHECK CONSTRAINT [FK_tblBinhLuan_tblBaiViet]
GO
/****** Object:  ForeignKey [FK_tblBinhLuan_tblThanhVien]    Script Date: 11/15/2015 19:12:22 ******/
ALTER TABLE [dbo].[tblBinhLuan]  WITH CHECK ADD  CONSTRAINT [FK_tblBinhLuan_tblThanhVien] FOREIGN KEY([id_TV])
REFERENCES [dbo].[tblThanhVien] ([id])
GO
ALTER TABLE [dbo].[tblBinhLuan] CHECK CONSTRAINT [FK_tblBinhLuan_tblThanhVien]
GO
/****** Object:  ForeignKey [FK_tblPhanHoi_tblThanhVien]    Script Date: 11/15/2015 19:12:22 ******/
ALTER TABLE [dbo].[tblPhanHoi]  WITH CHECK ADD  CONSTRAINT [FK_tblPhanHoi_tblThanhVien] FOREIGN KEY([id_TV])
REFERENCES [dbo].[tblThanhVien] ([id])
GO
ALTER TABLE [dbo].[tblPhanHoi] CHECK CONSTRAINT [FK_tblPhanHoi_tblThanhVien]
GO
