select UTL_RAW.CAST_TO_varchar2(DBMS_CRYPTO.decrypt('80AA4DEA59B77C433A2142AE9CDD235A', 4353, UTL_RAW.CAST_TO_RAW ('A1A2A3A4A5A6CAFE'))) from dual;
--key: 'A1A2A3A4A5A6CAFE'
--type: aes 256 /* = dbms_crypto.DES_CBC_PKCS5 */
--ma hoa truong NHANVIEN.LUONG
--ma hoa data co san:
ALTER TABLE hospital_manage.NHANVIEN
    ADD LUONG_ENC RAW(100) ;

update hospital_manage.NHANVIEN
SET LUONG_ENC = DBMS_CRYPTO.encrypt(UTL_RAW.CAST_FROM_NUMBER (LUONG), 4353 , 'A1A2A3A4A5A6CAFE');

alter table hospital_manage.NHANVIEN
DROP COLUMN luong;
-- xem luong decrypt:
SELECT  UTL_RAW.CAST_TO_number(DBMS_CRYPTO.decrypt(LUONG_ENC, 4353,'A1A2A3A4A5A6CAFE'))
FROM hospital_manage.NHANVIEN;
--view decrypt
CREATE or replace VIEW NHANVIEN_DEC AS
SELECT manv ,hoten, vaitro, donvi,UTL_RAW.CAST_TO_number(DBMS_CRYPTO.decrypt(LUONG_ENC, 4353,'A1A2A3A4A5A6CAFE')) luong
FROM
    hospital_manage.NHANVIEN;
-- xem view
select * from NHANVIEN_DEC;
-- cap quyen truy cap view
grant select,insert, update on hospital_manage.NHANVIEN_DEC to QUANLYTAINGUYEN;
-- TRIGGER INSERT UPDATE
CREATE OR REPLACE TRIGGER t_iu_nhanvien 
instead of
UPDATE or insert
ON hospital_manage.NHANVIEN_DEC  
FOR EACH ROW
DECLARE 
    v_manv NUMBER(38,0);
   v_luong_enc  RAW(100) ;  
BEGIN  
    v_manv := :new.manv;
   v_luong_enc := DBMS_CRYPTO.encrypt(UTL_RAW.CAST_FROM_NUMBER (:new.LUONG), 4353 , 'A1A2A3A4A5A6CAFE');
   if UPDATING then
    update hospital_manage.NHANVIEN set luong_enc=v_luong_enc where NHANVIEN.manv=:old.manv;
    elsif inserting then 
        INSERT INTO hospital_manage.NHANVIEN(manv,hoten,vaitro,donvi,luong_enc) VALUES (:new.manv,:new.hoten,:new.vaitro,:new.donvi,v_luong_enc);
    end if;
END; 
-- Test trigger
INSERT INTO hospital_manage.NHANVIEN_DEC VALUES (100,'Ngô Bá Khá','Bác sĩ',1,900);
