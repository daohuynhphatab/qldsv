using System.Drawing;
using System.Windows.Forms;

namespace QLDSV.Utils
{
 public static class UiTheme
 {
 // Primary palette
 public static readonly Color Primary = Color.FromArgb(30,136,229); // blue
 public static readonly Color PrimaryDark = Color.FromArgb(21,101,192);
 public static readonly Color Accent = Color.FromArgb(0,121,107); // teal
 public static readonly Color Background = Color.FromArgb(245,247,250); // very light
 public static readonly Color PanelBackground = Color.White;
 public static readonly Color Text = Color.FromArgb(33,33,33);
 public static readonly Color MutedText = Color.FromArgb(117,117,117);

 public static void ApplyTheme(Form form)
 {
 if (form == null) return;

 form.BackColor = Background;
 form.Font = new Font("Segoe UI",9F, FontStyle.Regular, GraphicsUnit.Point);

 ApplyToControls(form.Controls);

 // Specific tweaks for DataGridView controls found on form
 foreach (Control c in GetAllControls(form))
 {
 if (c is DataGridView dgv)
 {
 StyleDataGridView(dgv);
 }
 }
 }

 private static void ApplyToControls(Control.ControlCollection controls)
 {
 foreach (Control c in controls)
 {
 switch (c)
 {
 case Panel p:
 // side panels get primary color if narrow (sidebar)
 if (p.Dock == DockStyle.Left || p.Width <=260)
 {
 p.BackColor = Primary;
 SetForeColorRecursive(p.Controls, Color.White);
 }
 else if (p.Dock == DockStyle.Top)
 {
 p.BackColor = PrimaryDark;
 SetForeColorRecursive(p.Controls, Color.White);
 }
 else
 {
 p.BackColor = PanelBackground;
 }
 break;

 case GroupBox g:
 g.ForeColor = PrimaryDark;
 g.BackColor = PanelBackground;
 break;

 case Button b:
 b.BackColor = Primary;
 b.ForeColor = Color.White;
 b.FlatStyle = FlatStyle.Flat;
 b.FlatAppearance.BorderSize =0;
 break;

 case LinkLabel ll:
 ll.LinkColor = PrimaryDark;
 ll.ActiveLinkColor = Accent;
 break;

 case Label lb:
 lb.ForeColor = Text;
 break;

 case TextBox tb:
 tb.BackColor = Color.White;
 tb.ForeColor = Text;
 break;

 case ComboBox cb:
 cb.BackColor = Color.White;
 cb.ForeColor = Text;
 break;

 case DataGridView dgv:
 // handled separately in ApplyTheme
 break;

 case PictureBox pic:
 pic.BackColor = Color.Transparent;
 break;

 default:
 // no-op
 break;
 }

 // recursive
 if (c.HasChildren)
 {
 ApplyToControls(c.Controls);
 }
 }
 }

 private static void SetForeColorRecursive(Control.ControlCollection controls, Color fore)
 {
 foreach (Control c in controls)
 {
 try { c.ForeColor = fore; } catch { }
 if (c.HasChildren) SetForeColorRecursive(c.Controls, fore);
 }
 }

 private static IEnumerable<Control> GetAllControls(Control root)
 {
 var list = new List<Control>();
 foreach (Control c in root.Controls)
 {
 list.Add(c);
 if (c.HasChildren) list.AddRange(GetAllControls(c));
 }
 return list;
 }

 private static void StyleDataGridView(DataGridView dgv)
 {
 dgv.EnableHeadersVisualStyles = false;
 dgv.ColumnHeadersDefaultCellStyle.BackColor = PrimaryDark;
 dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
 dgv.ColumnHeadersDefaultCellStyle.Font = new Font(dgv.Font, FontStyle.Bold);
 dgv.RowHeadersVisible = false;
 dgv.GridColor = Color.FromArgb(220,230,241);
 dgv.BackgroundColor = Color.White;
 dgv.DefaultCellStyle.BackColor = Color.White;
 dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(247,249,250);
 dgv.DefaultCellStyle.ForeColor = Text;
 dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
 dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
 }
 }
}
