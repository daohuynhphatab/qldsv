using System.Data;

public class TeacherService
{
    public static int GetTeacherId(int userId)
    {
        return TeacherDB.GetTeacherId(userId);
    }
    public static DataTable GetStudents(int groupId)
    {
        return TeacherDB.GetStudents(groupId);
    }
    public static DataTable GetGroups(int teacherId)
    {
        return TeacherDB.GetGroupsByTeacher(teacherId);
    }
    public static void SaveGrade(int studentId, int sgId, double score)
    {
        TeacherDB.SaveGrade(studentId, sgId, score);
    }
    public static string GetTeacherName(int teacherId)
    {
        return TeacherDB.GetTeacherName(teacherId);
    }
    public static string GetSubject(int teacherId)
    {
        return TeacherDB.GetSubject(teacherId);
    }
}