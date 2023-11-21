using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Marks : Entity
    {
        [ForeignKey("DalykoId")]
        public Dalykas dalykas { get; set; }

        [ForeignKey("StudentId")]
        public Student student { get; set; }

        public int Mark {  get; set; }
        public int DalykoId { get; set; }
        public int StudentId { get; set; }              
        public string Description { get; set; }
        public string Procentas { get; set; }

        public DateTime DateOfMark { get; set; }

    }
}
