-- Script seed data mẫu cho hệ thống QLDSV
-- Chạy script này sau khi đã tạo database và các bảng

-- 1. Tạo users cho giáo viên
INSERT INTO users (username, password, role, created_at) VALUES
('gv1', '$2a$11$example.hash.for.gv1', 'teacher', NOW()),
('gv2', '$2a$11$example.hash.for.gv2', 'teacher', NOW()),
('gv3', '$2a$11$example.hash.for.gv3', 'teacher', NOW());

-- 2. Tạo teachers
INSERT INTO teachers (user_id) VALUES
(1), -- gv1
(2), -- gv2
(3); -- gv3

-- 3. Tạo subjects
INSERT INTO subjects (name, credits) VALUES
('Lập trình web', 3),
('Điện toán đám mây', 3),
('Lập trình quản lí', 3);

-- 4. Tạo class mẫu
INSERT INTO classes (name) VALUES ('DTH235');

-- 5. Tạo users cho sinh viên (20 sinh viên)
INSERT INTO users (username, password, role, created_at) VALUES
('DTH235001', '$2a$11$example.hash.for.student1', 'student', NOW()),
('DTH235002', '$2a$11$example.hash.for.student2', 'student', NOW()),
('DTH235003', '$2a$11$example.hash.for.student3', 'student', NOW()),
('DTH235004', '$2a$11$example.hash.for.student4', 'student', NOW()),
('DTH235005', '$2a$11$example.hash.for.student5', 'student', NOW()),
('DTH235006', '$2a$11$example.hash.for.student6', 'student', NOW()),
('DTH235007', '$2a$11$example.hash.for.student7', 'student', NOW()),
('DTH235008', '$2a$11$example.hash.for.student8', 'student', NOW()),
('DTH235009', '$2a$11$example.hash.for.student9', 'student', NOW()),
('DTH235010', '$2a$11$example.hash.for.student10', 'student', NOW()),
('DTH235011', '$2a$11$example.hash.for.student11', 'student', NOW()),
('DTH235012', '$2a$11$example.hash.for.student12', 'student', NOW()),
('DTH235013', '$2a$11$example.hash.for.student13', 'student', NOW()),
('DTH235014', '$2a$11$example.hash.for.student14', 'student', NOW()),
('DTH235015', '$2a$11$example.hash.for.student15', 'student', NOW()),
('DTH235016', '$2a$11$example.hash.for.student16', 'student', NOW()),
('DTH235017', '$2a$11$example.hash.for.student17', 'student', NOW()),
('DTH235018', '$2a$11$example.hash.for.student18', 'student', NOW()),
('DTH235019', '$2a$11$example.hash.for.student19', 'student', NOW()),
('DTH235020', '$2a$11$example.hash.for.student20', 'student', NOW());

-- 6. Tạo students (liên kết với users và class)
INSERT INTO students (mssv, user_id, class_id) VALUES
('DTH235001', 4, 1),
('DTH235002', 5, 1),
('DTH235003', 6, 1),
('DTH235004', 7, 1),
('DTH235005', 8, 1),
('DTH235006', 9, 1),
('DTH235007', 10, 1),
('DTH235008', 11, 1),
('DTH235009', 12, 1),
('DTH235010', 13, 1),
('DTH235011', 14, 1),
('DTH235012', 15, 1),
('DTH235013', 16, 1),
('DTH235014', 17, 1),
('DTH235015', 18, 1),
('DTH235016', 19, 1),
('DTH235017', 20, 1),
('DTH235018', 21, 1),
('DTH235019', 22, 1),
('DTH235020', 23, 1);

-- 7. Tạo subject_groups (liên kết subjects, teachers, class)
INSERT INTO subject_groups (subject_id, teacher_id, class_id) VALUES
(1, 1, 1), -- Lập trình web - gv1 - DTH235
(2, 2, 1), -- Điện toán đám mây - gv2 - DTH235
(3, 3, 1); -- Lập trình quản lí - gv3 - DTH235

-- 8. Tạo một số grades mẫu (tùy chọn)
-- INSERT INTO grades (student_id, subject_group_id, score, created_at, updated_at) VALUES
-- (1, 1, 8.5, NOW(), NOW()),
-- (2, 1, 7.0, NOW(), NOW()),
-- (3, 2, 9.0, NOW(), NOW());