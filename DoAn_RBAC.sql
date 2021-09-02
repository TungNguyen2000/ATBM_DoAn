--CREATE ROLE: 
DROP ROLE NHANVIENBANTHUOC;
CREATE ROLE NHANVIENBANTHUOC not IDENTIFIED;
DROP ROLE NHANVIENKETOAN;
CREATE ROLE NHANVIENKETOAN not IDENTIFIED;
DROP ROLE BACSI;
CREATE ROLE BACSI not IDENTIFIED;
DROP ROLE TIEPTAN;
CREATE ROLE TIEPTAN not IDENTIFIED;
DROP ROLE NHANVIENTAIVU;
CREATE ROLE NHANVIENTAIVU not IDENTIFIEd;
DROP ROLE QUANLYTAINGUYEN;
CREATE ROLE QUANLYTAINGUYEN not IDENTIFIED;
DROP ROLE QUANLYTAIVU;
CREATE ROLE QUANLYTAIVU not IDENTIFIEd;
DROP ROLE QUANLYCHUYENMON;
CREATE ROLE QUANLYCHUYENMON not IDENTIFIED;
--
-- B? ph?n ti?p tân và ?i?u ph?i b?nh ???c quy?n thêm, xóa, s?a, tìm ki?m thông tin b?nh nhân
GRANT INSERT, DELETE, UPDATE, SELECT ON HOSPITAL_MANAGE.BENHNHAN TO TIEPTAN;
--TI?P TÂN ???c ?i?u ph?i b?nh nh?ng không th? xem các thông tin liên quan ??n s? ti?n cho t?ng th? t?c khám, xét nghi?m ho?c ch?p hình ho?c thông tin thu?c ?i?u tr? b?nh cho b?nh nhân
DROP VIEW HOSPITAL_MANAGE.TIEPTAN_BENHNHAN;
CREATE VIEW HOSPITAL_MANAGE.TIEPTAN_BENHNHAN AS
SELECT HSBN.MAKB, HSBN.MABS, HSBN.MABN, HSBN.NGAYKHAM, HSDV.MADV, HSDV.NGAY, HSDV.NGUOI_TH
FROM HOSPITAL_MANAGE.HOSOBN HSBN, HOSPITAL_MANAGE.HOSO_DICHVU HSDV
WHERE HSBN.MAKB = HSDV.MAKB;

drop view hospital_manage.benhnhan_dichvu_TT ;
create view hospital_manage.benhnhan_dichvu_TT 
as select hsbn.mabn, hsbn.makb,hsbn.mabs,hsbn.ngaykham from HOSPITAL_MANAGE.hosobn hsbn;
grant select, insert on hospital_manage.benhnhan_dichvu_TT to tieptan;
grant select on hospital_manage.dichvu to tieptan;
grant insert,update on hospital_manage.hosobn to tieptan;
/
create or replace trigger TT_insert_KB instead of insert on HOSPITAL_MANAGE.benhnhan_dichvu_tt for each row
declare 
matt_new number(38, 0);
begin
select to_number(sys_context('EMPLOYEE_CTX', 'ID_NHANVIEN')) INTO matt_new FROM DUAL;
insert into hospital_manage.hosobn(mabn, makb, mabs,matt, ngaykham) values (:new.mabn, :new.makb, :new.mabs, matt_new, :new.ngaykham);
end;
/
GRANT SELECT, INSERT, UPDATE, DELETE ON HOSPITAL_MANAGE.TIEPTAN_BENHNHAN TO TIEPTAN;
grant select, insert, update on HOSPITAL_MANAGE.hoso_dichvu to tieptan; 
GRANT SELECT ON HOSPITAL_MANAGE.dichvu TO BACSI;
grant insert on hospital_manage.hoso_dichvu to bacsi;
grant select, update on hospital_manage.hosobn to bacsi;
/
DROP VIEW HOSPITAL_MANAGE.TIEPTAN_DICHVU;
CREATE VIEW HOSPITAL_MANAGE.TIEPTAN_DICHVU AS
SELECT MADV, TENDV
FROM HOSPITAL_MANAGE.DICHVU;
/
drop view hospital_manage.List_doctor;
create view hospital_manage.List_doctor as
select manv, hoten from hospital_manage.nhanvien where vaitro = 'Bác s?';
grant select on hospital_manage.List_doctor to tieptan;
/
GRANT SELECT ON HOSPITAL_MANAGE.TIEPTAN_DICHVU TO TIEPTAN;
--Nhân viên phòng tài v? ch? nhìn th?y các th? t?c mà bác s? yêu c?u b?nh nhân ph?i làm khi ?i?u tr? b?nh, thông tin mà b? ph?n ?i?u ph?i b?nh ?ã ?i?u ph?i và tính ti?n
drop view HOSPITAL_MANAGE.TAIVU_DICHVU;
CREATE VIEW HOSPITAL_MANAGE.TAIVU_DICHVU AS
SELECT hsBN.maBN, BN.HOTEN, hsdv.madv, hsdv.ngay, dvu.tendv, dvu.price
FROM HOSPITAL_MANAGE.HOSO_DICHVU HSDV, HOSPITAL_MANAGE.DICHVU DVU, HOSPITAL_MANAGE.BENHNHAN BN, HOSPITAL_MANAGE.hosobn HSBN
WHERE hsdv.madv = dvu.madv AND HSDV.MAKB = hsbn.makb AND BN.MABN = HSBN.MABN;

