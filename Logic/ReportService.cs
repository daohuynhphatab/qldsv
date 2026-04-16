using Microsoft.EntityFrameworkCore;
using QLDSV.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace QLDSV.Logic
{
    public class ReportService
    {
        public static List<Class> GetAllClasses()
        {
            using var context = new QldsvContext();
            return context.Classes.OrderBy(c => c.Name).ToList();
        }

        public static DataTable GetBaoCaoDiemToanKhoaDataTable(int? classId = null)
        {
            DataTable dt = new DataTable("BaoCaoDiemToanKhoa");
            dt.Columns.Add("STT", typeof(int));
            dt.Columns.Add("MSSV", typeof(string));
            dt.Columns.Add("HoVaTen", typeof(string));
            dt.Columns.Add("Lop", typeof(string));
            dt.Columns.Add("MonHoc", typeof(string));
            dt.Columns.Add("Diem", typeof(float));
            dt.Columns.Add("DiemTrungBinh", typeof(float));

            using var context = new QldsvContext();

            // Truy vấn lấy điểm sinh viên
            var query = context.Grades
                .Include(g => g.Student)
                .ThenInclude(s => s.Class)
                .Include(g => g.SubjectGroup)
                .ThenInclude(sg => sg.Subject)
                .AsQueryable();

            if (classId.HasValue && classId.Value > 0)
            {
                query = query.Where(g => g.Student.ClassId == classId.Value);
            }

            var results = query
                .OrderBy(g => g.Student.Class.Name)
                .ThenBy(g => g.Student.Mssv)
                .ToList();

            // Tính điểm trung bình theo sinh viên
            var studentAverages = results
                .GroupBy(r => r.StudentId)
                .ToDictionary(
                    g => g.Key,
                    g => g.Average(r => r.Score ?? 0)
                );

            int stt = 1;
            int lastStudentId = -1;
            
            foreach (var g in results)
            {
                if (lastStudentId != g.StudentId && lastStudentId != -1)
                {
                    stt++;
                }
                
                DataRow row = dt.NewRow();
                row["STT"] = stt;
                row["MSSV"] = g.Student.Mssv;
                row["HoVaTen"] = g.Student.Name ?? (g.Student.User?.Username ?? "Unknown");
                row["Lop"] = g.Student.Class?.Name ?? "N/A";
                row["MonHoc"] = g.SubjectGroup?.Subject?.Name ?? "Unknown";
                row["Diem"] = g.Score ?? 0;
                row["DiemTrungBinh"] = studentAverages.ContainsKey(g.StudentId) ? studentAverages[g.StudentId] : 0;
                
                dt.Rows.Add(row);
                lastStudentId = g.StudentId;
            }

            return dt;
        }
    }
}
