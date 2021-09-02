-- SUA DATA
UPDATE hosobn
SET
    mabs = dbms_random.value(
        34,
        80
    )
WHERE mabs NOT BETWEEN 34 AND 80;
--TAO LEVEL
EXEC sa_components.create_level(
                               'ACCESS_NHANVIEN',
                               9000,
                               'GD',
                               'GIÁM ĐỐC'
     );

EXEC sa_components.create_level(
                               'ACCESS_NHANVIEN',
                               8000,
                               'QL',
                               'QUẢN LÝ'
     );

EXEC sa_components.create_level(
                               'ACCESS_NHANVIEN',
                               7000,
                               'NV',
                               'NHÂN VIÊN'
     );
--TAO COMPARTMENTS
EXEC sa_components.create_compartment(
                                     'ACCESS_NHANVIEN',
                                     1000,
                                     'TNNS',
                                     'TÀI NGUYÊN NHÂN SỰ'
     );

EXEC sa_components.create_compartment(
                                     'ACCESS_NHANVIEN',
                                     1100,
                                     'TV',
                                     'TÀI VỤ'
     );

EXEC sa_components.create_compartment(
                                     'ACCESS_NHANVIEN',
                                     1200,
                                     'CM',
                                     'CHUYÊN MÔN'
     );

EXEC sa_components.create_compartment(
                                     'ACCESS_NHANVIEN',
                                     1300,
                                     'DP',
                                     'ĐIỀU PHỐI'
     );

EXEC sa_components.create_compartment(
                                     'ACCESS_NHANVIEN',
                                     1400,
                                     'BS',
                                     'BÁC SĨ'
     );

EXEC sa_components.create_compartment(
                                     'ACCESS_NHANVIEN',
                                     1500,
                                     'BT',
                                     'BÁN THUỐC'
     );

EXEC sa_components.create_compartment(
                                     'ACCESS_NHANVIEN',
                                     1600,
                                     'KT',
                                     'KẾ TOÁN'
     );
--TAO GROUPS
EXEC sa_components.create_group(
                               'ACCESS_NHANVIEN',
                               10,
                               'Q1',
                               'QUẬN 1',
                               NULL
     );

EXEC sa_components.create_group(
                               'ACCESS_NHANVIEN',
                               20,
                               'Q2',
                               'QUẬN 2',
                               NULL
     );

EXEC sa_components.create_group(
                               'ACCESS_NHANVIEN',
                               30,
                               'Q3',
                               'QUẬN 3',
                               NULL
     );
--TAO LABELS
--NV KE TOAN
EXEC sa_label_admin.create_label(
                                'ACCESS_NHANVIEN',
                                101,
                                'NV:KT:Q1'
     );

EXEC sa_label_admin.create_label(
                                'ACCESS_NHANVIEN',
                                102,
                                'NV:KT:Q2'
     );

EXEC sa_label_admin.create_label(
                                'ACCESS_NHANVIEN',
                                103,
                                'NV:KT:Q3'
     );
--NV BAN THUOC
EXEC sa_label_admin.create_label(
                                'ACCESS_NHANVIEN',
                                111,
                                'NV:BT:Q1'
     );

EXEC sa_label_admin.create_label(
                                'ACCESS_NHANVIEN',
                                112,
                                'NV:BT:Q2'
     );

EXEC sa_label_admin.create_label(
                                'ACCESS_NHANVIEN',
                                113,
                                'NV:BT:Q3'
     );
--BAC SI
EXEC sa_label_admin.create_label(
                                'ACCESS_NHANVIEN',
                                121,
                                'NV:BS:Q1'
     );

EXEC sa_label_admin.create_label(
                                'ACCESS_NHANVIEN',
                                122,
                                'NV:BS:Q2'
     );

EXEC sa_label_admin.create_label(
                                'ACCESS_NHANVIEN',
                                123,
                                'NV:BS:Q3'
     );
