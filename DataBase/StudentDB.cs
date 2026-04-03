using MySql.Data.MySqlClient;
using QLDSV.Model;
using System.Data;
using System.Data.Common;
using System.Xml.Linq;

public class StudentDB
{
    public static Score GetGrades(string StudentId)
    {
        var conn = DB.GetConnection();
        conn.Open();
        Score s = new Score();
        
        string query = @"SELECT 
            s.mssv,

            IFNULL(MAX(CASE WHEN sg.subject_id = 1 THEN g.score END), 0) AS ltql,
            IFNULL(MAX(CASE WHEN sg.subject_id = 2 THEN g.score END), 0) AS csdl,
            IFNULL(MAX(CASE WHEN sg.subject_id = 3 THEN g.score END), 0) AS mmt

            FROM grades g
            JOIN subject_groups sg 
                ON g.subject_group_id = sg.id

            JOIN students s 
                ON g.student_id = s.id

            WHERE s.mssv = @studentId

            GROUP BY s.mssv;";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@studentId", StudentId);
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                s.LTQL = Convert.ToDouble(reader["ltql"]);
                s.CSDL = Convert.ToDouble(reader["csdl"]);
                s.MMT = Convert.ToDouble(reader["mmt"]);
            }
        conn.Close();
        return s;
    }
    public static string GetStudentName(String StudentId)
    {
        string query = "SELECT name FROM students WHERE mssv = @studentId";
        using (MySqlConnection conn = DB.GetConnection())
        {
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@studentId", StudentId);
            conn.Open();
            object result = cmd.ExecuteScalar();
            return result != null ? result.ToString() : "";
        }
    }
    public static string GetStudentClass(String StudentId)
    {
        string query = "SELECT c.name\r\nFROM students s\r\nJOIN classes c ON s.class_id = c.id;";
        using (MySqlConnection conn = DB.GetConnection())
        {
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@studentId", StudentId);
            conn.Open();
            object result = cmd.ExecuteScalar();
            return result != null ? result.ToString() : "";
        }
    }
}