GRANT SELECT ON HOSPITAL_MANAGE.TAIVU_DICHVU TO NHANVIENTAIVU;
GRANT select,insert ON HOSPITAL_MANAGE.CHITIETHD TO NHANVIENTAIVU;
grant select on hospital_manage.dichvu to nhanvientaivu;
grant select on hospital_manage.HoaDon to nhanvientaivu;

-- Nhân viên phòng tài v? ch? ???c c?p nh?t s? ti?n ph?i tr? cho t?ng chi ti?t khám tr? b?nh c?a b?nh nhân mà không ???c ch?nh s?a b?t c? thông tin gì
DROP VIEW HOSPITAL_MANAGE.TAIVU_HOADON;
CREATE VIEW HOSPITAL_MANAGE.TAIVU_HOADON AS
SELECT CTHD.SOHD, cthd.madv, hd.makb, dvu.price, HD.TONGTIEN
FROM HOSPITAL_MANAGE.chitiethd CTHD, HOSPITAL_MANAGE.hoadon HD, HOSPITAL_MANAGE.dichvu DVU
WHERE hd.sohd = cthd.sohd AND dvu.madv = cthd.madv;

GRANT insert, select ON HOSPITAL_MANAGE.TAIVU_HOADON TO NHANVIENTAIVU;
--Nhân viên b? ph?n bán thu?c: ch? có th? nhìn th?y toa thu?c mà bác s? kê cho t?ng b?nh nhân ?? tính ti?n thu?c cho b?nh nhân mà không th? xem ???c b?nh nhân b?nh gì hay b?t c? thông tin gì khác
DROP VIEW HOSPITAL_MANAGE.BANTHUOC_CTDONTHUOC;
CREATE VIEW HOSPITAL_MANAGE.BANTHUOC_CTDONTHUOC AS
SELECT HSBN.MABN, bn.hoten, ctdt.mathuoc, thuoc.tenth, thuoc.price * CTDT.SL AS "TONG TIEN  THUOC", ctdt.sl, hsbn.makb, ctdt.descrip 
FROM HOSPITAL_MANAGE.chitietdonthuoc CTDT, HOSPITAL_MANAGE.hosobn HSBN, HOSPITAL_MANAGE.thuoc THUOC, hospital_manage.benhnhan bn
WHERE ctdt.makb = hsbn.makb AND ctdt.mathuoc = thuoc.mathuoc and hsbn.mabn = bn.mabn;

GRANT SELECT ON HOSPITAL_MANAGE.BANTHUOC_CTDONTHUOC TO NHANVIENBANTHUOC;

--Nhân viên k? toán: tính l??ng cho các bác s? và các nhân viên khác d?a vào l??ng c? b?n, ph? c?p, s? ngày công
create or replace view hospital_manage.luong_nv_Ketoan as select nv.manv, nv.hoten , nv.vaitro, nv.donvi from hospital_manage.nhanvien nv; 

GRANT SELECT ON HOSPITAL_MANAGE.luong_nv_Ketoan TO NHANVIENketoan;

--trigger
/
CREATE OR REPLACE TRIGGER UPDATE_CTHD_HD 
AFTER INSERT OR UPDATE OR DELETE ON HOSPITAL_MANAGE.CHITIETHD 
REFERENCING OLD AS O NEW AS N
FOR EACH ROW
DECLARE
    SUM_PRICE NUMBER(19, 4);
BEGIN
    SELECT SUM(DVU.PRICE) into SUM_PRICE FROM HOSPITAL_MANAGE.CHITIETHD CTHD, HOSPITAL_MANAGE.DICHVU DVU WHERE CTHD.MADV = DVU.MADV AND CTHD.SOHD = :N.SOHD;
    UPDATE HOSPITAL_MANAGE.HOADON SET TONGTIEN = SUM_PRICE WHERE SOHD = :N.SOHD;
END;
/
select * from HOSPITAL_MANAGE.hoso_dichvu;
select * from all_users;