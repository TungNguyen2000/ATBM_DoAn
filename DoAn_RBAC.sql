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
-- B? ph?n ti?p t�n v� ?i?u ph?i b?nh ???c quy?n th�m, x�a, s?a, t�m ki?m th�ng tin b?nh nh�n
GRANT INSERT, DELETE, UPDATE, SELECT ON HOSPITAL_MANAGE.BENHNHAN TO TIEPTAN;
--TI?P T�N ???c ?i?u ph?i b?nh nh?ng kh�ng th? xem c�c th�ng tin li�n quan ??n s? ti?n cho t?ng th? t?c kh�m, x�t nghi?m ho?c ch?p h�nh ho?c th�ng tin thu?c ?i?u tr? b?nh cho b?nh nh�n
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
select manv, hoten from hospital_manage.nhanvien where vaitro = 'B�c s?';
grant select on hospital_manage.List_doctor to tieptan;
/
GRANT SELECT ON HOSPITAL_MANAGE.TIEPTAN_DICHVU TO TIEPTAN;
--Nh�n vi�n ph�ng t�i v? ch? nh�n th?y c�c th? t?c m� b�c s? y�u c?u b?nh nh�n ph?i l�m khi ?i?u tr? b?nh, th�ng tin m� b? ph?n ?i?u ph?i b?nh ?� ?i?u ph?i v� t�nh ti?n
drop view HOSPITAL_MANAGE.TAIVU_DICHVU;
CREATE VIEW HOSPITAL_MANAGE.TAIVU_DICHVU AS
SELECT hsBN.maBN, BN.HOTEN, hsdv.madv, hsdv.ngay, dvu.tendv, dvu.price
FROM HOSPITAL_MANAGE.HOSO_DICHVU HSDV, HOSPITAL_MANAGE.DICHVU DVU, HOSPITAL_MANAGE.BENHNHAN BN, HOSPITAL_MANAGE.hosobn HSBN
WHERE hsdv.madv = dvu.madv AND HSDV.MAKB = hsbn.makb AND BN.MABN = HSBN.MABN;

GRANT SELECT ON HOSPITAL_MANAGE.TAIVU_DICHVU TO NHANVIENTAIVU;
GRANT select,insert ON HOSPITAL_MANAGE.CHITIETHD TO NHANVIENTAIVU;
grant select on hospital_manage.dichvu to nhanvientaivu;
grant select on hospital_manage.HoaDon to nhanvientaivu;

-- Nh�n vi�n ph�ng t�i v? ch? ???c c?p nh?t s? ti?n ph?i tr? cho t?ng chi ti?t kh�m tr? b?nh c?a b?nh nh�n m� kh�ng ???c ch?nh s?a b?t c? th�ng tin g�
DROP VIEW HOSPITAL_MANAGE.TAIVU_HOADON;
CREATE VIEW HOSPITAL_MANAGE.TAIVU_HOADON AS
SELECT CTHD.SOHD, cthd.madv, hd.makb, dvu.price, HD.TONGTIEN
FROM HOSPITAL_MANAGE.chitiethd CTHD, HOSPITAL_MANAGE.hoadon HD, HOSPITAL_MANAGE.dichvu DVU
WHERE hd.sohd = cthd.sohd AND dvu.madv = cthd.madv;

GRANT insert, select ON HOSPITAL_MANAGE.TAIVU_HOADON TO NHANVIENTAIVU;
--Nh�n vi�n b? ph?n b�n thu?c: ch? c� th? nh�n th?y toa thu?c m� b�c s? k� cho t?ng b?nh nh�n ?? t�nh ti?n thu?c cho b?nh nh�n m� kh�ng th? xem ???c b?nh nh�n b?nh g� hay b?t c? th�ng tin g� kh�c
DROP VIEW HOSPITAL_MANAGE.BANTHUOC_CTDONTHUOC;
CREATE VIEW HOSPITAL_MANAGE.BANTHUOC_CTDONTHUOC AS
SELECT HSBN.MABN, bn.hoten, ctdt.mathuoc, thuoc.tenth, thuoc.price * CTDT.SL AS "TONG TIEN  THUOC", ctdt.sl, hsbn.makb, ctdt.descrip 
FROM HOSPITAL_MANAGE.chitietdonthuoc CTDT, HOSPITAL_MANAGE.hosobn HSBN, HOSPITAL_MANAGE.thuoc THUOC, hospital_manage.benhnhan bn
WHERE ctdt.makb = hsbn.makb AND ctdt.mathuoc = thuoc.mathuoc and hsbn.mabn = bn.mabn;

GRANT SELECT ON HOSPITAL_MANAGE.BANTHUOC_CTDONTHUOC TO NHANVIENBANTHUOC;

--Nh�n vi�n k? to�n: t�nh l??ng cho c�c b�c s? v� c�c nh�n vi�n kh�c d?a v�o l??ng c? b?n, ph? c?p, s? ng�y c�ng
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