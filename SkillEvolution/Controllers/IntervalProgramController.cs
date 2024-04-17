using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SkillEvolution.Models;
namespace SkillEvolution.Controllers
{
    public class IntervalProgramController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IList<Interval> MergeOverlapping(IList<Interval> intervals)
        {
            var outVal = new SortedSet<Interval>(intervals, new IntervalComparer());
            for (int i = 0; i < outVal.Count - 1; i++)
            {
                Interval curr = outVal.ElementAt(i);
                Interval next = outVal.ElementAt(i + 1);
                if (next.Start - curr.End < 1)
                {
                    curr.End = Math.Max(curr.End, next.End);
                    outVal.Remove(next);
                    i--;
                }
            }
            return outVal.ToList();
        }
    }


    public class IntervalComparer : IComparer<Interval>
    {
        public int Compare(Interval lhs, Interval rhs)
        {
            if (lhs.Start == rhs.Start)
            {
                return lhs.End.CompareTo(rhs.End);
            }
            return lhs.Start.CompareTo(rhs.Start);
        }
    }
}