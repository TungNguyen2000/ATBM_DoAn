-- Audit 
-- M? ch? ?? audit: 
-- VD: K?t n?i vào root cdb.
-- ALTER SESSION SET CONTAINER=XE;
-- alter system set audit_trail = db,extended scope=spfile;
-- shutdown immediate;
-- startup

-- Thi?t l?p audit: trên statement, object, by access/by session, ?i?u ki?n kích ho?t
-- VD:  AUDIT select on HOSPITAL_MANAGE.CHITIETDONTHUOC by access whenever successful/not successful
-- Không thi?t l?p audit: trên statement, object
-- VD: NOAUDIT all on HOSPITAL_MANAGE.CHITIETDONTHUOC

-- Xóa n?i dung audit_trail
-- VD: TRUNCATE TABLE SYS.AUD$

-- Declare policy
-- Policy TOO_MUCH_MEDICINE
begin
dbms_fga.add_policy(object_schema => 'HOSPITAL_MANAGE',object_name => 'CHITIETDONTHUOC',policy_name => 'TOO_MUCH_MEDICINE',audit_condition => 'SL>=50',audit_column => 'SL');
end;
-- Policy UPDATE_HOSO_DICHVU
begin
DBMS_FGA.ADD_POLICY(object_schema => 'HOSPITAL_MANAGE', object_name => 'HOSO_DICHVU', policy_name => 'UPDATE_HOSO_DICHVU', statement_types=> 'UPDATE');
end;

-- Enable policy
-- VD: begin
-- dbms_fga.ENABLE_POLICY(object_schema => 'HOSPITAL_MANAGE',object_name => 'CHITIETDONTHUOC',policy_name => 'TOO_MUCH_MEDICINE');
-- end;

-- Disable policy
-- VD: begin
-- dbms_fga.DISABLE_POLICY(object_schema => 'HOSPITAL_MANAGE',object_name => 'CHITIETDONTHUOC',policy_name => 'TOO_MUCH_MEDICINE');
-- end;

