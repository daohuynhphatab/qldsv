using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSV.Models
{
    public class GradeDTO
    {
        public Dictionary<string, double?> SubjectGrades { get; set; } = new Dictionary<string, double?>();
        
        public double Average { get; set; }
    }
}