--NV TAI VU
EXEC sa_label_admin.create_label(
                                'ACCESS_NHANVIEN',
                                131,
                                'NV:TV:Q1'
     );

EXEC sa_label_admin.create_label(
                                'ACCESS_NHANVIEN',
                                132,
                                'NV:TV:Q2'
     );

EXEC sa_label_admin.create_label(
                                'ACCESS_NHANVIEN',
                                133,
                                'NV:TV:Q3'
     );
--NV DIEU PHOI
EXEC sa_label_admin.create_label(
                                'ACCESS_NHANVIEN',
                                141,
                                'NV:DP:Q1'
     );

EXEC sa_label_admin.create_label(
                                'ACCESS_NHANVIEN',
                                142,
                                'NV:DP:Q2'
     );

EXEC sa_label_admin.create_label(
                                'ACCESS_NHANVIEN',
                                143,
                                'NV:DP:Q3'
     );

--QUAN LI TAI NGUYEN NHAN SU
EXEC sa_label_admin.create_label(
                                'ACCESS_NHANVIEN',
                                201,
                                'QL:TNNS:Q1'
     );

EXEC sa_label_admin.create_label(
                                'ACCESS_NHANVIEN',
                                202,
                                'QL:TNNS:Q2'
     );

EXEC sa_label_admin.create_label(
                                'ACCESS_NHANVIEN',
                                203,
                                'QL:TNNS:Q3'
     );
--QUAN LI TAI VU
EXEC sa_label_admin.create_label(
                                'ACCESS_NHANVIEN',
                                211,
                                'QL:TV:Q1'
     );

EXEC sa_label_admin.create_label(
                                'ACCESS_NHANVIEN',
                                212,
                                'QL:TV:Q2'
     );

EXEC sa_label_admin.create_label(
                                'ACCESS_NHANVIEN',
                                213,
                                'QL:TV:Q3'
     );
--QUAN LI CHUYEN MON
EXEC sa_label_admin.create_label(
                                'ACCESS_NHANVIEN',
                                221,
                                'QL:CM:Q1'
     );

EXEC sa_label_admin.create_label(
                                'ACCESS_NHANVIEN',
                                222,
                                'QL:CM:Q2'
     );

EXEC sa_label_admin.create_label(
                                'ACCESS_NHANVIEN',
                                223,
                                'QL:CM:Q3'
     );
--GIAM DOC CHI NHANH
EXEC sa_label_admin.create_label(
                                'ACCESS_NHANVIEN',
                                301,
                                'GD:BT,BS,DP,KT,TNNS,TV,CM:Q1'
     );

EXEC sa_label_admin.create_label(
                                'ACCESS_NHANVIEN',
                                311,
                                'GD:TNNS:Q1'
     );

EXEC sa_label_admin.create_label(
                                'ACCESS_NHANVIEN',
                                302,
                                'GD:BT,BS,DP,KT,TNNS,TV,CM:Q2'
     );

EXEC sa_label_admin.create_label(
                                'ACCESS_NHANVIEN',
                                312,
                                'GD:TNNS:Q2'
     );

EXEC sa_label_admin.create_label(
                                'ACCESS_NHANVIEN',
                                303,
                                'GD:BT,BS,DP,KT,TNNS,TV,CM:Q3'
     );

EXEC sa_label_admin.create_label(
                                'ACCESS_NHANVIEN',
                                313,
                                'GD:TNNS:Q3'
     );
--TONG GIAM DOC
EXEC sa_label_admin.create_label(
                                'ACCESS_NHANVIEN',
                                400,
                                'GD:BT,BS,DP,KT,TNNS,TV,CM:Q1,Q2,Q3'
     );

EXEC sa_label_admin.create_label(
                                'ACCESS_NHANVIEN',
                                410,
                                'GD:TNNS:Q1,Q2,Q3'
     );

