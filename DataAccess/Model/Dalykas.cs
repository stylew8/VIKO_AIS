using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Dalykas : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [ForeignKey("lecturerId")]
        public Person lecturer { get; set; }
        public int lecturerId { get; set; }

        public string? FullName
        {
            get
            {
                return $"{Id}.{Name}";
            }
        }
    }
}
