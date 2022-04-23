using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Company> Companies { get; set; } = new List<Company>();
    }
}
