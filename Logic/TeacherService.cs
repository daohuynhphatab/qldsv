using Microsoft.VisualBasic.ApplicationServices;
using QLDSV.Models;
using System.Data;
using Microsoft.EntityFrameworkCore;

public class TeacherService
{
    public static void SaveGrade(int studentId, int subjectGroupId, double score)
    {
        using (var context = new QldsvContext())
        {
            // Tìm kiếm xem sinh viên này đã có điểm cho môn này chưa
            var grade = context.Grades
                .FirstOrDefault(g => g.StudentId == studentId
                                  && g.SubjectGroupId == subjectGroupId);

            if (grade == null)
            {
                // Nếu chưa có → tạo record mới
                grade = new Grade
                {
                    StudentId = studentId,
                    SubjectGroupId = subjectGroupId,
                    Score = (float)score,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                context.Grades.Add(grade);
            }
            else
            {
                // Nếu đã có → chỉ cập nhật điểm + ngày sửa
                grade.Score = (float)score;
                grade.UpdatedAt = DateTime.Now;
            }

            context.SaveChanges();
        }
    }

    public static int GetTeacherId(int userId)
    {
        using (var context = new QldsvContext())
        {
            var teacherId = context.Teachers
                .Where(t => t.UserId == userId)
                .Select(t => t.Id)
                .FirstOrDefault();

            return teacherId; // nếu không có sẽ trả về 0
        }
    }

    public static string? GetTeacherName(int teacherId)
    {
        using var context = new QldsvContext();

        return context.Teachers
            .Where(t => t.Id == teacherId)
            .Select(t => t.Name)
            .FirstOrDefault();
    }

    public static string? GetSubject(int teacherId)
    {
        using var context = new QldsvContext();

        return context.SubjectGroups
            .Where(sg => sg.TeacherId == teacherId)
            .Select(sg => sg.Subject != null ? sg.Subject.Name : null)
            .FirstOrDefault();
    }

    public static List<object> GetGroups(int teacherId)
    {
        using var context = new QldsvContext();

        return context.SubjectGroups
            .Where(sg => sg.TeacherId == teacherId)
            .Select(sg => new
            {
                id = sg.Id
            })
            .ToList<object>();
    }

    public static List<StudentDTO> GetStudents(int groupId)
    {
        using var context = new QldsvContext();

        return context.Students
            .Where(s => s.Class.SubjectGroups.Any(sg => sg.Id == groupId))
            .Select(s => new StudentDTO
            {
                Mssv = s.Mssv,
                Name = s.Name ?? (s.User != null ? s.User.Username : "Unknown"),
                GroupID = groupId,
                // Lấy điểm (nếu có) hoặc null
                Score = s.Grades
                    .Where(g => g.SubjectGroupId == groupId)
                    .Select(g => g.Score)
                    .FirstOrDefault()
            })
            .ToList();
    }
}