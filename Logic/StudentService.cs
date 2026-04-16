using QLDSV.Models;
using System.Data;
using Microsoft.EntityFrameworkCore;

public class StudentService
{
    //lay id sinh vien tu mssv
    public static int getStudentId(string mssv)
    {
        using (var context = new QldsvContext())
        {
            var student = context.Students.FirstOrDefault(s => s.Mssv == mssv);
            return student != null ? student.Id : 0;
        }
    }

    public static string? GetStudentName(int studentId)
    {
        using (var context = new QldsvContext())
        {
            var student = context.Students
                .FirstOrDefault(s => s.Id == studentId);
            return student?.Name;
        }
    }

    public static string GetStudentClass(int studentId)
    {
        using (var context = new QldsvContext())
        {
            var classname = context.Students
                .Where(s => s.Id == studentId)
                .Select(s => s.Class.Name)
                .FirstOrDefault();
            return classname;
        }
    }

    public static GradeDTO GetGrade(int studentId)
    {
        using var context = new QldsvContext();

        // Lấy tất cả điểm của sinh viên
        // Include: SubjectGroup (để có tên môn học)
        var grades = context.Grades
            .Include(g => g.SubjectGroup)
            .ThenInclude(sg => sg.Subject)
            .Where(g => g.StudentId == studentId)
            .ToList();

        // Nhóm điểm theo tên môn học
        var gradesBySubject = grades
            .GroupBy(g => g.SubjectGroup?.Subject?.Name ?? "Unknown")
            .ToDictionary(
                g => g.Key ?? "Unknown",
                g => (double?)g.FirstOrDefault()?.Score
            );

        return new GradeDTO
        {
            SubjectGrades = gradesBySubject,
            // Tính điểm trung bình = tổng điểm / số môn
            Average = grades.Any() ? grades.Average(g => (double?)g.Score) ?? 0 : 0
        };
    }

}