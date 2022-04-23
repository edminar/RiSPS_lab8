using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba8
{
    public class Curriculum
    {
        public int Id { get; set; }
        public int AcademicYear { get; set; }
        public string Speciality { get; set; }
        public string Qualification { get; set; }
        public string FormEducation { get; set; }
        public string NameCurriculum { get; set; }
        public int Course { get; set; }
        public List<Discipline> Disciplines { get; set; } = new List<Discipline>();
    }
}
