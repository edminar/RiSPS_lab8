using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba8
{
    public class Discipline
    {
        public int Id { get; set; }
        public int CurriculumId { get; set; }
        public Curriculum Curriculum { get; set; }
        public int ChairId { get; set; }
        public Chair Chair { get; set; }
        public string NameDiscipline { get; set; }
        public int Course { get; set; }
        public int Semester { get; set; }
        public int Lecture { get; set; }
        public int Laboratory { get; set; }
        public int Practical { get; set; }
        public bool Examen { get; set; }
        public bool SetOff { get; set; }
    }
}
