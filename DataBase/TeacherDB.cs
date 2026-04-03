using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Common;

public class TeacherDB
{
    public static int GetTeacherId(int userId)
    {
        var conn = DB.GetConnection();
        conn.Open();

        string query = "SELECT id FROM teachers WHERE user_id=@uid";
        MySqlCommand cmd = new MySqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@uid", userId);

        int id = Convert.ToInt32(cmd.ExecuteScalar());

        conn.Close();
        return id;
    }
    public static DataTable GetStudents(int groupId)
    {
        var conn = DB.GetConnection();
        conn.Open();
        string query = @"
        SELECT 
            s.id AS StudentID,
            s.name AS StudentName,
            sg.id AS GroupID,
            g.score
        FROM subject_groups sg
        JOIN students s ON sg.class_id = s.class_id
        LEFT JOIN grades g 
            ON g.student_id = s.id 
            AND g.subject_group_id = sg.id
        WHERE sg.id = @gid";
        MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
        da.SelectCommand.Parameters.AddWithValue("@gid", groupId);
        DataTable dt = new DataTable();
        da.Fill(dt);
        conn.Close();
        return dt;
    }
    public static void SaveGrade(int studentId, int sgId, double score)
    {
        var conn = DB.GetConnection();
        conn.Open();

        string query = @"
        INSERT INTO grades(student_id, subject_group_id, score)
        VALUES(@id,@sgid,@score)
        ON DUPLICATE KEY UPDATE score=@score";

        MySqlCommand cmd = new MySqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@id", studentId);
        cmd.Parameters.AddWithValue("@sgid", sgId);
        cmd.Parameters.AddWithValue("@score", score);

        cmd.ExecuteNonQuery();
        conn.Close();
    }
    public static DataTable GetGroupsByTeacher(int teacherId)
    {
        var conn = DB.GetConnection();
        conn.Open();
        string query = @"
        SELECT 
            t.name AS teacher_name,
            g.id
            
        FROM subject_groups g
        JOIN teachers t ON g.teacher_id = t.id
        WHERE t.id = @tid";
        MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
        da.SelectCommand.Parameters.AddWithValue("@tid", teacherId);
        DataTable dt = new DataTable();
        da.Fill(dt);
        conn.Close();
        return dt;
    }
    public static string GetTeacherName(int teacherId)
    {
        using (var conn = DB.GetConnection())
        {
            conn.Open();
            string query = "SELECT name FROM teachers WHERE id = @id";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", teacherId);

            object result = cmd.ExecuteScalar();

            return result?.ToString() ?? "";
        }
    }
    public static string GetSubject(int teacherId)
    {
        using (var conn = DB.GetConnection())
        {
            conn.Open();
            string query = @"
            SELECT 
                s.name 
            FROM subject_groups sg
            JOIN subjects s ON sg.subject_id = s.id
            WHERE sg.teacher_id = @tid
            LIMIT 1";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@tid", teacherId);
            object result = cmd.ExecuteScalar();
            return result?.ToString() ?? "";
        }
    }
}