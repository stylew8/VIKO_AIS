using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Student : Person
    {
        public string? Grupe { get; set; }
        public string? Kursas { get; set; }
        public int? Semestras { get; set; }
        public string? Programa { get; set; }
        
    }
}
