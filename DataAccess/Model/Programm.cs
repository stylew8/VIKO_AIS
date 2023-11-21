using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Programm : Entity
    {
        public int Semestras {  get; set; }

        public int Kursas { get; set; }

        [ForeignKey("DalykoId")]
        public Dalykas dalykas { get; set; }

        public int DalykoId { get; set; }

        public string ProgrammName { get; set; }
    }
}
