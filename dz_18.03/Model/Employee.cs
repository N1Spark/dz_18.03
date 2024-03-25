using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz_18._03.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public int PosititonId { get; set; }
        public Position? position { get; set; }
        
    }
}
