--KHOI TAO POLICY VA GAN CAC QUYEN CAN THIET CHO DBA
EXECUTE sa_sysdba.create_policy(
                               'ACCESS_NHANVIEN',
                               'OLS_NHANVIEN'
        );

GRANT access_nhanvien_dba TO hospital_manage;

GRANT EXECUTE ON sa_sysdba TO hospital_manage;

GRANT EXECUTE ON to_lbac_data_label TO hospital_manage;
--
GRANT EXECUTE ON sa_user_admin TO hospital_manage;
--
GRANT EXECUTE ON sa_components TO hospital_manage;
-- Quyền tạo các label
GRANT EXECUTE ON sa_label_admin TO hospital_manage;
-- Quyền gán policy cho các bảng
GRANT EXECUTE ON sa_policy_admin TO hospital_manage;
--Quyền gán label cho tài khoản
GRANT EXECUTE ON sa_user_admin TO hospital_manage;
--Chuyển chuỗi thành số của label
GRANT EXECUTE ON char_to_label TO hospital_manage;

--______________________APPLY POLICY VAO CAC BANG___________________________
-- 1. BANG NHANVIEN
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

UPDATE hospital_manage.nhanvien
SET
    hoten = hoten;

COMMIT;

--GAN NHAN CHO USER
EXEC sa_user_admin.set_user_labels(
                                  'ACCESS_NHANVIEN',
                                  'QLTNNS1',
                                  'QL:BT,BS,DP,KT,TNNS,TV,CM:Q1'
     );

EXEC sa_user_admin.set_user_labels(
                                  'ACCESS_NHANVIEN',
                                  'HOSPITAL_MANAGE',
                                  'GD:BT,BS,DP,KT,TNNS,TV,CM:Q1,Q2,Q3'
     );

-- 2. BANG HOSOBENHNHAN
--LABEL FUNC
CREATE OR REPLACE FUNCTION hsbn_label (
    p_mabs IN NUMBER
) RETURN lbacsys.lbac_label AS
    v_label  VARCHAR2(80);
    v_donvi  NUMBER(
                  38,
                  0
    );
BEGIN
    v_label := 'NV:BS:';
    SELECT donvi
    INTO v_donvi
    FROM hospital_manage.nhanvien
    WHERE manv = p_mabs;

    IF v_donvi = 1 THEN
        v_label := v_label
                   || 'Q1';
    ELSIF v_donvi = 2 THEN
        v_label := v_label
                   || 'Q2';
    ELSE
        v_label := v_label
                   || 'Q3';
    END IF;

    RETURN to_lbac_data_label(
                             'ACCESS_NHANVIEN',
                             v_label
           );
--return v_label;
END hsbn_label;
/

SHOW ERRORS

--apply policy
BEGIN
    sa_policy_admin.apply_table_policy(
                                      policy_name => 'ACCESS_NHANVIEN',
                                      schema_name => 'HOSPITAL_MANAGE',
                                      table_name => 'HOSOBN',
                                      table_options => 'NO_CONTROL'
    );
END;

UPDATE hospital_manage.hosobn
SET
    ols_nhanvien = char_to_label(
        'ACCESS_NHANVIEN',
        'NV:BS:Q1'
    );

COMMIT;

EXEC sa_policy_admin.remove_table_policy(
                                        'ACCESS_NHANVIEN',
                                        'HOSPITAL_MANAGE',
                                        'HOSOBN'
     );

BEGIN
    sa_policy_admin.apply_table_policy(
                                      policy_name => 'ACCESS_NHANVIEN',
                                      schema_name => 'HOSPITAL_MANAGE',
                                      table_name => 'HOSOBN',
                                      table_options => 'READ_CONTROL,WRITE_CONTROL',
                                      label_function => 'HSBN_label(:NEW.MABS)'
    );
END;

UPDATE hospital_manage.hosobn
SET
    makb = makb;

COMMIT;
