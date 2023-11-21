using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Person : Entity
    {
        public string? Login {get ;set ;}
        public string? Password { get; set; }
        public string? Premissions { get; set; }

        public string? Valstybe { get; set; }
        public string? Miestas { get; set; }
        public string? Gatve { get; set; }
        public string? StudPastas => $"{Name.ToLower()}.{Surname.ToLower()}@viko.lt";
        public string? Telefonas { get; set; }
        public string? AsmPastas {  get; set; }
        public string? Fakultetas { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }


        public string? FullName
        {
            get
            {
                return $"{Id}.{Name} {Surname}";
            }
        }
    }
}
