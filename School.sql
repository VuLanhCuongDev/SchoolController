CREATE DATABASE School
GO
CREATE TABLE [dbo].[TaiKhoan]
(
    [TenTaiKhoan] VARCHAR(50) PRIMARY KEY,
    [MatKhau] VARCHAR(50) NOT NULL,
);
GO
CREATE TABLE [dbo].[SinhVien]
(
    [MaSinhVien] VARCHAR(10) PRIMARY KEY,
    [TenSinhVien] NVARCHAR(50) NOT NULL,
    [GioiTinh] BIT NULL,
    [NgaySinh] DATE NULL,
    [SoDienThoai] VARCHAR(10) NOT NULL,
    [DiaChi] NVARCHAR(MAX) NULL,
    [Hinh] NVARCHAR(MAX) NULL,
    [TenTaiKhoan] VARCHAR(50) NOT NULL,
    [MaPhuHuynh] VARCHAR(10) NOT NULL,
);
GO
CREATE TABLE [dbo].[PhuHuynh]
(
    [MaPhuHuynh] VARCHAR(10) PRIMARY KEY,
    [TenPhuHuynh] NVARCHAR(50) NOT NULL,
    [GioiTinh] BIT NULL,
    [NgaySinh] DATE NULL,
    [SoDienThoai] VARCHAR(10) NOT NULL,
    [DiaChi] NVARCHAR(MAX) NULL,
    [Hinh] NVARCHAR(MAX) NULL,
    [TenTaiKhoan] VARCHAR(50) NOT NULL,
);
GO
CREATE TABLE [dbo].[GiangVien]
(
    [MaGiangVien] VARCHAR(10) PRIMARY KEY,
    [TenGiangVien] NVARCHAR(50) NOT NULL,
    [GioiTinh] BIT NULL,
    [NgaySinh] DATE NULL,
    [SoDienThoai] VARCHAR(10) NOT NULL,
    [DiaChi] NVARCHAR(MAX) NULL,
    [Hinh] NVARCHAR(MAX) NULL,
    [TenTaiKhoan] VARCHAR(50) NOT NULL,
);
GO
CREATE TABLE [dbo].[CanBoDaoTao]
(
    [MaCanBoDaoTao] VARCHAR(10) PRIMARY KEY,
    [TenCanBoDaoTao] NVARCHAR(50) NOT NULL,
    [GioiTinh] BIT NULL,
    [NgaySinh] DATE NULL,
    [SoDienThoai] VARCHAR(10) NOT NULL,
    [DiaChi] NVARCHAR(MAX) NULL,
    [Hinh] NVARCHAR(MAX) NULL,
    [TenTaiKhoan] VARCHAR(50) NOT NULL,
);
GO
CREATE TABLE [dbo].[MonHoc]
(
    [MaMonHoc] VARCHAR(10) PRIMARY KEY,
    [TenMonHoc] NVARCHAR(50) NOT NULL,
    [SoTinChi] INT NOT NULL,
);
GO
CREATE TABLE [dbo].[Lop]
(
    [MaLop] VARCHAR(10) PRIMARY KEY,
    [TrangThai] NVARCHAR(MAX) NOT NULL,
);
GO
CREATE TABLE [dbo].[ChuyenNganh]
(
    [MaChuyenNganh] VARCHAR(10) PRIMARY KEY,
    [TenChuyenNganh] NVARCHAR(50) NOT NULL,
);
GO
CREATE TABLE [dbo].[GiangVien-MonHoc]
(
    [MaGiangVien] VARCHAR(10) NOT NULL,
    [MaMonHoc] VARCHAR(10) NOT NULL,
    [DanhGia] NVARCHAR(MAX) NULL,
    PRIMARY KEY([MaGiangVien],[MaMonHoc])
);
GO
CREATE TABLE [dbo].[ChuyenNganh-MonHoc]
(
    [MaChuyenNganh] VARCHAR(10) NOT NULL,
    [MaMonHoc] VARCHAR(10) NOT NULL,
    PRIMARY KEY([MaChuyenNganh],[MaMonHoc])
);
GO
CREATE TABLE [dbo].[DiemSo]
(
    [MaSinhVien] VARCHAR(10) NOT NULL,
    [MaMonHoc] VARCHAR(10) NOT NULL,
    [MaGiangVien] VARCHAR(10) NOT NULL,
    [MaLop] VARCHAR(10) NOT NULL,
    PRIMARY KEY([MaSinhVien],[MaMonHoc])
);
ALTER TABLE SinhVien ADD CONSTRAINT FK_TaiKhoan_SinhVien FOREIGN KEY (MaSinhVien) REFERENCES SinhVien(MaSinhVien);
ALTER TABLE SinhVien ADD CONSTRAINT FK_PhuHuynh_SinhVien FOREIGN KEY (MaPhuHuynh) REFERENCES PhuHuynh(MaPhuHuynh);
ALTER TABLE GiangVien ADD CONSTRAINT FK_TaiKhoan_GiangVien FOREIGN KEY (MaGiangVien) REFERENCES GiangVien(MaGiangVien);
ALTER TABLE PhuHuynh ADD CONSTRAINT FK_TaiKhoan_PhuHuynh FOREIGN KEY (MaPhuHuynh) REFERENCES PhuHuynh(MaPhuHuynh);
ALTER TABLE CanBoDaoTao ADD CONSTRAINT FK_TaiKhoan_CanBoDaoTao FOREIGN KEY (MaCanBoDaoTao) REFERENCES CanBoDaoTao(MaCanBoDaoTao);
ALTER TABLE DiemSo ADD CONSTRAINT FK_SinhVien_DiemSo FOREIGN KEY (MaSinhVien) REFERENCES SinhVien(MaSinhVien);
ALTER TABLE DiemSo ADD CONSTRAINT FK_MonHoc_DiemSo FOREIGN KEY (MaMonHoc) REFERENCES MonHoc(MaMonHoc);
ALTER TABLE DiemSo ADD CONSTRAINT FK_GiangVien_DiemSo FOREIGN KEY (MaGiangVien) REFERENCES GiangVien(MaGiangVien);
ALTER TABLE DiemSo ADD CONSTRAINT FK_Lop_DiemSo FOREIGN KEY (MaLop) REFERENCES Lop(MaLop);
ALTER TABLE [GiangVien-MonHoc] ADD CONSTRAINT [FK_GiangVien_GiangVien-MonHoc] FOREIGN KEY (MaGiangVien) REFERENCES GiangVien(MaGiangVien);
ALTER TABLE [GiangVien-MonHoc] ADD CONSTRAINT [FK_MonHoc_GiangVien-MonHoc] FOREIGN KEY (MaMonHoc) REFERENCES MonHoc(MaMonHoc);
ALTER TABLE [ChuyenNganh-MonHoc] ADD CONSTRAINT [FK_ChuyenNganh_ChuyenNganh-MonHoc] FOREIGN KEY (MaChuyenNganh) REFERENCES ChuyenNganh(MaChuyenNganh);
ALTER TABLE [ChuyenNganh-MonHoc] ADD CONSTRAINT [FK_MonHoc_ChuyenNganh-MonHoc] FOREIGN KEY (MaMonHoc) REFERENCES MonHoc(MaMonHoc);