USE [WebQLDiem]
GO
/****** Object:  Table [dbo].[BaiTap]    Script Date: 4/27/2021 12:55:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaiTap](
	[MaBaiTap] [int] IDENTITY(1,1) NOT NULL,
	[TenBaiTap] [nvarchar](250) NOT NULL,
	[MoTa] [nvarchar](max) NULL,
	[ThangDiem] [int] NOT NULL,
	[MaLopHoc] [int] NOT NULL,
	[NgayBatDau] [datetime] NOT NULL,
	[NgayKetThuc] [datetime] NOT NULL,
	[NguoiTao] [int] NOT NULL,
	[MaChuDe] [int] NULL,
	[TrangThai] [int] NULL,
	[NgayTao] [datetime] NULL,
	[ThangDiemChuyenCan] [int] NOT NULL,
 CONSTRAINT [PK_BaiTap] PRIMARY KEY CLUSTERED 
(
	[MaBaiTap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BaiTap-HocVien]    Script Date: 4/27/2021 12:55:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaiTap-HocVien](
	[MaBaiTap] [int] NOT NULL,
	[MaHocVien] [int] NOT NULL,
	[TrangThai] [int] NULL,
	[NgayGiao] [datetime] NULL,
	[NgayNop] [datetime] NULL,
	[NgayChamDiem] [datetime] NULL,
	[DiemHocTap] [int] NULL,
	[DiemChuyenCan] [int] NULL,
	[NhanXetGiangVien] [nvarchar](500) NULL,
	[TepDinhKem] [nvarchar](1000) NULL,
	[NoiDungGuiBai] [nvarchar](max) NULL,
 CONSTRAINT [PK_BaiTap-HocVien] PRIMARY KEY CLUSTERED 
(
	[MaBaiTap] ASC,
	[MaHocVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BaiTap-NhanXet]    Script Date: 4/27/2021 12:55:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaiTap-NhanXet](
	[MaNhanXet] [int] IDENTITY(1,1) NOT NULL,
	[NoiDung] [nvarchar](500) NULL,
	[NgayTao] [datetime] NULL,
	[NguoiTao] [int] NULL,
	[MaBaiTap] [int] NULL,
 CONSTRAINT [PK_NhanXet] PRIMARY KEY CLUSTERED 
(
	[MaNhanXet] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BaiTapTepDinhKem]    Script Date: 4/27/2021 12:55:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaiTapTepDinhKem](
	[MaTepDinhKem] [int] IDENTITY(1,1) NOT NULL,
	[MaBaiTap] [int] NULL,
	[DuongDan] [nvarchar](500) NULL,
	[NgayTao] [datetime] NULL,
	[NguoiTao] [int] NULL,
 CONSTRAINT [PK_BaiTapTepDinhKem] PRIMARY KEY CLUSTERED 
(
	[MaTepDinhKem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChuDe]    Script Date: 4/27/2021 12:55:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChuDe](
	[MaChuDe] [int] IDENTITY(1,1) NOT NULL,
	[TenChuDe] [nvarchar](150) NULL,
	[NgayTao] [datetime] NULL,
	[NguoiTao] [int] NULL,
	[MaLopHoc] [int] NULL,
 CONSTRAINT [PK_ChuDe] PRIMARY KEY CLUSTERED 
(
	[MaChuDe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GiangVien]    Script Date: 4/27/2021 12:55:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiangVien](
	[MaGiangVien] [int] IDENTITY(1,1) NOT NULL,
	[TenGiangVien] [nvarchar](150) NOT NULL,
	[Email] [nvarchar](150) NOT NULL,
	[SoDienThoai] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](500) NULL,
	[MaTaiKhoan] [int] NULL,
 CONSTRAINT [PK_GiangVien] PRIMARY KEY CLUSTERED 
(
	[MaGiangVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HocVien]    Script Date: 4/27/2021 12:55:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HocVien](
	[MaHocVien] [int] IDENTITY(1,1) NOT NULL,
	[TenHocVien] [nvarchar](150) NOT NULL,
	[Email] [nvarchar](150) NOT NULL,
	[SoDienThoai] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](500) NULL,
	[MaTaiKhoan] [int] NULL,
 CONSTRAINT [PK_HocVien] PRIMARY KEY CLUSTERED 
(
	[MaHocVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LopHoc]    Script Date: 4/27/2021 12:55:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LopHoc](
	[MaLopHoc] [int] IDENTITY(1,1) NOT NULL,
	[TenLopHoc] [nvarchar](100) NOT NULL,
	[MoTa] [nvarchar](1000) NULL,
	[DiaChi] [nvarchar](500) NULL,
	[Phong] [nvarchar](100) NULL,
	[ChuDe] [nvarchar](100) NULL,
	[NgayTao] [datetime] NOT NULL,
	[NguoiTao] [int] NOT NULL,
	[TrangThai] [int] NOT NULL,
 CONSTRAINT [PK_LopHoc] PRIMARY KEY CLUSTERED 
(
	[MaLopHoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LopHoc-GiangVien]    Script Date: 4/27/2021 12:55:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LopHoc-GiangVien](
	[MaLopHoc] [int] NOT NULL,
	[MaGiangVien] [int] NOT NULL,
 CONSTRAINT [PK_LopHoc-GiangVien] PRIMARY KEY CLUSTERED 
(
	[MaLopHoc] ASC,
	[MaGiangVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LopHoc-HocVien]    Script Date: 4/27/2021 12:55:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LopHoc-HocVien](
	[MaLopHoc] [int] NOT NULL,
	[MaHocVien] [int] NOT NULL,
 CONSTRAINT [PK_LopHoc-HocVien] PRIMARY KEY CLUSTERED 
(
	[MaLopHoc] ASC,
	[MaHocVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 4/27/2021 12:55:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[MaTaKhoan] [int] IDENTITY(1,1) NOT NULL,
	[TenDangNhap] [nvarchar](50) NOT NULL,
	[MatKhau] [nvarchar](50) NOT NULL,
	[NgayTao] [datetime] NULL,
	[LoaiTaiKhoan] [int] NULL,
	[HinhDaiDien] [nvarchar](500) NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[MaTaKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TaiKhoan-ThongBao]    Script Date: 4/27/2021 12:55:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan-ThongBao](
	[MaThongBao] [int] IDENTITY(1,1) NOT NULL,
	[MaTaiKhoan] [int] NULL,
	[TieuDe] [nvarchar](100) NULL,
	[NoiDung] [nvarchar](1000) NULL,
	[NgayTao] [datetime] NULL,
 CONSTRAINT [PK_TaiKhoan-ThongBao] PRIMARY KEY CLUSTERED 
(
	[MaThongBao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TaiLieu]    Script Date: 4/27/2021 12:55:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiLieu](
	[MaTaiLieu] [int] IDENTITY(1,1) NOT NULL,
	[MaLopHoc] [int] NULL,
	[TenTaiLieu] [nvarchar](250) NOT NULL,
	[MoTa] [nvarchar](max) NULL,
	[NgayTao] [datetime] NOT NULL,
	[NguoiTao] [int] NOT NULL,
	[TrangThai] [int] NULL,
	[MaChuDe] [int] NULL,
 CONSTRAINT [PK_TaiLieu] PRIMARY KEY CLUSTERED 
(
	[MaTaiLieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TaiLieu-HocVien]    Script Date: 4/27/2021 12:55:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiLieu-HocVien](
	[MaTaiLieu] [int] NOT NULL,
	[MaHocVien] [int] NOT NULL,
 CONSTRAINT [PK_TaiLieu-HocVien] PRIMARY KEY CLUSTERED 
(
	[MaTaiLieu] ASC,
	[MaHocVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TaiLieu-NhanXet]    Script Date: 4/27/2021 12:55:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiLieu-NhanXet](
	[MaNhanXet] [int] IDENTITY(1,1) NOT NULL,
	[MaTaiLieu] [int] NULL,
	[NoiDung] [nvarchar](500) NULL,
	[NgayTao] [datetime] NULL,
	[NguoiTao] [int] NULL,
 CONSTRAINT [PK_TaiLieu-NhanXet] PRIMARY KEY CLUSTERED 
(
	[MaNhanXet] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TaiLieuTepDinhKem]    Script Date: 4/27/2021 12:55:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiLieuTepDinhKem](
	[MaTepDinhKem] [int] IDENTITY(1,1) NOT NULL,
	[MaTaiLieu] [int] NULL,
	[DuongDan] [nvarchar](500) NULL,
	[NgayTao] [datetime] NULL,
	[NguoiTao] [int] NULL,
 CONSTRAINT [PK_TaiLieuTepDinhKem] PRIMARY KEY CLUSTERED 
(
	[MaTepDinhKem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ThongBao]    Script Date: 4/27/2021 12:55:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThongBao](
	[MaThongBao] [int] IDENTITY(1,1) NOT NULL,
	[NoiDung] [nvarchar](500) NULL,
	[NgayTao] [datetime] NULL,
	[NguoiTao] [int] NULL,
	[MaLopHoc] [int] NULL,
 CONSTRAINT [PK_ThongBao] PRIMARY KEY CLUSTERED 
(
	[MaThongBao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ThongBao-HocVien]    Script Date: 4/27/2021 12:55:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThongBao-HocVien](
	[MaThongBao] [int] NOT NULL,
	[MaHocVien] [int] NOT NULL,
 CONSTRAINT [PK_ThongBao-HocVien_1] PRIMARY KEY CLUSTERED 
(
	[MaThongBao] ASC,
	[MaHocVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ThongBao-NhanXet]    Script Date: 4/27/2021 12:55:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThongBao-NhanXet](
	[MaNhanXet] [int] IDENTITY(1,1) NOT NULL,
	[MaThongBao] [int] NULL,
	[NoiDung] [nvarchar](500) NULL,
	[NgayTao] [datetime] NULL,
	[NguoiTao] [int] NULL,
 CONSTRAINT [PK_ThongBao-NhanXet] PRIMARY KEY CLUSTERED 
(
	[MaNhanXet] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ThongBaoTepDinhKem]    Script Date: 4/27/2021 12:55:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThongBaoTepDinhKem](
	[MaTepDinhKem] [int] IDENTITY(1,1) NOT NULL,
	[MaThongBao] [int] NULL,
	[DuongDan] [nvarchar](500) NULL,
	[NgayTao] [datetime] NULL,
	[NguoiTao] [int] NULL,
 CONSTRAINT [PK_ThongBaoTepDinhKem] PRIMARY KEY CLUSTERED 
(
	[MaTepDinhKem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[BaiTap] ON 

INSERT [dbo].[BaiTap] ([MaBaiTap], [TenBaiTap], [MoTa], [ThangDiem], [MaLopHoc], [NgayBatDau], [NgayKetThuc], [NguoiTao], [MaChuDe], [TrangThai], [NgayTao], [ThangDiemChuyenCan]) VALUES (1, N'Bài tập về nhà', N'<p>
	432342 4234 2342342342 234 2</p>
', 10, 1, CAST(0x0000AD080011D7F8 AS DateTime), CAST(0x0000AD110011D7F8 AS DateTime), 1, 1, 3, CAST(0x0000AD080011D7F8 AS DateTime), 10)
INSERT [dbo].[BaiTap] ([MaBaiTap], [TenBaiTap], [MoTa], [ThangDiem], [MaLopHoc], [NgayBatDau], [NgayKetThuc], [NguoiTao], [MaChuDe], [TrangThai], [NgayTao], [ThangDiemChuyenCan]) VALUES (2, N'Bài tập 555', NULL, 10, 1, CAST(0x0000AD08001375A4 AS DateTime), CAST(0x0000AD10001375A4 AS DateTime), 1, NULL, 1, CAST(0x0000AD080011D7F8 AS DateTime), 10)
INSERT [dbo].[BaiTap] ([MaBaiTap], [TenBaiTap], [MoTa], [ThangDiem], [MaLopHoc], [NgayBatDau], [NgayKetThuc], [NguoiTao], [MaChuDe], [TrangThai], [NgayTao], [ThangDiemChuyenCan]) VALUES (3, N'Bài tập 55544', NULL, 10, 1, CAST(0x0000AD08001515A8 AS DateTime), CAST(0x0000AD11001515A8 AS DateTime), 1, 1, 1, CAST(0x0000AD080011D7F8 AS DateTime), 10)
INSERT [dbo].[BaiTap] ([MaBaiTap], [TenBaiTap], [MoTa], [ThangDiem], [MaLopHoc], [NgayBatDau], [NgayKetThuc], [NguoiTao], [MaChuDe], [TrangThai], [NgayTao], [ThangDiemChuyenCan]) VALUES (4, N'Bài tập 1', N'<p>
	Kiểm tra b&agrave;i tập 1</p>
', 100, 2, CAST(0x0000AD1400876810 AS DateTime), CAST(0x0000AD1A00876810 AS DateTime), 1, 3, 3, CAST(0x0000AD1400876810 AS DateTime), 100)
INSERT [dbo].[BaiTap] ([MaBaiTap], [TenBaiTap], [MoTa], [ThangDiem], [MaLopHoc], [NgayBatDau], [NgayKetThuc], [NguoiTao], [MaChuDe], [TrangThai], [NgayTao], [ThangDiemChuyenCan]) VALUES (5, N'Kiểm tra Bài tập', N'<p>
	Hệ thống b&agrave;i tập tuần 2</p>
', 100, 2, CAST(0x0000AD1600AD7CE4 AS DateTime), CAST(0x0000AD1900AD7CE4 AS DateTime), 11, 4, 1, CAST(0x0000AD1600AD9CE5 AS DateTime), 100)
SET IDENTITY_INSERT [dbo].[BaiTap] OFF
INSERT [dbo].[BaiTap-HocVien] ([MaBaiTap], [MaHocVien], [TrangThai], [NgayGiao], [NgayNop], [NgayChamDiem], [DiemHocTap], [DiemChuyenCan], [NhanXetGiangVien], [TepDinhKem], [NoiDungGuiBai]) VALUES (1, 1, 3, CAST(0x0000AD0800209018 AS DateTime), CAST(0x0000AD08015C8C70 AS DateTime), CAST(0x0000AD1201670286 AS DateTime), 10, 9, N'Học tốt', N',/Uploads/3/images/tranh%201.jpg,/Uploads/3/images/tranh%202.jpg', NULL)
INSERT [dbo].[BaiTap-HocVien] ([MaBaiTap], [MaHocVien], [TrangThai], [NgayGiao], [NgayNop], [NgayChamDiem], [DiemHocTap], [DiemChuyenCan], [NhanXetGiangVien], [TepDinhKem], [NoiDungGuiBai]) VALUES (2, 1, 1, CAST(0x0000AD080013C39F AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[BaiTap-HocVien] ([MaBaiTap], [MaHocVien], [TrangThai], [NgayGiao], [NgayNop], [NgayChamDiem], [DiemHocTap], [DiemChuyenCan], [NhanXetGiangVien], [TepDinhKem], [NoiDungGuiBai]) VALUES (3, 1, 1, CAST(0x0000AD0800153C55 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[BaiTap-HocVien] ([MaBaiTap], [MaHocVien], [TrangThai], [NgayGiao], [NgayNop], [NgayChamDiem], [DiemHocTap], [DiemChuyenCan], [NhanXetGiangVien], [TepDinhKem], [NoiDungGuiBai]) VALUES (3, 2, 1, CAST(0x0000AD0800153C5C AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[BaiTap-HocVien] ([MaBaiTap], [MaHocVien], [TrangThai], [NgayGiao], [NgayNop], [NgayChamDiem], [DiemHocTap], [DiemChuyenCan], [NhanXetGiangVien], [TepDinhKem], [NoiDungGuiBai]) VALUES (4, 8, 3, CAST(0x0000AD1400878F5D AS DateTime), CAST(0x0000AD1400AE20D3 AS DateTime), CAST(0x0000AD1400AE64FF AS DateTime), 10, 10, N'Kém', N'', N'')
INSERT [dbo].[BaiTap-HocVien] ([MaBaiTap], [MaHocVien], [TrangThai], [NgayGiao], [NgayNop], [NgayChamDiem], [DiemHocTap], [DiemChuyenCan], [NhanXetGiangVien], [TepDinhKem], [NoiDungGuiBai]) VALUES (5, 8, 1, CAST(0x0000AD1600AD9DE3 AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[BaiTap-NhanXet] ON 

INSERT [dbo].[BaiTap-NhanXet] ([MaNhanXet], [NoiDung], [NgayTao], [NguoiTao], [MaBaiTap]) VALUES (1, N'Xin chào nhé', CAST(0x0000AD12016EDF13 AS DateTime), 1, 1)
INSERT [dbo].[BaiTap-NhanXet] ([MaNhanXet], [NoiDung], [NgayTao], [NguoiTao], [MaBaiTap]) VALUES (2, N'Kiểm tra', CAST(0x0000AD1400ADFD60 AS DateTime), 10, 4)
INSERT [dbo].[BaiTap-NhanXet] ([MaNhanXet], [NoiDung], [NgayTao], [NguoiTao], [MaBaiTap]) VALUES (3, N'sao vậy Huy', CAST(0x0000AD1400AE1A9E AS DateTime), 1, 4)
SET IDENTITY_INSERT [dbo].[BaiTap-NhanXet] OFF
SET IDENTITY_INSERT [dbo].[BaiTapTepDinhKem] ON 

INSERT [dbo].[BaiTapTepDinhKem] ([MaTepDinhKem], [MaBaiTap], [DuongDan], [NgayTao], [NguoiTao]) VALUES (2, 2, N'/Uploads/1/files/tranh%202.jpg', CAST(0x0000AD080013ABA1 AS DateTime), 1)
INSERT [dbo].[BaiTapTepDinhKem] ([MaTepDinhKem], [MaBaiTap], [DuongDan], [NgayTao], [NguoiTao]) VALUES (3, 2, N'/Uploads/1/files/tranh%201.jpg', CAST(0x0000AD080013B091 AS DateTime), 1)
INSERT [dbo].[BaiTapTepDinhKem] ([MaTepDinhKem], [MaBaiTap], [DuongDan], [NgayTao], [NguoiTao]) VALUES (4, 3, N'/Uploads/1/files/tranh%202.jpg', CAST(0x0000AD0800153C4B AS DateTime), 1)
INSERT [dbo].[BaiTapTepDinhKem] ([MaTepDinhKem], [MaBaiTap], [DuongDan], [NgayTao], [NguoiTao]) VALUES (5, 3, N'/Uploads/1/files/tranh%201.jpg', CAST(0x0000AD0800153C51 AS DateTime), 1)
INSERT [dbo].[BaiTapTepDinhKem] ([MaTepDinhKem], [MaBaiTap], [DuongDan], [NgayTao], [NguoiTao]) VALUES (6, 1, N'/Uploads/1/files/tranh%202.jpg', CAST(0x0000AD0800209007 AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[BaiTapTepDinhKem] OFF
SET IDENTITY_INSERT [dbo].[ChuDe] ON 

INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe], [NgayTao], [NguoiTao], [MaLopHoc]) VALUES (1, N'Toán học', CAST(0x0000AD070114C7C7 AS DateTime), 1, 1)
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe], [NgayTao], [NguoiTao], [MaLopHoc]) VALUES (2, N'Văn học', CAST(0x0000AD1201794A19 AS DateTime), 1, 1)
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe], [NgayTao], [NguoiTao], [MaLopHoc]) VALUES (3, N'Tuần 1', CAST(0x0000AD14008761B2 AS DateTime), 1, 2)
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe], [NgayTao], [NguoiTao], [MaLopHoc]) VALUES (4, N'Tuần 2', CAST(0x0000AD1600AD7969 AS DateTime), 11, 2)
SET IDENTITY_INSERT [dbo].[ChuDe] OFF
SET IDENTITY_INSERT [dbo].[GiangVien] ON 

INSERT [dbo].[GiangVien] ([MaGiangVien], [TenGiangVien], [Email], [SoDienThoai], [DiaChi], [MaTaiKhoan]) VALUES (1, N'Ngô Văn minh', N'minh@gmail.com', N'0939939202', N'HH', 2)
INSERT [dbo].[GiangVien] ([MaGiangVien], [TenGiangVien], [Email], [SoDienThoai], [DiaChi], [MaTaiKhoan]) VALUES (2, N'HUYIT', N'nguyenvanhuy44@gmail.com', NULL, NULL, 11)
SET IDENTITY_INSERT [dbo].[GiangVien] OFF
SET IDENTITY_INSERT [dbo].[HocVien] ON 

INSERT [dbo].[HocVien] ([MaHocVien], [TenHocVien], [Email], [SoDienThoai], [DiaChi], [MaTaiKhoan]) VALUES (1, N'Hoàng Anh Khoa', N'khoa@gmail.com', N'090009009', N'HH', 3)
INSERT [dbo].[HocVien] ([MaHocVien], [TenHocVien], [Email], [SoDienThoai], [DiaChi], [MaTaiKhoan]) VALUES (2, N'Nguyễn Thùy Phương', N'phuong@gmail.com', N'0939939202', N'HH', 4)
INSERT [dbo].[HocVien] ([MaHocVien], [TenHocVien], [Email], [SoDienThoai], [DiaChi], [MaTaiKhoan]) VALUES (7, N'Giỏi', N'trangioihd.2010@gmail.com', N'0939939202', N'HH', 9)
INSERT [dbo].[HocVien] ([MaHocVien], [TenHocVien], [Email], [SoDienThoai], [DiaChi], [MaTaiKhoan]) VALUES (8, N'Nguyễn Văn Huy', N'huyit.nv@gmail.com', N'0938939202', NULL, 10)
SET IDENTITY_INSERT [dbo].[HocVien] OFF
SET IDENTITY_INSERT [dbo].[LopHoc] ON 

INSERT [dbo].[LopHoc] ([MaLopHoc], [TenLopHoc], [MoTa], [DiaChi], [Phong], [ChuDe], [NgayTao], [NguoiTao], [TrangThai]) VALUES (1, N'Lớp học 1', N'học toán', N'HH', N'PO3', N'toán', CAST(0x0000AD0700FDD01E AS DateTime), 1, 1)
INSERT [dbo].[LopHoc] ([MaLopHoc], [TenLopHoc], [MoTa], [DiaChi], [Phong], [ChuDe], [NgayTao], [NguoiTao], [TrangThai]) VALUES (2, N'Lớp 10', N'Mô tả lớp 10', NULL, NULL, NULL, CAST(0x0000AD1400840900 AS DateTime), 1, 1)
SET IDENTITY_INSERT [dbo].[LopHoc] OFF
INSERT [dbo].[LopHoc-GiangVien] ([MaLopHoc], [MaGiangVien]) VALUES (1, 1)
INSERT [dbo].[LopHoc-GiangVien] ([MaLopHoc], [MaGiangVien]) VALUES (2, 1)
INSERT [dbo].[LopHoc-GiangVien] ([MaLopHoc], [MaGiangVien]) VALUES (2, 2)
INSERT [dbo].[LopHoc-HocVien] ([MaLopHoc], [MaHocVien]) VALUES (1, 1)
INSERT [dbo].[LopHoc-HocVien] ([MaLopHoc], [MaHocVien]) VALUES (1, 2)
INSERT [dbo].[LopHoc-HocVien] ([MaLopHoc], [MaHocVien]) VALUES (2, 8)
SET IDENTITY_INSERT [dbo].[TaiKhoan] ON 

INSERT [dbo].[TaiKhoan] ([MaTaKhoan], [TenDangNhap], [MatKhau], [NgayTao], [LoaiTaiKhoan], [HinhDaiDien]) VALUES (1, N'admin', N'123', CAST(0x0000AD0700000000 AS DateTime), 0, N'/Uploads/1/files/tranh%202.jpg')
INSERT [dbo].[TaiKhoan] ([MaTaKhoan], [TenDangNhap], [MatKhau], [NgayTao], [LoaiTaiKhoan], [HinhDaiDien]) VALUES (2, N'minh@gmail.com', N'123456', CAST(0x0000AD0700EE1D6C AS DateTime), 1, NULL)
INSERT [dbo].[TaiKhoan] ([MaTaKhoan], [TenDangNhap], [MatKhau], [NgayTao], [LoaiTaiKhoan], [HinhDaiDien]) VALUES (3, N'khoa@gmail.com', N'123456', CAST(0x0000AD0700EE88D9 AS DateTime), 2, NULL)
INSERT [dbo].[TaiKhoan] ([MaTaKhoan], [TenDangNhap], [MatKhau], [NgayTao], [LoaiTaiKhoan], [HinhDaiDien]) VALUES (4, N'phuong@gmail.com', N'123456', CAST(0x0000AD08000C21DF AS DateTime), 2, NULL)
INSERT [dbo].[TaiKhoan] ([MaTaKhoan], [TenDangNhap], [MatKhau], [NgayTao], [LoaiTaiKhoan], [HinhDaiDien]) VALUES (9, N'trangioihd.2010@gmail.com', N'123456', CAST(0x0000AD080179D2C7 AS DateTime), 2, NULL)
INSERT [dbo].[TaiKhoan] ([MaTaKhoan], [TenDangNhap], [MatKhau], [NgayTao], [LoaiTaiKhoan], [HinhDaiDien]) VALUES (10, N'huyit.nv@gmail.com', N'123456', CAST(0x0000AD140086F953 AS DateTime), 2, NULL)
INSERT [dbo].[TaiKhoan] ([MaTaKhoan], [TenDangNhap], [MatKhau], [NgayTao], [LoaiTaiKhoan], [HinhDaiDien]) VALUES (11, N'nguyenvanhuy44@gmail.com', N'123456', CAST(0x0000AD1600AD241A AS DateTime), 1, NULL)
SET IDENTITY_INSERT [dbo].[TaiKhoan] OFF
SET IDENTITY_INSERT [dbo].[TaiKhoan-ThongBao] ON 

INSERT [dbo].[TaiKhoan-ThongBao] ([MaThongBao], [MaTaiKhoan], [TieuDe], [NoiDung], [NgayTao]) VALUES (1, 2, N'Bạn đã được thêm vào lớp [Lớp 10]', N'Bạn đã được thêm vào lớp [Lớp 10]', CAST(0x0000AD1400862D2A AS DateTime))
INSERT [dbo].[TaiKhoan-ThongBao] ([MaThongBao], [MaTaiKhoan], [TieuDe], [NoiDung], [NgayTao]) VALUES (2, 10, N'Bạn đã được thêm vào lớp [Lớp 10]', N'Bạn đã được thêm vào lớp [Lớp 10]', CAST(0x0000AD140087550B AS DateTime))
INSERT [dbo].[TaiKhoan-ThongBao] ([MaThongBao], [MaTaiKhoan], [TieuDe], [NoiDung], [NgayTao]) VALUES (3, 10, N'Bạn đã được giao bài tập tại lớp [Lớp 10]', N'Bạn đã được giao bài tập tại lớp [Lớp 10]', CAST(0x0000AD14008A1312 AS DateTime))
INSERT [dbo].[TaiKhoan-ThongBao] ([MaThongBao], [MaTaiKhoan], [TieuDe], [NoiDung], [NgayTao]) VALUES (4, 3, N'Bạn đã được thông báo tại lớp [Lớp học 1]', N'Bạn đã được thông báo tại lớp [Lớp học 1]', CAST(0x0000AD140098EE99 AS DateTime))
INSERT [dbo].[TaiKhoan-ThongBao] ([MaThongBao], [MaTaiKhoan], [TieuDe], [NoiDung], [NgayTao]) VALUES (5, 4, N'Bạn đã được thông báo tại lớp [Lớp học 1]', N'Bạn đã được thông báo tại lớp [Lớp học 1]', CAST(0x0000AD140098EEA4 AS DateTime))
INSERT [dbo].[TaiKhoan-ThongBao] ([MaThongBao], [MaTaiKhoan], [TieuDe], [NoiDung], [NgayTao]) VALUES (6, 3, N'Có 1 trao đổi mới tại thông báo trong lớp học [Lớp học 1]', N'Có 1 trao đổi mới tại thông báo trong lớp học [Lớp học 1]', CAST(0x0000AD140098FC8F AS DateTime))
INSERT [dbo].[TaiKhoan-ThongBao] ([MaThongBao], [MaTaiKhoan], [TieuDe], [NoiDung], [NgayTao]) VALUES (7, 4, N'Có 1 trao đổi mới tại thông báo trong lớp học [Lớp học 1]', N'Có 1 trao đổi mới tại thông báo trong lớp học [Lớp học 1]', CAST(0x0000AD140098FC99 AS DateTime))
INSERT [dbo].[TaiKhoan-ThongBao] ([MaThongBao], [MaTaiKhoan], [TieuDe], [NoiDung], [NgayTao]) VALUES (8, 1, N'Có 1 trao đổi mới tại bài tập [Bài tập 1]', N'Có 1 trao đổi mới tại bài tập [Bài tập 1]', CAST(0x0000AD1400ADFDE3 AS DateTime))
INSERT [dbo].[TaiKhoan-ThongBao] ([MaThongBao], [MaTaiKhoan], [TieuDe], [NoiDung], [NgayTao]) VALUES (9, 10, N'Có 1 trao đổi mới tại bài tập [Bài tập 1]', N'Có 1 trao đổi mới tại bài tập [Bài tập 1]', CAST(0x0000AD1400AE1AA2 AS DateTime))
INSERT [dbo].[TaiKhoan-ThongBao] ([MaThongBao], [MaTaiKhoan], [TieuDe], [NoiDung], [NgayTao]) VALUES (10, 1, N'Học viên [Nguyễn Văn Huy] nộp bài tập [Bài tập 1]', N'Học viên [Nguyễn Văn Huy] nộp bài tập [Bài tập 1]', CAST(0x0000AD1400AE20E1 AS DateTime))
INSERT [dbo].[TaiKhoan-ThongBao] ([MaThongBao], [MaTaiKhoan], [TieuDe], [NoiDung], [NgayTao]) VALUES (11, 10, N'Bài tập [Bài tập 1] đã được chấm điểm', N'Bài tập [Bài tập 1] đã được chấm điểm', CAST(0x0000AD1400AE6951 AS DateTime))
INSERT [dbo].[TaiKhoan-ThongBao] ([MaThongBao], [MaTaiKhoan], [TieuDe], [NoiDung], [NgayTao]) VALUES (12, 3, N'Bạn đã được giao bài tập tại lớp [Lớp học 1]', N'Bạn đã được giao bài tập tại lớp [Lớp học 1]', CAST(0x0000AD1400C2E148 AS DateTime))
INSERT [dbo].[TaiKhoan-ThongBao] ([MaThongBao], [MaTaiKhoan], [TieuDe], [NoiDung], [NgayTao]) VALUES (13, 4, N'Bạn đã được giao bài tập tại lớp [Lớp học 1]', N'Bạn đã được giao bài tập tại lớp [Lớp học 1]', CAST(0x0000AD1400C2E548 AS DateTime))
INSERT [dbo].[TaiKhoan-ThongBao] ([MaThongBao], [MaTaiKhoan], [TieuDe], [NoiDung], [NgayTao]) VALUES (14, 3, N'Bạn đã được giao bài tập tại lớp [Lớp học 1]', N'Bạn đã được giao bài tập tại lớp [Lớp học 1]', CAST(0x0000AD1400C30C98 AS DateTime))
INSERT [dbo].[TaiKhoan-ThongBao] ([MaThongBao], [MaTaiKhoan], [TieuDe], [NoiDung], [NgayTao]) VALUES (15, 11, N'Bạn đã được thêm vào lớp [Lớp 10]', N'Bạn đã được thêm vào lớp [Lớp 10]', CAST(0x0000AD1600AD4C1C AS DateTime))
INSERT [dbo].[TaiKhoan-ThongBao] ([MaThongBao], [MaTaiKhoan], [TieuDe], [NoiDung], [NgayTao]) VALUES (16, 10, N'Bạn đã được giao bài tập tại lớp [Lớp 10]', N'Bạn đã được giao bài tập tại lớp [Lớp 10]', CAST(0x0000AD1600ADA743 AS DateTime))
SET IDENTITY_INSERT [dbo].[TaiKhoan-ThongBao] OFF
SET IDENTITY_INSERT [dbo].[TaiLieu] ON 

INSERT [dbo].[TaiLieu] ([MaTaiLieu], [MaLopHoc], [TenTaiLieu], [MoTa], [NgayTao], [NguoiTao], [TrangThai], [MaChuDe]) VALUES (0, 1, N'tài liệu kiểu mới', N'<p>
	342342 42423423</p>
', CAST(0x0000AD070184E214 AS DateTime), 1, 1, 1)
INSERT [dbo].[TaiLieu] ([MaTaiLieu], [MaLopHoc], [TenTaiLieu], [MoTa], [NgayTao], [NguoiTao], [TrangThai], [MaChuDe]) VALUES (1, 1, N'123231', N'<p>
	123123123</p>
', CAST(0x0000AD07018A05EF AS DateTime), 1, 0, NULL)
SET IDENTITY_INSERT [dbo].[TaiLieu] OFF
INSERT [dbo].[TaiLieu-HocVien] ([MaTaiLieu], [MaHocVien]) VALUES (0, 1)
INSERT [dbo].[TaiLieu-HocVien] ([MaTaiLieu], [MaHocVien]) VALUES (1, 2)
SET IDENTITY_INSERT [dbo].[TaiLieu-NhanXet] ON 

INSERT [dbo].[TaiLieu-NhanXet] ([MaNhanXet], [MaTaiLieu], [NoiDung], [NgayTao], [NguoiTao]) VALUES (1, 0, N'Xin chào nhé', CAST(0x0000AD1201770021 AS DateTime), 1)
INSERT [dbo].[TaiLieu-NhanXet] ([MaNhanXet], [MaTaiLieu], [NoiDung], [NgayTao], [NguoiTao]) VALUES (2, 0, N'vâng tôi cũng xin chào', CAST(0x0000AD12017D0023 AS DateTime), 1)
INSERT [dbo].[TaiLieu-NhanXet] ([MaNhanXet], [MaTaiLieu], [NoiDung], [NgayTao], [NguoiTao]) VALUES (3, 0, N'hi', CAST(0x0000AD12017D5934 AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[TaiLieu-NhanXet] OFF
SET IDENTITY_INSERT [dbo].[TaiLieuTepDinhKem] ON 

INSERT [dbo].[TaiLieuTepDinhKem] ([MaTepDinhKem], [MaTaiLieu], [DuongDan], [NgayTao], [NguoiTao]) VALUES (5, 1, N'/Uploads/1/files/tranh%201.jpg', CAST(0x0000AD13000F90A8 AS DateTime), 1)
INSERT [dbo].[TaiLieuTepDinhKem] ([MaTepDinhKem], [MaTaiLieu], [DuongDan], [NgayTao], [NguoiTao]) VALUES (6, 0, N'/Uploads/1/files/tranh%201.jpg', CAST(0x0000AD1300CCE6A1 AS DateTime), 1)
INSERT [dbo].[TaiLieuTepDinhKem] ([MaTepDinhKem], [MaTaiLieu], [DuongDan], [NgayTao], [NguoiTao]) VALUES (7, 0, N'/Uploads/1/files/tranh%202.jpg', CAST(0x0000AD1300CCE6AA AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[TaiLieuTepDinhKem] OFF
SET IDENTITY_INSERT [dbo].[ThongBao] ON 

INSERT [dbo].[ThongBao] ([MaThongBao], [NoiDung], [NgayTao], [NguoiTao], [MaLopHoc]) VALUES (1, NULL, CAST(0x0000AD120185CD70 AS DateTime), 1, 1)
INSERT [dbo].[ThongBao] ([MaThongBao], [NoiDung], [NgayTao], [NguoiTao], [MaLopHoc]) VALUES (2, N'<p>
	th&ocirc;ng b&aacute;o n&agrave;y thay cho giấy mời</p>
', CAST(0x0000AD12018A1F9B AS DateTime), 1, 1)
INSERT [dbo].[ThongBao] ([MaThongBao], [NoiDung], [NgayTao], [NguoiTao], [MaLopHoc]) VALUES (3, N'<p>
	thống b&aacute;o vui vẻ nh&eacute; vui vẻ nh&eacute;</p>
', CAST(0x0000AD12018AC607 AS DateTime), 1, 1)
INSERT [dbo].[ThongBao] ([MaThongBao], [NoiDung], [NgayTao], [NguoiTao], [MaLopHoc]) VALUES (4, N'<p>
	th&ocirc;ng b&aacute;o của t&ocirc;i nh&eacute;</p>
', CAST(0x0000AD130001DB04 AS DateTime), 1, 1)
INSERT [dbo].[ThongBao] ([MaThongBao], [NoiDung], [NgayTao], [NguoiTao], [MaLopHoc]) VALUES (5, N'<p>
	Th&ocirc;ng b&aacute;o kh&oacute;a Học 10 ch&uacute; &yacute; tiến độ c&ocirc;ng việc..</p>
', CAST(0x0000AD1400852D96 AS DateTime), 1, 2)
INSERT [dbo].[ThongBao] ([MaThongBao], [NoiDung], [NgayTao], [NguoiTao], [MaLopHoc]) VALUES (8, N'<p>
	Thoong baos cho vui ve nhes</p>
', CAST(0x0000AD1400966BE9 AS DateTime), 1, 1)
INSERT [dbo].[ThongBao] ([MaThongBao], [NoiDung], [NgayTao], [NguoiTao], [MaLopHoc]) VALUES (9, N'<p>
	4234234 242 424 2 2424242 24</p>
', CAST(0x0000AD1400969948 AS DateTime), 1, 1)
INSERT [dbo].[ThongBao] ([MaThongBao], [NoiDung], [NgayTao], [NguoiTao], [MaLopHoc]) VALUES (10, N'<p>
	525252352352352353252</p>
', CAST(0x0000AD140096B2D5 AS DateTime), 1, 1)
INSERT [dbo].[ThongBao] ([MaThongBao], [NoiDung], [NgayTao], [NguoiTao], [MaLopHoc]) VALUES (11, N'<p>
	3242 423 4234 2 424234</p>
', CAST(0x0000AD1400979893 AS DateTime), 1, 1)
INSERT [dbo].[ThongBao] ([MaThongBao], [NoiDung], [NgayTao], [NguoiTao], [MaLopHoc]) VALUES (12, N'<p>
	234 242 42424 242 4234</p>
', CAST(0x0000AD140097B953 AS DateTime), 1, 1)
INSERT [dbo].[ThongBao] ([MaThongBao], [NoiDung], [NgayTao], [NguoiTao], [MaLopHoc]) VALUES (13, N'<p>
	423424 234234234</p>
', CAST(0x0000AD140098EDEF AS DateTime), 1, 1)
SET IDENTITY_INSERT [dbo].[ThongBao] OFF
INSERT [dbo].[ThongBao-HocVien] ([MaThongBao], [MaHocVien]) VALUES (1, 1)
INSERT [dbo].[ThongBao-HocVien] ([MaThongBao], [MaHocVien]) VALUES (1, 2)
INSERT [dbo].[ThongBao-HocVien] ([MaThongBao], [MaHocVien]) VALUES (2, 1)
INSERT [dbo].[ThongBao-HocVien] ([MaThongBao], [MaHocVien]) VALUES (2, 2)
INSERT [dbo].[ThongBao-HocVien] ([MaThongBao], [MaHocVien]) VALUES (3, 1)
INSERT [dbo].[ThongBao-HocVien] ([MaThongBao], [MaHocVien]) VALUES (3, 2)
INSERT [dbo].[ThongBao-HocVien] ([MaThongBao], [MaHocVien]) VALUES (4, 1)
INSERT [dbo].[ThongBao-HocVien] ([MaThongBao], [MaHocVien]) VALUES (4, 2)
INSERT [dbo].[ThongBao-HocVien] ([MaThongBao], [MaHocVien]) VALUES (8, 1)
INSERT [dbo].[ThongBao-HocVien] ([MaThongBao], [MaHocVien]) VALUES (9, 1)
INSERT [dbo].[ThongBao-HocVien] ([MaThongBao], [MaHocVien]) VALUES (10, 1)
INSERT [dbo].[ThongBao-HocVien] ([MaThongBao], [MaHocVien]) VALUES (11, 1)
INSERT [dbo].[ThongBao-HocVien] ([MaThongBao], [MaHocVien]) VALUES (12, 1)
INSERT [dbo].[ThongBao-HocVien] ([MaThongBao], [MaHocVien]) VALUES (13, 1)
INSERT [dbo].[ThongBao-HocVien] ([MaThongBao], [MaHocVien]) VALUES (13, 2)
SET IDENTITY_INSERT [dbo].[ThongBao-NhanXet] ON 

INSERT [dbo].[ThongBao-NhanXet] ([MaNhanXet], [MaThongBao], [NoiDung], [NgayTao], [NguoiTao]) VALUES (1, 4, N'hinh hee', CAST(0x0000AD130001E622 AS DateTime), 1)
INSERT [dbo].[ThongBao-NhanXet] ([MaNhanXet], [MaThongBao], [NoiDung], [NgayTao], [NguoiTao]) VALUES (2, 4, N'hhhaaa', CAST(0x0000AD130005C15B AS DateTime), 1)
INSERT [dbo].[ThongBao-NhanXet] ([MaNhanXet], [MaThongBao], [NoiDung], [NgayTao], [NguoiTao]) VALUES (3, 13, N'234242342', CAST(0x0000AD140098F7F9 AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[ThongBao-NhanXet] OFF
SET IDENTITY_INSERT [dbo].[ThongBaoTepDinhKem] ON 

INSERT [dbo].[ThongBaoTepDinhKem] ([MaTepDinhKem], [MaThongBao], [DuongDan], [NgayTao], [NguoiTao]) VALUES (1, 1, N'/Uploads/1/files/tranh%202.jpg', CAST(0x0000AD120185CD78 AS DateTime), 1)
INSERT [dbo].[ThongBaoTepDinhKem] ([MaTepDinhKem], [MaThongBao], [DuongDan], [NgayTao], [NguoiTao]) VALUES (2, 2, N'/Uploads/1/files/tranh%202.jpg', CAST(0x0000AD12018A1FA2 AS DateTime), 1)
INSERT [dbo].[ThongBaoTepDinhKem] ([MaTepDinhKem], [MaThongBao], [DuongDan], [NgayTao], [NguoiTao]) VALUES (3, 3, N'/Uploads/1/files/tranh%203.jpg', CAST(0x0000AD12018AD247 AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[ThongBaoTepDinhKem] OFF
ALTER TABLE [dbo].[BaiTap] ADD  CONSTRAINT [DF_BaiTap_NgayTao]  DEFAULT (getdate()) FOR [NgayTao]
GO
ALTER TABLE [dbo].[TaiKhoan-ThongBao] ADD  CONSTRAINT [DF_TaiKhoan-ThongBao_NgayTao]  DEFAULT (getdate()) FOR [NgayTao]
GO
ALTER TABLE [dbo].[TaiLieu-NhanXet] ADD  CONSTRAINT [DF_TaiLieu-NhanXet_NgayTao]  DEFAULT (getdate()) FOR [NgayTao]
GO
ALTER TABLE [dbo].[ThongBao] ADD  CONSTRAINT [DF_ThongBao_NgayTao]  DEFAULT (getdate()) FOR [NgayTao]
GO
ALTER TABLE [dbo].[ThongBao-NhanXet] ADD  CONSTRAINT [DF_ThongBao-NhanXet_NgayTao]  DEFAULT (getdate()) FOR [NgayTao]
GO
ALTER TABLE [dbo].[ThongBaoTepDinhKem] ADD  CONSTRAINT [DF_ThongBaoTepDinhKem_NgayTao]  DEFAULT (getdate()) FOR [NgayTao]
GO
ALTER TABLE [dbo].[BaiTap]  WITH CHECK ADD  CONSTRAINT [FK_BaiTap_ChuDe] FOREIGN KEY([MaChuDe])
REFERENCES [dbo].[ChuDe] ([MaChuDe])
GO
ALTER TABLE [dbo].[BaiTap] CHECK CONSTRAINT [FK_BaiTap_ChuDe]
GO
ALTER TABLE [dbo].[BaiTap]  WITH CHECK ADD  CONSTRAINT [FK_BaiTap_LopHoc] FOREIGN KEY([MaLopHoc])
REFERENCES [dbo].[LopHoc] ([MaLopHoc])
GO
ALTER TABLE [dbo].[BaiTap] CHECK CONSTRAINT [FK_BaiTap_LopHoc]
GO
ALTER TABLE [dbo].[BaiTap]  WITH CHECK ADD  CONSTRAINT [FK_BaiTap_TaiKhoan] FOREIGN KEY([NguoiTao])
REFERENCES [dbo].[TaiKhoan] ([MaTaKhoan])
GO
ALTER TABLE [dbo].[BaiTap] CHECK CONSTRAINT [FK_BaiTap_TaiKhoan]
GO
ALTER TABLE [dbo].[BaiTap-HocVien]  WITH CHECK ADD  CONSTRAINT [FK_BaiTap-HocVien_BaiTap] FOREIGN KEY([MaBaiTap])
REFERENCES [dbo].[BaiTap] ([MaBaiTap])
GO
ALTER TABLE [dbo].[BaiTap-HocVien] CHECK CONSTRAINT [FK_BaiTap-HocVien_BaiTap]
GO
ALTER TABLE [dbo].[BaiTap-HocVien]  WITH CHECK ADD  CONSTRAINT [FK_BaiTap-HocVien_HocVien] FOREIGN KEY([MaHocVien])
REFERENCES [dbo].[HocVien] ([MaHocVien])
GO
ALTER TABLE [dbo].[BaiTap-HocVien] CHECK CONSTRAINT [FK_BaiTap-HocVien_HocVien]
GO
ALTER TABLE [dbo].[BaiTap-NhanXet]  WITH CHECK ADD  CONSTRAINT [FK_NhanXet_BaiTap] FOREIGN KEY([MaBaiTap])
REFERENCES [dbo].[BaiTap] ([MaBaiTap])
GO
ALTER TABLE [dbo].[BaiTap-NhanXet] CHECK CONSTRAINT [FK_NhanXet_BaiTap]
GO
ALTER TABLE [dbo].[BaiTap-NhanXet]  WITH CHECK ADD  CONSTRAINT [FK_NhanXet_TaiKhoan] FOREIGN KEY([NguoiTao])
REFERENCES [dbo].[TaiKhoan] ([MaTaKhoan])
GO
ALTER TABLE [dbo].[BaiTap-NhanXet] CHECK CONSTRAINT [FK_NhanXet_TaiKhoan]
GO
ALTER TABLE [dbo].[BaiTapTepDinhKem]  WITH CHECK ADD  CONSTRAINT [FK_BaiTapTepDinhKem_BaiTap] FOREIGN KEY([MaBaiTap])
REFERENCES [dbo].[BaiTap] ([MaBaiTap])
GO
ALTER TABLE [dbo].[BaiTapTepDinhKem] CHECK CONSTRAINT [FK_BaiTapTepDinhKem_BaiTap]
GO
ALTER TABLE [dbo].[BaiTapTepDinhKem]  WITH CHECK ADD  CONSTRAINT [FK_BaiTapTepDinhKem_TaiKhoan] FOREIGN KEY([NguoiTao])
REFERENCES [dbo].[TaiKhoan] ([MaTaKhoan])
GO
ALTER TABLE [dbo].[BaiTapTepDinhKem] CHECK CONSTRAINT [FK_BaiTapTepDinhKem_TaiKhoan]
GO
ALTER TABLE [dbo].[ChuDe]  WITH CHECK ADD  CONSTRAINT [FK_ChuDe_LopHoc] FOREIGN KEY([MaLopHoc])
REFERENCES [dbo].[LopHoc] ([MaLopHoc])
GO
ALTER TABLE [dbo].[ChuDe] CHECK CONSTRAINT [FK_ChuDe_LopHoc]
GO
ALTER TABLE [dbo].[ChuDe]  WITH CHECK ADD  CONSTRAINT [FK_ChuDe_TaiKhoan] FOREIGN KEY([NguoiTao])
REFERENCES [dbo].[TaiKhoan] ([MaTaKhoan])
GO
ALTER TABLE [dbo].[ChuDe] CHECK CONSTRAINT [FK_ChuDe_TaiKhoan]
GO
ALTER TABLE [dbo].[GiangVien]  WITH CHECK ADD  CONSTRAINT [FK_GiangVien_TaiKhoan] FOREIGN KEY([MaTaiKhoan])
REFERENCES [dbo].[TaiKhoan] ([MaTaKhoan])
GO
ALTER TABLE [dbo].[GiangVien] CHECK CONSTRAINT [FK_GiangVien_TaiKhoan]
GO
ALTER TABLE [dbo].[HocVien]  WITH CHECK ADD  CONSTRAINT [FK_HocVien_TaiKhoan] FOREIGN KEY([MaTaiKhoan])
REFERENCES [dbo].[TaiKhoan] ([MaTaKhoan])
GO
ALTER TABLE [dbo].[HocVien] CHECK CONSTRAINT [FK_HocVien_TaiKhoan]
GO
ALTER TABLE [dbo].[LopHoc]  WITH CHECK ADD  CONSTRAINT [FK_LopHoc_TaiKhoan] FOREIGN KEY([NguoiTao])
REFERENCES [dbo].[TaiKhoan] ([MaTaKhoan])
GO
ALTER TABLE [dbo].[LopHoc] CHECK CONSTRAINT [FK_LopHoc_TaiKhoan]
GO
ALTER TABLE [dbo].[LopHoc-GiangVien]  WITH CHECK ADD  CONSTRAINT [FK_LopHoc-GiangVien_GiangVien] FOREIGN KEY([MaGiangVien])
REFERENCES [dbo].[GiangVien] ([MaGiangVien])
GO
ALTER TABLE [dbo].[LopHoc-GiangVien] CHECK CONSTRAINT [FK_LopHoc-GiangVien_GiangVien]
GO
ALTER TABLE [dbo].[LopHoc-GiangVien]  WITH CHECK ADD  CONSTRAINT [FK_LopHoc-GiangVien_LopHoc] FOREIGN KEY([MaLopHoc])
REFERENCES [dbo].[LopHoc] ([MaLopHoc])
GO
ALTER TABLE [dbo].[LopHoc-GiangVien] CHECK CONSTRAINT [FK_LopHoc-GiangVien_LopHoc]
GO
ALTER TABLE [dbo].[LopHoc-HocVien]  WITH CHECK ADD  CONSTRAINT [FK_LopHoc-HocVien_HocVien] FOREIGN KEY([MaHocVien])
REFERENCES [dbo].[HocVien] ([MaHocVien])
GO
ALTER TABLE [dbo].[LopHoc-HocVien] CHECK CONSTRAINT [FK_LopHoc-HocVien_HocVien]
GO
ALTER TABLE [dbo].[LopHoc-HocVien]  WITH CHECK ADD  CONSTRAINT [FK_LopHoc-HocVien_LopHoc] FOREIGN KEY([MaLopHoc])
REFERENCES [dbo].[LopHoc] ([MaLopHoc])
GO
ALTER TABLE [dbo].[LopHoc-HocVien] CHECK CONSTRAINT [FK_LopHoc-HocVien_LopHoc]
GO
ALTER TABLE [dbo].[TaiKhoan-ThongBao]  WITH CHECK ADD  CONSTRAINT [FK_TaiKhoan-ThongBao_TaiKhoan] FOREIGN KEY([MaTaiKhoan])
REFERENCES [dbo].[TaiKhoan] ([MaTaKhoan])
GO
ALTER TABLE [dbo].[TaiKhoan-ThongBao] CHECK CONSTRAINT [FK_TaiKhoan-ThongBao_TaiKhoan]
GO
ALTER TABLE [dbo].[TaiLieu]  WITH CHECK ADD  CONSTRAINT [FK_TaiLieu_ChuDe] FOREIGN KEY([MaChuDe])
REFERENCES [dbo].[ChuDe] ([MaChuDe])
GO
ALTER TABLE [dbo].[TaiLieu] CHECK CONSTRAINT [FK_TaiLieu_ChuDe]
GO
ALTER TABLE [dbo].[TaiLieu]  WITH CHECK ADD  CONSTRAINT [FK_TaiLieu_LopHoc] FOREIGN KEY([MaLopHoc])
REFERENCES [dbo].[LopHoc] ([MaLopHoc])
GO
ALTER TABLE [dbo].[TaiLieu] CHECK CONSTRAINT [FK_TaiLieu_LopHoc]
GO
ALTER TABLE [dbo].[TaiLieu]  WITH CHECK ADD  CONSTRAINT [FK_TaiLieu_TaiKhoan] FOREIGN KEY([NguoiTao])
REFERENCES [dbo].[TaiKhoan] ([MaTaKhoan])
GO
ALTER TABLE [dbo].[TaiLieu] CHECK CONSTRAINT [FK_TaiLieu_TaiKhoan]
GO
ALTER TABLE [dbo].[TaiLieu-HocVien]  WITH CHECK ADD  CONSTRAINT [FK_TaiLieu-HocVien_HocVien] FOREIGN KEY([MaHocVien])
REFERENCES [dbo].[HocVien] ([MaHocVien])
GO
ALTER TABLE [dbo].[TaiLieu-HocVien] CHECK CONSTRAINT [FK_TaiLieu-HocVien_HocVien]
GO
ALTER TABLE [dbo].[TaiLieu-HocVien]  WITH CHECK ADD  CONSTRAINT [FK_TaiLieu-HocVien_TaiLieu] FOREIGN KEY([MaTaiLieu])
REFERENCES [dbo].[TaiLieu] ([MaTaiLieu])
GO
ALTER TABLE [dbo].[TaiLieu-HocVien] CHECK CONSTRAINT [FK_TaiLieu-HocVien_TaiLieu]
GO
ALTER TABLE [dbo].[TaiLieu-NhanXet]  WITH CHECK ADD  CONSTRAINT [FK_TaiLieu-NhanXet_TaiKhoan] FOREIGN KEY([NguoiTao])
REFERENCES [dbo].[TaiKhoan] ([MaTaKhoan])
GO
ALTER TABLE [dbo].[TaiLieu-NhanXet] CHECK CONSTRAINT [FK_TaiLieu-NhanXet_TaiKhoan]
GO
ALTER TABLE [dbo].[TaiLieu-NhanXet]  WITH CHECK ADD  CONSTRAINT [FK_TaiLieu-NhanXet_TaiLieu] FOREIGN KEY([MaTaiLieu])
REFERENCES [dbo].[TaiLieu] ([MaTaiLieu])
GO
ALTER TABLE [dbo].[TaiLieu-NhanXet] CHECK CONSTRAINT [FK_TaiLieu-NhanXet_TaiLieu]
GO
ALTER TABLE [dbo].[TaiLieuTepDinhKem]  WITH CHECK ADD  CONSTRAINT [FK_TaiLieuTepDinhKem_TaiKhoan] FOREIGN KEY([NguoiTao])
REFERENCES [dbo].[TaiKhoan] ([MaTaKhoan])
GO
ALTER TABLE [dbo].[TaiLieuTepDinhKem] CHECK CONSTRAINT [FK_TaiLieuTepDinhKem_TaiKhoan]
GO
ALTER TABLE [dbo].[TaiLieuTepDinhKem]  WITH CHECK ADD  CONSTRAINT [FK_TaiLieuTepDinhKem_TaiLieu] FOREIGN KEY([MaTaiLieu])
REFERENCES [dbo].[TaiLieu] ([MaTaiLieu])
GO
ALTER TABLE [dbo].[TaiLieuTepDinhKem] CHECK CONSTRAINT [FK_TaiLieuTepDinhKem_TaiLieu]
GO
ALTER TABLE [dbo].[ThongBao]  WITH CHECK ADD  CONSTRAINT [FK_ThongBao_LopHoc] FOREIGN KEY([MaLopHoc])
REFERENCES [dbo].[LopHoc] ([MaLopHoc])
GO
ALTER TABLE [dbo].[ThongBao] CHECK CONSTRAINT [FK_ThongBao_LopHoc]
GO
ALTER TABLE [dbo].[ThongBao]  WITH CHECK ADD  CONSTRAINT [FK_ThongBao_TaiKhoan] FOREIGN KEY([NguoiTao])
REFERENCES [dbo].[TaiKhoan] ([MaTaKhoan])
GO
ALTER TABLE [dbo].[ThongBao] CHECK CONSTRAINT [FK_ThongBao_TaiKhoan]
GO
ALTER TABLE [dbo].[ThongBao-HocVien]  WITH CHECK ADD  CONSTRAINT [FK_ThongBao-HocVien_HocVien] FOREIGN KEY([MaHocVien])
REFERENCES [dbo].[HocVien] ([MaHocVien])
GO
ALTER TABLE [dbo].[ThongBao-HocVien] CHECK CONSTRAINT [FK_ThongBao-HocVien_HocVien]
GO
ALTER TABLE [dbo].[ThongBao-HocVien]  WITH CHECK ADD  CONSTRAINT [FK_ThongBao-HocVien_ThongBao] FOREIGN KEY([MaThongBao])
REFERENCES [dbo].[ThongBao] ([MaThongBao])
GO
ALTER TABLE [dbo].[ThongBao-HocVien] CHECK CONSTRAINT [FK_ThongBao-HocVien_ThongBao]
GO
ALTER TABLE [dbo].[ThongBao-NhanXet]  WITH CHECK ADD  CONSTRAINT [FK_ThongBao-NhanXet_TaiKhoan] FOREIGN KEY([NguoiTao])
REFERENCES [dbo].[TaiKhoan] ([MaTaKhoan])
GO
ALTER TABLE [dbo].[ThongBao-NhanXet] CHECK CONSTRAINT [FK_ThongBao-NhanXet_TaiKhoan]
GO
ALTER TABLE [dbo].[ThongBao-NhanXet]  WITH CHECK ADD  CONSTRAINT [FK_ThongBao-NhanXet_ThongBao] FOREIGN KEY([MaThongBao])
REFERENCES [dbo].[ThongBao] ([MaThongBao])
GO
ALTER TABLE [dbo].[ThongBao-NhanXet] CHECK CONSTRAINT [FK_ThongBao-NhanXet_ThongBao]
GO
ALTER TABLE [dbo].[ThongBaoTepDinhKem]  WITH CHECK ADD  CONSTRAINT [FK_ThongBaoTepDinhKem_TaiKhoan] FOREIGN KEY([NguoiTao])
REFERENCES [dbo].[TaiKhoan] ([MaTaKhoan])
GO
ALTER TABLE [dbo].[ThongBaoTepDinhKem] CHECK CONSTRAINT [FK_ThongBaoTepDinhKem_TaiKhoan]
GO
ALTER TABLE [dbo].[ThongBaoTepDinhKem]  WITH CHECK ADD  CONSTRAINT [FK_ThongBaoTepDinhKem_ThongBao] FOREIGN KEY([MaThongBao])
REFERENCES [dbo].[ThongBao] ([MaThongBao])
GO
ALTER TABLE [dbo].[ThongBaoTepDinhKem] CHECK CONSTRAINT [FK_ThongBaoTepDinhKem_ThongBao]
GO
