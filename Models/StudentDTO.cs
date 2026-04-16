using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSV.Models
{
    public class StudentDTO
    {
        public required string Mssv { get; set; }
        public required string Name { get; set; }
        public int GroupID { get; set; }
        public double? Score { get; set; }
    }
}
