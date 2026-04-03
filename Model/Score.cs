using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSV.Model
{
    public class Score
    {
        public double LTQL { get; set; }
        public double CSDL { get; set; }
        public double MMT { get; set; }

        public double Average
        {
            get { return (LTQL + CSDL + MMT) / 3; }
        }
    }
}
