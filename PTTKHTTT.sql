ALTER TABLE THONGTINDATTOUR
drop CONSTRAINT FK_THONGTINDATTOUR_khachhang;

ALTER TABLE THONGTINDATTOUR
drop CONSTRAINT FK_THONGTINDATTOUR_DSDIADIEM;

ALTER TABLE PhieuDatDV
drop CONSTRAINT FK_PhieuDatDV_KHACHHANG;

ALTER TABLE PhieuThuPhi
drop CONSTRAINT FK_PhieuThuPhi_NhanVien1;



DROP TABLE DSDIADIEM;
DROP TABLE KHACHHANG;
DROP TABLE THONGTINDATTOUR;
DROP TABLE PhieuThuPhi;
DROP TABLE NhanVien1;
DROP TABLE DichVu;
DROP TABLE PhieuDatDV; 

CREATE TABLE DSDIADIEM (
    MATOUR NUMBER(5) generated always as identity(start with 1 increment by 1),
    MADT NUMBER(5),
    TENTOUR NVARCHAR2(50),
    DIADIEMDI NVARCHAR2(50),
    SLTOIDA NUMBER(3),
    PHITOUR NVARCHAR2(50),
    DIADIEMDEN NVARCHAR2(50),

    
    CONSTRAINT DSDIADIEM_PK
    PRIMARY KEY(MATOUR)
);
CREATE TABLE KHACHHANG (
    MAKH NUMBER(5) generated always as identity(start with 1 increment by 1),
    HOTEN NVARCHAR2(50),
    CCCD NUMBER(20),
    NGAYSINH NVARCHAR2(15),
    DIACHI NVARCHAR2(50),
    SDT NVARCHAR2(12),
    EMAIL NVARCHAR2(50),

    
    CONSTRAINT KHACHHANG_PK
    PRIMARY KEY(MAKH)
);
CREATE TABLE THONGTINDATTOUR (
    MADATTOUR NUMBER(5) generated always as identity(start with 1 increment by 1),
    MATOUR NUMBER(5),
    MAKH NUMBER(5),
    DIADIEMKHOIHANH NVARCHAR2(50),
    NGAYKHOIHANH NVARCHAR2(15),
    NGAYKT NVARCHAR2(15),
    GHICHU NVARCHAR2(50),

    
    CONSTRAINT THONGTINDATTOUR_PK
    PRIMARY KEY(MADATTOUR)
);
CREATE TABLE PhieuThuPhi (
    MAPHIEUTHU NUMBER(5) generated always as identity(start with 1 increment by 1),
    MADAT NVARCHAR2(20),
    THANHTIEN NVARCHAR2(20),
    NVTHUPHI NUMBER(5),

    
    CONSTRAINT PhieuThuPhi_PK
    PRIMARY KEY(MAPHIEUTHU)
);
CREATE TABLE DichVu (
    MADV NUMBER(5) generated always as identity(start with 1 increment by 1),
    TENDV NVARCHAR2(20),
    MOTADV NVARCHAR2(50),
    LOAIDV NVARCHAR2(50),
    HOTROLOAIPHONG NVARCHAR2(50),
    PHIDV NVARCHAR2(20),

    
    CONSTRAINT DichVu_PK
    PRIMARY KEY(MADV)
);
CREATE TABLE PhieuDatDV (
    MADATDV NUMBER(5) generated always as identity(start with 1 increment by 1),
    MAKH NUMBER(5),
    STT NUMBER(5),
    MADV NUMBER(5),
    NGAYDAT NVARCHAR2(10),
    NGAYKT NVARCHAR2(10),
    SOLUONGNGUOI NUMBER(3),

    
    CONSTRAINT MADATDV_PK
    PRIMARY KEY(MADATDV)
);

create table NhanVien1(
    MANV NUMBER(5) generated always as identity(start with 1 increment by 1),
    HoTen NVARCHAR2(50),
    DIACHI NVARCHAR2(50),
    SDT NVARCHAR2(12),
    EMAIL NVARCHAR2(50),
    lUONG NUMBER,
    LOAINV NVARCHAR2(50),
    CONSTRAINT NhanVien1_PK
    PRIMARY KEY(MANV)
);

ALTER TABLE THONGTINDATTOUR
ADD CONSTRAINT FK_THONGTINDATTOUR_KHACHHANG
FOREIGN KEY (MAKH)
REFERENCES KHACHHANG(MAKH);

ALTER TABLE THONGTINDATTOUR
ADD CONSTRAINT FK_THONGTINDATTOUR_DSDIADIEM
FOREIGN KEY (MATOUR)
REFERENCES DSDIADIEM(MATOUR);

ALTER TABLE PhieuDatDV
ADD CONSTRAINT FK_PhieuDatDV_KHACHHANG
FOREIGN KEY (MAKH)
REFERENCES KHACHHANG(MAKH);

ALTER TABLE PhieuThuPhi
ADD CONSTRAINT FK_PhieuThuPhi_NhanVien1
FOREIGN KEY (NVTHUPHI)
REFERENCES NhanVien1(MANV);



INSERT INTO KHACHHANG(HOTEN,CCCD,NGAYSINH,DIACHI,SDT,EMAIL)
VALUES (N'Nguyen Van A', 0123456789,'01/01/2002','TP.Ho Chi Minh', '0123456798', 'nguyenchithuan55@gmail.com');

INSERT INTO DSDIADIEM(MADT,TENTOUR,DIADIEMDI,SLTOIDA,PHITOUR,DIADIEMDEN)
VALUES (1, 'DT001','TP.Ho Chi Minh', 50, '100000','TP.Ha Noi');

INSERT INTO DichVu(TENDV,MOTADV,LOAIDV,HOTROLOAIPHONG,PHIDV)
VALUES ('Cafe','Thuc Uong','Am Thuc','Thuong','30000' );

INSERT INTO PhieuDatDV(MAKH,STT,MADV,NGAYDAT,NGAYKT,SOLUONGNGUOI)
VALUES (1,1,1,'25/04/2023','26/04/2023',5);

INSERT INTO NhanVien1(HoTen,DIACHI,SDT,EMAIL,lUONG,LOAINV)
VALUES ('Nguyen Van A','TP.Ho Chi Minh','0123456789','nguyenchithuan55@gmail.com',1000000,'Le Tan');

INSERT INTO PhieuThuPhi(MADAT,THANHTIEN,NVTHUPHI)
VALUES ('DV1',150000,1);

INSERT INTO THONGTINDATTOUR(MATOUR,MAKH,DIADIEMKHOIHANH,NGAYKHOIHANH,NGAYKT,GHICHU)
VALUES (1,1,'TP.HO CHI MINH','25/04/2023','26/04/2023',N'TU TUC');
select*from DSDIADIEM;