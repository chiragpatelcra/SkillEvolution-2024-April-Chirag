using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillEvolution.Models
{
    public class Interval
    {
        public int Start;
        public int End;
        public Interval() { Start = 0; End = 0; }
        public Interval(int s, int e) { Start = s; End = e; }
    }
}
