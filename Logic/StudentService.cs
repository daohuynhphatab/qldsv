using QLDSV.Model;
using System.Data;

public class StudentService
{
    public static Score GetGrades(String StudentId)
    {
        return StudentDB.GetGrades(StudentId);
    }
    public static string GetStudentName(String StudentId)
    {
        return StudentDB.GetStudentName(StudentId);
    }
    public static string GetStudentClass(String StudentId)
    {
        return StudentDB.GetStudentClass(StudentId);
    }

}