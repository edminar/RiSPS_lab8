using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba8
{
    public class Chair
    {
        public int Id { get; set; }
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }
        public string NameChair { get; set; }
        public string ShortNameChair { get; set; }
        public List<Discipline> Disciplines { get; set; } = new List<Discipline>();
    }
}
