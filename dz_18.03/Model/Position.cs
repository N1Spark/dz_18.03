using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz_18._03.Model
{
    public class Position
    {
        public int Id { get; set; }
        public string? NamePosition { get; set; }
        public virtual ICollection<Employee>? Employees { get; set; }
    }
}