--label func
CREATE OR REPLACE FUNCTION nhanvien_label (
    p_vaitro  IN  VARCHAR2,
    p_donvi   IN  NUMBER
) RETURN lbacsys.lbac_label
--RETURN varchar2
 AS
    v_label VARCHAR2(80);
BEGIN
    IF p_vaitro LIKE '%Giám đốc%' THEN
        v_label := 'GD:';
    ELSE
        v_label := 'QL:';
    END IF;

    v_label := v_label
               || 'TNNS:';
    IF p_donvi = 1 THEN
        v_label := v_label
                   || 'Q1';
    ELSIF p_donvi = 2 THEN
        v_label := v_label
                   || 'Q2';
    ELSE
        v_label := v_label
                   || 'Q3';
    END IF;

    IF p_vaitro = 'Tổng Giám đốc' THEN
        v_label := 'GD:TNNS:Q1,Q2,Q3';
    END IF;
    RETURN to_lbac_data_label(
                             'ACCESS_NHANVIEN',
                             v_label
           );
--return v_label;
END nhanvien_label;
/

SHOW ERRORS
--
GRANT EXECUTE ON hospital_manage.nhanvien_label TO lbacsys;

GRANT SELECT, INSERT, UPDATE ON hospital_manage.nhanvien TO lbacsys;

GRANT SELECT, INSERT, UPDATE ON hospital_manage.hosobn TO lbacsys;

---------------------apply label vao bang NHANVIEN
-- LBACSYS:
BEGIN
    sa_policy_admin.apply_table_policy(
                                      policy_name => 'ACCESS_NHANVIEN',
                                      schema_name => 'HOSPITAL_MANAGE',
                                      table_name => 'NHANVIEN',
                                      table_options => 'NO_CONTROL'
    );
END;

UPDATE nhanvien
SET
    ols_nhanvien = char_to_label(
        'ACCESS_NHANVIEN',
        'QL:TNNS:Q1'
    );

COMMIT;

EXEC sa_policy_admin.remove_table_policy(
                                        'ACCESS_NHANVIEN',
                                        'HOSPITAL_MANAGE',
                                        'NHANVIEN'
     );

BEGIN
    sa_policy_admin.apply_table_policy(
                                      policy_name => 'ACCESS_NHANVIEN',
                                      schema_name => 'HOSPITAL_MANAGE',
                                      table_name => 'NHANVIEN',
                                      table_options => 'READ_CONTROL,WRITE_CONTROL',
                                      label_function => 'HOSPITAL_MANAGE.NhanVien_label(:NEW.VAITRO,:NEW.DONVI)'
    );
END;
/
---------------------

--Test Case: Quan li nhan su
CREATE USER qltnns1 IDENTIFIED BY qltnns1;

GRANT quanlytainguyen TO qltnns1;

GRANT SELECT ON hospital_manage.nhanvien TO quanlytainguyen;

GRANT connect TO qltnns1;
--Gán Label cho các user (cả DBA)
EXEC sa_user_admin.set_user_labels(
                                  'ACCESS_NHANVIEN',
                                  'qltnns1',
                                  'QL:TNNS:Q1'
     );

EXEC sa_user_admin.set_user_labels(
                                  'ACCESS_NHANVIEN',
                                  'HOSPITAL_MANAGE',
                                  'GD:BT,BS,DP,KT,TNNS,TV,CM:Q1,Q2,Q3'
     );
--Test Case: Bac si Q1
CREATE USER bs1 IDENTIFIED BY bs1;

GRANT SELECT ON hospital_manage.hosobn TO bs1;

GRANT connect TO bacsi;

GRANT
    CREATE SESSION
TO bs1;

GRANT bacsi TO bs1;

EXEC sa_user_admin.set_user_labels(
                                  'ACCESS_NHANVIEN',
                                  'bs1',
                                  'NV:BS:Q1'
     );
-- XEM LABEL CUA USER HIEN TAI
SELECT *
FROM user_sa_session;